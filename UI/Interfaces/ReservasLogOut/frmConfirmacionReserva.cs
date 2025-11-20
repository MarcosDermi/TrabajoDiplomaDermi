using BE;
using SERVICES.Helpers;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UI.Interfaces.ReservasLogOut
{
    public partial class frmConfirmacionReserva : BaseForm
    {
        private bool IsLogin;
        BEReserva _oReserva;

        public frmConfirmacionReserva(BEReserva oReserva, bool IsLogin)
        {
            InitializeComponent();
            _oReserva = oReserva;
            this.IsLogin = IsLogin;
        }

        private void frmGestionProveedoresEdit_Load(object sender, EventArgs e)
        {
            lblDia.Text = _oReserva.FechaInicio.ToString("dddd, dd 'de' MMMM 'de' yyyy", new System.Globalization.CultureInfo("es-ES"));
            lblHorario.Text = _oReserva.FechaInicio.Hour.ToString();
            lblProfesional.Text = GeneralService.ListarProfesionales().FirstOrDefault(x => x.ProfesionalID == _oReserva.ProfesionalID).Nombre;

            lstServicios.Items.Clear();
            foreach (var servicio in _oReserva.Servicios)
            {
                lstServicios.Items.Add(new ListViewItem(servicio.Nombre));
            }

            lblTotal.Text = "$ " + _oReserva.PrecioTotal.ToString("F2");
            lblMedioDePago.Text = GeneralService.ObtenerMediosDePago().AsEnumerable().FirstOrDefault(x => x.Field<int>("MedioPagoID") == _oReserva.MedioDePagoID).Field<string>("Nombre");

            if (IsLogin)
            {
                txtEmail.Enabled = false;
                txtEmail.Text = SingletonSesionService.Usuario.Mail;
            }

            var oPrecioTotalDescuento = CalcularDescuentoPromocion(_oReserva.FechaInicio, _oReserva.PrecioTotal);
            if (oPrecioTotalDescuento > 0)
            {
                _oReserva.PrecioTotal = oPrecioTotalDescuento;
                lblPrecioPromo.Visible = true;
                lblPrecioPromo.Text = "- $ " + oPrecioTotalDescuento.ToString("F2") + " (Descuento Promoción)";
                lblTotal.Font = new Font(lblTotal.Font, FontStyle.Strikeout);
            }
        }

        private decimal CalcularDescuentoPromocion(DateTime dtReservaFechaInicio, decimal precioTotal)
        {
            try
            {
                var dDescuentoAcumulado = 0m;

                if (!GestionPromocionesService.VerificarPromocionVigenteParaFecha(dtReservaFechaInicio))
                {
                    return 0;
                }

                var oDtPromocionesActivas = GestionPromocionesService.ObtenerPromocionesActivas();

                if (oDtPromocionesActivas.Rows.Count > 0)
                {
                    foreach (DataRow row in oDtPromocionesActivas.Rows)
                    {
                        DateTime desde = ((DateTime)row["FechaDesde"]).Date;
                        DateTime hasta = ((DateTime)row["FechaHasta"]).Date;

                        if (dtReservaFechaInicio.Date >= desde && dtReservaFechaInicio.Date <= hasta)
                        {
                            dDescuentoAcumulado += (decimal)row["Descuento"];
                        }
                    }
                    return precioTotal - ((precioTotal * dDescuentoAcumulado) / 100);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex.Message);
                return 0;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void txtGuardar_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {

        }

        private void txtConfirmarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidatorsService.validarMail(txtEmail.Text))
                {
                    MostrarMensajeError("Debe ingresar un mail valido.");
                    return;
                }
                else
                {
                    _oReserva.Cliente.Mail = txtEmail.Text;
                    var Id = IsLogin == true ? SingletonSesionService.Usuario.Id : 0;

                    if (IsLogin)
                    {
                        var dtDesc = FidelizacionService.ObtenerDescuentoPendiente(SingletonSesionService.Usuario.Id);

                        if (dtDesc.Rows.Count > 0)
                        {
                            var descuentoID = (int)dtDesc.Rows[0]["DescuentoID"];
                            var porcentaje = (decimal)dtDesc.Rows[0]["PorcentajeDescuento"];

                            var dPrecioConDesuento = _oReserva.PrecioTotal - (_oReserva.PrecioTotal * (porcentaje / 100));

                            MessageBox.Show($"Se ha aplicado un descuento del {porcentaje}% a su reserva. El nuevo precio total es: $ {dPrecioConDesuento.ToString("F2")}", "Descuento Aplicado por Fidelizacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    var idReserva = AgendaService.ConfirmarReserva(_oReserva, Id);

                    AgendaService.ReservaAcciones(idReserva, ReservaAcciones.Confirmada);

                    var oEmailHelper = new EmailHelper();
                    oEmailHelper.EnviarConfirmacionTurno(_oReserva, idReserva);

                    MessageBox.Show($"La reserva se ha confirmado exitosamente. Su número de reserva es: {idReserva}", "Reserva Confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea cancelar la reserva?", "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
