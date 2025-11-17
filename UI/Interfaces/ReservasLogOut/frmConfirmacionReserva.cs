using BE;
using BE.Exceptions;
using BLL;
using DocumentFormat.OpenXml.Office2010.Excel;
using SERVICES.Helpers;
using System;
using System.Data;
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
    }
}
