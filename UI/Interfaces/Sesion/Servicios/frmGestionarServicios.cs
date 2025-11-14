using System;
using System.Data;
using System.Windows.Forms;

namespace UI.Interfaces.Sesion.Servicios
{
    public partial class frmGestionarServicios : BaseForm
    {
        int ServicioID = 0;
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

        private void dgvServiciosProfesional_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvInsumosServicios.ClearSelection();
                dgvInsumosServicios.DataSource = GestionServicioService.ObtenerObtenerInsumosPorServicio((int)dgvServiciosProfesional.Rows[e.RowIndex].Cells["ServicioID"].Value);
                lblCantRegistrosServiciosInsumos.Text = dgvInsumosServicios.Rows.Count.ToString();

                var ServicioProfesional = (DataRowView)dgvServiciosProfesional.CurrentRow.DataBoundItem;
                ServicioID = Convert.ToInt32(ServicioProfesional.Row["ServicioID"]);

                btnModificarServicio.Enabled = true;
                btnEliminarServicio.Enabled = true;
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }

        private void btnCrearInsumo_Click(object sender, EventArgs e)
        {
            frmGestionarServiciosServicioEdit ofrmGestionarServiciosServicioEdit = new frmGestionarServiciosServicioEdit(0);

            this.Hide();

            if (ofrmGestionarServiciosServicioEdit.ShowDialog() == DialogResult.OK)
            {
                // El registro fue exitoso, podés hacer algo
            }

            // Opcional: restaurás la ventana si estaba minimizada
            this.Show();
        }

        private void btnModificarInsumo_Click(object sender, EventArgs e)
        {
            frmGestionarServiciosServicioEdit ofrmGestionarServiciosServicioEdit = new frmGestionarServiciosServicioEdit(ServicioID);

            this.Hide();

            if (ofrmGestionarServiciosServicioEdit.ShowDialog() == DialogResult.OK)
            {
                // El registro fue exitoso, podés hacer algo
            }

            // Opcional: restaurás la ventana si estaba minimizada
            this.Show();
        }
    }
}
