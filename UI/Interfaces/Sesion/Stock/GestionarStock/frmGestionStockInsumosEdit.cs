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

namespace UI.Interfaces.Sesion.Stock.GestionarStock
{
    public partial class frmGestionStockInsumosEdit : BaseForm
    {
        int insumoID = 0;
        DataTable _oDtSubcategorias = new DataTable();

        public frmGestionStockInsumosEdit(int insumoID)
        {

            InitializeComponent();
            this.insumoID = insumoID;
        }

        private void frmGestionStockInsumosEdit_Load(object sender, EventArgs e)
        {
            cmbPresentacion.DataSource = GestionStockService.ObtenerInsumosPresentaciones();
            _oDtSubcategorias = GestionStockService.ObtenerSubcategorias(false);

            cmbProveedores.DisplayMember = "RazonSocial";
            cmbProveedores.ValueMember = "ProveedorID";
            cmbProveedores.DataSource = GestionStockService.ObtenerProveedores(true);

            cmbCategorias.DisplayMember = "Nombre";
            cmbCategorias.ValueMember = "CategoriaID";
            cmbCategorias.DataSource = GestionStockService.ObtenerCategorias(true);

            cmbSubCategorias.DisplayMember = "SubcategoriaNombre";
            cmbSubCategorias.ValueMember = "CategoriaID";
            cmbSubCategorias.DataSource = GestionStockService.OrdenarSubcategoriasPorCategoria(_oDtSubcategorias, cmbCategorias.SelectedValue.ToString());
        
            if(insumoID != 0)
            {
                CargarInsumo(insumoID);
            }
        }

        private void CargarInsumo(int insumoID)
        {
            try
            {
                var oBEInsumo = GestionStockService.ObtenerInsumo(insumoID);
                txtCodigo.Text = oBEInsumo.Codigo;
                txtNombre.Text = oBEInsumo.Nombre;
                cmbPresentacion.SelectedItem = oBEInsumo.Presentacion;
                cmbProveedores.SelectedValue = oBEInsumo.Proveedor.IdProveedor;
                cmbCategorias.SelectedValue = oBEInsumo.Categoria.IdCategoriaPadre;
                cmbSubCategorias.SelectedValue = oBEInsumo.Categoria.IdCategoria;
                txtCantidad.Text = oBEInsumo.Cantidad.ToString();
                txtStock.Text = oBEInsumo.Stock.ToString();
                txtStockMinimoAlerta.Text = oBEInsumo.StockMinimo.ToString();
                txtPrecioCompra.Text = oBEInsumo.PrecioCompra.ToString();
                txtDescuento.Text = oBEInsumo.Descuento.ToString();
                txtPrecioFinal.Text = oBEInsumo.PrecioFinal.ToString();
                dtpFechaVencimiento.Value = oBEInsumo.FechaVencimiento;
            }
            catch (Exception Ex)
            {
                MostrarMensajeError(Ex);
            }
        }

        private void chkAlertaStockMinimo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlertaStockMinimo.Checked)
            {
                txtStockMinimoAlerta.Enabled = true;
            }
            else
            {
                txtStockMinimoAlerta.Enabled = false;
                txtStockMinimoAlerta.Text = "0";
            }
        }

        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSubCategorias.DataSource = GestionStockService.OrdenarSubcategoriasPorCategoria(_oDtSubcategorias, cmbCategorias.SelectedValue.ToString());
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            txtStock.Text = txtCantidad.Text;
        }

        private void txtDescuento_Leave(object sender, EventArgs e)
        {
            if (!ValidatorsService.validarDecimal(txtDescuento.Text))
            {
                txtDescuento.Text = "0";
                MessageBox.Show("El valor del descuento debe ser en formato decimal. Por ejemplo: 50 o 0,50", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ;
            txtPrecioFinal.Text = PrecioTotalCalculado(Convert.ToDecimal(txtPrecioCompra.Text), Convert.ToDecimal(txtDescuento.Text)).ToString();
        }

        private decimal PrecioTotalCalculado(decimal PrecioCompra, decimal Descuento)
        {
            return PrecioCompra - ((PrecioCompra * Descuento) / 100);
        }

        private void txtPrecioCompra_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPrecioFinal.Text = PrecioTotalCalculado(Convert.ToDecimal(txtPrecioCompra.Text), Convert.ToDecimal(txtDescuento.Text)).ToString();
            }
            catch (Exception Ex)
            {
                MostrarMensajeError(Ex);
            }
        }

        private void btnCrearInsumo_Click(object sender, EventArgs e)
        {
            try
            {
                var oBEInsumo = new BEInsumo()
                {
                    IDInsumo = insumoID,
                    Codigo = txtCodigo.Text,
                    Nombre = txtNombre.Text,
                    Presentacion = (UnidadesEnum)cmbPresentacion.SelectedItem,
                    Proveedor = { IdProveedor = Convert.ToInt32(cmbProveedores.SelectedValue) },
                    Categoria = { IdCategoria = Convert.ToInt32(cmbSubCategorias.SelectedValue),
                    IdCategoriaPadre = Convert.ToInt32(cmbCategorias.SelectedValue)},
                    Cantidad = Convert.ToDecimal(txtCantidad.Text),
                    Stock = Convert.ToInt32(txtStock.Text),
                    StockMinimo = Convert.ToDecimal(txtStockMinimoAlerta.Text),
                    PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text),
                    Descuento = Convert.ToDecimal(txtDescuento.Text),
                    PrecioFinal = Convert.ToDecimal(txtPrecioFinal.Text),
                    FechaVencimiento = dtpFechaVencimiento.Value,
                };

                if (GestionStockService.GuardarInsumo(oBEInsumo))
                {
                    MessageBox.Show("Insumo guardado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al guardar el insumo. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Ex)
            {
                MostrarMensajeError(Ex);
            }
        }
    }
}
