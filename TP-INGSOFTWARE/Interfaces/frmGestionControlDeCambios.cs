using BE;
using BLL;
using System;
using System.Windows.Forms;

namespace TP_INGSOFTWARE
{
    public partial class frmGestionControlDeCambios : Form
    {
        public frmGestionControlDeCambios()
        {
            InitializeComponent();
            oBLLUsuario = new BLLUsuario();
            oBEUsuario = new BEUsuario();
            this.cmbUsuarios.DataSource = oBLLUsuario.ListarTodo(false, 0);
        }

        BLLUsuario oBLLUsuario;
        BEUsuario oBEUsuario;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var UsuarioID = (int)cmbUsuarios.SelectedItem;
            //dgvControlCambios.DataSource = 
        }

        private void cmbUsuarios_SelectedValueChanged(object sender, EventArgs e)
        {
            oBEUsuario = (BEUsuario)cmbUsuarios.SelectedValue;
            dgvControlCambios.DataSource = oBLLUsuario.ListarTodo(true, oBEUsuario.Id);

            if(dgvControlCambios.DataSource != null)
            {
                dgvControlCambios.Columns["Id"].Visible = false;
                dgvControlCambios.Columns["isAdmin"].HeaderText = "Administrador?";
            }
            
        }

        private void dgvControlCambios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oBEUsuario = (BEUsuario)dgvControlCambios.CurrentRow.DataBoundItem;

            if (dgvControlCambios.SelectedRows.Count == 1)
            {
                oBLLUsuario.GuardarConDV(oBEUsuario);
                MessageBox.Show(string.Format("El usuario {0} se recupero satisfactoriamente.", oBEUsuario.Usuario), "Exito", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Seleccione un momento para recuperar.");
            }
        }
    }
}
