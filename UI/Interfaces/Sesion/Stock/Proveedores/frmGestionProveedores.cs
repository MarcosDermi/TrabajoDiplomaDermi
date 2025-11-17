using BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace UI.Interfaces.Sesion.Stock.GestionarStock
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

            if (!bFiltrosVarios) { oDtProveedores = GestionStockService.ObtenerProveedores(false); }
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
            frmGestionProveedoresEdit ofrmGestionProveedoresEdit = new frmGestionProveedoresEdit(0);
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var oDrProveedor = (DataRowView)dgvProveedores.CurrentRow.DataBoundItem;

            frmGestionProveedoresEdit ofrmGestionProveedoresEdit = new frmGestionProveedoresEdit((int)oDrProveedor.Row["ProveedorID"]);
            this.Hide();

            if (ofrmGestionProveedoresEdit.ShowDialog() == DialogResult.OK)
            {
                BuscarProveedorers(false);
            }

            this.Show();
            ofrmGestionProveedoresEdit.FormClosed += (s, args) => this.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var oDrProveedor = (DataRowView)dgvProveedores.CurrentRow.DataBoundItem;

            var Resultado = MessageBox.Show("¿Está seguro que desea eliminar el proveedor seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (Resultado == DialogResult.Yes)
            {
                try
                {
                    GestionStockService.EliminarProveedor((int)oDrProveedor.Row["ProveedorID"]);
                    MessageBox.Show("Proveedor eliminado correctamente.", "Confirmacion", MessageBoxButtons.OK);
                    BuscarProveedorers(false);
                }
                catch (Exception ex)
                {
                    MostrarMensajeError(ex.Message);
                }
            }
        }
    }
}
