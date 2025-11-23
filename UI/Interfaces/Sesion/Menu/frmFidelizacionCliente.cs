using System;
using System.Windows.Forms;

namespace UI.Interfaces.Sesion.Menu
{
    public partial class frmFidelizacionCliente : BaseForm
    {
        private readonly int _clienteId;

        public frmFidelizacionCliente(int clienteId)
        {
            InitializeComponent();
            _clienteId = clienteId;
        }

        private void frmFidelizacionCliente_Load(object sender, EventArgs e)
        {
            CargarDatosCliente();
        }

        private void CargarDatosCliente()
        {
            var oUsuario = GeneralService.ObtenerUsuarioPorUsuarioID(_clienteId);

            var dt = FidelizacionService.ObtenerPorCliente(_clienteId, oUsuario.Mail);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0].IsNull("ClienteID"))
                {
                    FidelizacionService.ActualizarFidelizacionConClienteID(_clienteId, oUsuario.Mail);
                }
                lblPuntos.Text = dt.Rows[0]["PuntosAcumulados"].ToString();
            }
            else
            {
                lblPuntos.Text = "0";
            }

            dgvHistorial.DataSource = FidelizacionService.ObtenerHistorialCanjes(_clienteId);
            dgvPendientes.DataSource = FidelizacionService.ObtenerDescuentoPendiente(_clienteId);
        }

        private void numPuntosCanje_ValueChanged(object sender, EventArgs e)
        {
            decimal puntos = numPuntosCanje.Value;
            decimal descuento = (puntos / 10) * 5; // Cada 10 puntos = 5%
            lblPreviewDescuento.Text = $"Descuento estimado: {descuento}%";
        }


        private void btnAplicarDescuento_Click(object sender, EventArgs e)
        {
            int puntosDisponibles = int.Parse(lblPuntos.Text);
            int puntosCanjeados = (int)numPuntosCanje.Value;
            if (puntosCanjeados > puntosDisponibles)
            {
                MessageBox.Show("No tiene suficientes puntos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal descuento = (puntosCanjeados / 10m) * 5m;

            FidelizacionService.RegistrarDescuentoPendiente(_clienteId, descuento, puntosCanjeados);
            MessageBox.Show($"Canje exitoso. Obtendrá un {descuento}% de descuento en su próxima reserva.",
                            "Fidelización", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarDatosCliente();
        }

    }
}
