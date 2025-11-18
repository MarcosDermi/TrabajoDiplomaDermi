using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Interfaces.Sesion.Calendario
{
    public partial class frmMedioDePagoReservaAtendida : BaseForm
    {
        public MedioDePagoEnum MedioDePagoSeleccionado { get; private set; }

        public frmMedioDePagoReservaAtendida()
        {
            InitializeComponent();
        }

        private void frmMedioDePagoReservaAtendida_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (rbEfectivo.Checked)
            {
                MedioDePagoSeleccionado = MedioDePagoEnum.Efectivo;
                this.DialogResult = DialogResult.OK;
            }
            else if (rbTarjCredito.Checked)
            {
                MedioDePagoSeleccionado = MedioDePagoEnum.Credito;
                this.DialogResult = DialogResult.OK;
            }
            else if (rbTarjDebito.Checked)
            {
                MedioDePagoSeleccionado = MedioDePagoEnum.Debito;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MostrarMensajeError("Debe seleccionar un medio de pago.");
                return;
            }
        }
    }
}
