using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;


namespace UI.Interfaces.Sesion.Servicios
{
    public partial class frmGestionarServiciosBusquedaInsumo : BaseForm
    {
        DataTable _oDtSubcategorias = new DataTable();
        public delegate void InsumosSeleccionadosHandler(List<InsumoSeleccionado> insumos);
        public List<InsumoSeleccionado> InsumosSeleccionados { get; private set; } = new List<InsumoSeleccionado>();



        public frmGestionarServiciosBusquedaInsumo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmGestionarServiciosBusquedaInsumo_Load(object sender, EventArgs e)
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
            dgvResultadoBusqueda.DataSource = GestionStockService.BuscarInsumosPorFiltrosVarios(string.Empty, string.Empty, 0, 0, 0);

            PrepararDataGridView(dgvResultadoBusqueda);

        }

        private void PrepararDataGridView(DataGridView oDGV)
        {
            if (dgvResultadoBusqueda.Rows.Count > 0)
            {
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.HeaderText = "Seleccionar";
                chk.Name = "Seleccionar";
                chk.Width = 80; // opcional
                chk.ReadOnly = false;
                dgvResultadoBusqueda.Columns.Insert(0, chk);

                DataGridViewTextBoxColumn colCantidad = new DataGridViewTextBoxColumn();
                colCantidad.HeaderText = "Cantidad a usar";
                colCantidad.Name = "Cantidad";
                colCantidad.Width = 100;
                colCantidad.ReadOnly = false;
                dgvResultadoBusqueda.Columns.Insert(1, colCantidad);
            }

            foreach (DataGridViewColumn col in dgvResultadoBusqueda.Columns)
            {
                if (col.Name == "Seleccionar" || col.Name == "Cantidad" || col.Name.Equals("InsumoID", StringComparison.OrdinalIgnoreCase) || col.Name.Equals("Codigo", StringComparison.OrdinalIgnoreCase) || col.Name.Equals("Nombre", StringComparison.OrdinalIgnoreCase) || col.Name.Equals("Cantidad", StringComparison.OrdinalIgnoreCase))
                {

                    col.Visible = true;
                    col.ReadOnly = true;

                    if (col.Name == "Seleccionar" || col.Name == "Cantidad")
                    {
                        col.ReadOnly = false;
                    }
                }
                else
                {
                    col.Visible = false;
                }
            }
        }

        private void btnCrearInsumo_Click(object sender, EventArgs e)
        {
            InsumosSeleccionados.Clear();

            foreach (DataGridViewRow row in dgvResultadoBusqueda.Rows)
            {
                bool seleccionado = row.Cells["Seleccionar"].Value != null && (bool)row.Cells["Seleccionar"].Value;
                if (seleccionado)
                {
                    var insumo = new InsumoSeleccionado
                    {
                        InsumoID = Convert.ToInt32(row.Cells["InsumoID"].Value),
                        Codigo = row.Cells["Codigo"].Value?.ToString(),
                        Nombre = row.Cells["Nombre"].Value?.ToString(),
                        CantidadStock = Convert.ToDecimal(row.Cells["Stock"].Value),
                        CantidadUsar = Convert.ToDecimal(row.Cells["Cantidad"].Value ?? 0)
                    };
                    InsumosSeleccionados.Add(insumo);
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
    

}
