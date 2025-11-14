using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Interfaces.Sesion.Menu
{
    public partial class frmFidelizacionCliente : BaseForm
    {
        private readonly BLLFidelizacion _bll = new BLLFidelizacion();
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
            var dt = _bll.ObtenerPorCliente(_clienteId);
            if (dt.Rows.Count > 0)
            {
                lblPuntos.Text = dt.Rows[0]["PuntosAcumulados"].ToString();
            }
            else
            {
                lblPuntos.Text = "0";
            }

            dgvHistorial.DataSource = _bll.ObtenerHistorialCanjes(_clienteId);
            dgvPendientes.DataSource = _bll.ObtenerDescuentoPendiente(_clienteId);
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

            _bll.RegistrarDescuentoPendiente(_clienteId, descuento, puntosCanjeados);
            MessageBox.Show($"Canje exitoso. Obtendrá un {descuento}% de descuento en su próxima reserva.",
                            "Fidelización", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarDatosCliente();
        }

    }
}
