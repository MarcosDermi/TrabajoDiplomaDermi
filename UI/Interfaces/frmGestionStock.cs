using BE;
using Newtonsoft.Json;
using SERVICES.Interfaces;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace UI.Interfaces
{
    public partial class frmGestionStock : BaseForm
    {
        IGestionStockService IgestionService { get; set; }
        DataTable _oDtSubcategorias = new DataTable();
        BEInsumo oBEInsumo;

        public frmGestionStock()
        {
            InitializeComponent();
            oBEInsumo = new BEInsumo();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmGestionStock_Load(object sender, EventArgs e)
        {
            cmbPresentacion.DataSource = GestionStockService.ObtenerInsumosPresentaciones();
            _oDtSubcategorias = GestionStockService.ObtenerSubcategorias(false);

            cmbProveedor.DisplayMember = "RazonSocial";
            cmbProveedor.ValueMember = "ProveedorID";
            cmbProveedor.DataSource = GestionStockService.ObtenerProveedores(true);

            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "CategoriaID";
            cmbCategoria.DataSource = GestionStockService.ObtenerCategorias(true);

            cmbSubCategoria.DisplayMember = "SubcategoriaNombre";
            cmbSubCategoria.ValueMember = "CategoriaID";
            cmbSubCategoria.DataSource = GestionStockService.OrdenarSubcategoriasPorCategoria(_oDtSubcategorias, cmbCategoria.SelectedValue.ToString());

            dgvResultadoBusqueda.DataSource = GestionStockService.BuscarInsumosPorFiltrosVarios(string.Empty, string.Empty, 0, 0, 0);
            lblCantRegistros.Text = dgvResultadoBusqueda.Rows.Count.ToString();
            if (dgvResultadoBusqueda.Rows.Count > 0)
            {
                btnSerializar.Enabled = true;
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCrearInsumo_Click(object sender, EventArgs e)
        {
            frmGestionStockInsumosEdit ofrmGestionStockInsumosEdit = new frmGestionStockInsumosEdit();

            this.Hide();

            if (ofrmGestionStockInsumosEdit.ShowDialog() == DialogResult.OK)
            {
                // El registro fue exitoso, podés hacer algo
            }

            // Opcional: restaurás la ventana si estaba minimizada
            this.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvResultadoBusqueda.DataSource = GestionStockService.BuscarInsumosPorFiltrosVarios(txtCodigoBusqueda.Text, txtNombreBusqueda.Text, (int)cmbProveedor.SelectedValue, (int)cmbSubCategoria.SelectedValue, (int)cmbPresentacion.SelectedValue);
            lblCantRegistros.Text = dgvResultadoBusqueda.Rows.Count.ToString();
            if(dgvResultadoBusqueda.Rows.Count > 0)
            {
                btnSerializar.Enabled = true;
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSubCategoria.DataSource = GestionStockService.OrdenarSubcategoriasPorCategoria(_oDtSubcategorias, cmbCategoria.SelectedValue.ToString());
        }

        private void btnEliminarInsumo_Click(object sender, EventArgs e)
        {
            var drv = (DataRowView)dgvResultadoBusqueda.CurrentRow.DataBoundItem;
            int insumoId = (int)drv["InsumoID"];
            string nombre = (string)drv["Nombre"];

            if (dgvResultadoBusqueda.SelectedRows.Count == 1)
            {
                GestionStockService.EliminarInsumo(insumoId);
                MessageBox.Show(string.Format("El insumo {0} con ID: {1} se elimino correctamente.", nombre, insumoId), "Exito", MessageBoxButtons.OK);
                btnModificarInsumo.Enabled = false;
                btnEliminarInsumo.Enabled = false;

                dgvResultadoBusqueda.DataSource = GestionStockService.BuscarInsumosPorFiltrosVarios(string.Empty, string.Empty, 0, 0, 0);
                lblCantRegistros.Text = dgvResultadoBusqueda.Rows.Count.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un insumo para eliminar.");
            }
        }

        private void dgvResultadoBusqueda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvResultadoBusqueda.SelectedRows.Count == 1)
            {
                btnEliminarInsumo.Enabled = true;
                btnModificarInsumo.Enabled = true;
            }
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            try
            {
                var oSaveFileDialog = new SaveFileDialog();
                oSaveFileDialog.Filter = "Archivos de texto (*.txt)";
                if (oSaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(oSaveFileDialog.FileName))
                    {
                        string txt = oSaveFileDialog.FileName;

                        FileStream fs = new FileStream("ResultadoInsumos.json", FileMode.Append, FileAccess.Write);

                        var oJsonSerializer = new JsonSerializer();
                        using (StreamWriter writer = new StreamWriter(fs))
                        {
                            oJsonSerializer.Serialize(writer, dgvResultadoBusqueda.DataSource);
                        }

                        fs.Close();
                    }
                }
            }
            catch (Exception ex) { MostrarMensajeError(ex); }
        }
    }
}
