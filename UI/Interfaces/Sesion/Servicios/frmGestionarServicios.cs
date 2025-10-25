using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Interfaces.Sesion.Servicios
{
    public partial class frmGestionarServicios : BaseForm
    {
        public frmGestionarServicios()
        {
            InitializeComponent();
        }

        private void frmGestionarServicios_Load(object sender, EventArgs e)
        {
            cmbProfesional.DisplayMember = "Nombre";
            cmbProfesional.ValueMember = "ProfesionalID";
            cmbProfesional.DataSource = GeneralService.ListarProfesionales();
        }

        private void cmbProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                dgvServiciosProfesional.ClearSelection();
                dgvServiciosProfesional.DataSource = GestionServicioService.ObtenerServiciosPorProfesional((int)cmbProfesional.SelectedValue);
                lblCantRegistrosServicios.Text = dgvServiciosProfesional.Rows.Count.ToString();
            }
            catch (Exception ex) { MostrarMensajeError(ex); }
        }
    }
}
