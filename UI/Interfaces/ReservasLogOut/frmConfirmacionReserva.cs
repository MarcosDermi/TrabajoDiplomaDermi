using BE;
using BLL;
using SERVICES.Helpers;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UI.Interfaces.ReservasLogOut
{
    public partial class frmConfirmacionReserva : BaseForm
    {

        BEReserva _oReserva;

        public frmConfirmacionReserva(BEReserva oReserva)
        {
            InitializeComponent();
            _oReserva = oReserva;
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
            if (ValidatorsService.validarMail(txtEmail.Text))
            {
                _oReserva.Cliente.Mail = txtEmail.Text;
                var idReserva = AgendaService.ConfirmarReserva(_oReserva);
                var oEmailHelper = new EmailHelper();
                oEmailHelper.EnviarConfirmacionTurno(_oReserva, idReserva);

                MessageBox.Show($"La reserva se ha confirmado exitosamente. Su número de reserva es: {idReserva}", "Reserva Confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un correo electrónico válido.", "Correo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
    }
}
