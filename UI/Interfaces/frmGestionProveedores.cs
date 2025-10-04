using BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace UI.Interfaces
{
    public partial class frmGestionProveedores : BaseForm
    {
        public frmGestionProveedores()
        {
            InitializeComponent();
        }

        private void frmGestionProveedores_Load(object sender, EventArgs e)
        {
            BuscarProveedorers(false);
        }

        private void BuscarProveedorers(bool bFiltrosVarios)
        {
            var oDtProveedores = new DataTable();

            if (!bFiltrosVarios) { oDtProveedores = GestionStockService.ObtenerProveedores(); }
            else
            {
                oDtProveedores = GestionStockService.BuscarProveedoresPorFiltrosVarios(txtCodigo.Text, txtNombre.Text, txtRazonSocial.Text);
            }

            GeneralService.LimpiarDataTable(oDtProveedores);

            dgvProveedores.DataSource = oDtProveedores;

            GeneralService.EsconderColumna(dgvProveedores, oDtProveedores.Columns["ProveedorID"].ToString());

            lblCantRegistros.Text = oDtProveedores.Rows.Count.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmGestionProveedoresEdit ofrmGestionProveedoresEdit = new frmGestionProveedoresEdit();
            this.Hide();

            if (ofrmGestionProveedoresEdit.ShowDialog() == DialogResult.OK)
            {
                BuscarProveedorers(false);
            }

            this.Show();
            ofrmGestionProveedoresEdit.FormClosed += (s, args) => this.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarProveedorers(true);
        }


    }
}
