using BE;
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

namespace UI.Interfaces.Sesion.Stock.GestionarStock
{
    public partial class frmGestionProveedoresEdit : BaseForm
    {
        int _ProveedorID = 0;
        public frmGestionProveedoresEdit(int ProveedorID)
        {
            InitializeComponent();
            oProveedor = new BEProveedor();
            oProveedorBLL = new BLLProveedor();
            _ProveedorID = ProveedorID;
        }

        BEProveedor oProveedor;
        BLLProveedor oProveedorBLL;
        private void frmGestionProveedoresEdit_Load(object sender, EventArgs e)
        {
            txtRazonSocial.Enabled = false;

            if (_ProveedorID != 0)
            {
                CargarProveedor(_ProveedorID);
            }
        }

        private void CargarProveedor(int ProveedorID)
        {
            var oDtProveedor = GestionStockService.ObtenerProveedores(false);

            var oProveedor = oDtProveedor.AsEnumerable()
                             .FirstOrDefault(x => (int)x["ProveedorID"] == ProveedorID);

            if (oProveedor != null)
            {
                txtCodigo.Text = oProveedor["Codigo"].ToString();
                txtNombre.Text = oProveedor["Nombre"].ToString();
                txtRazonSocial.Text = oProveedor["RazonSocial"].ToString();
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMismoNombreRazonSocial.Checked)
            {
                txtRazonSocial.Enabled = false;
                txtRazonSocial.Text = txtNombre.Text;
            }
            else
            {
                txtRazonSocial.Enabled = true;
            }
        }

        private void txtGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                oProveedor = new BEProveedor
                {
                    IdProveedor = _ProveedorID,
                    Codigo = txtCodigo.Text,
                    Nombre = txtNombre.Text,
                    RazonSocial = txtRazonSocial.Text,
                };

                var oDtProveedores = GestionStockService.ObtenerProveedores(false);

                if (oDtProveedores.Rows.Count != 0)
                {
                    foreach (DataRow oDr in oDtProveedores.Rows)
                    {
                        if (oDr["Codigo"].ToString().Equals(oProveedor.Codigo, StringComparison.OrdinalIgnoreCase) &&
                            (int)oDr["ProveedorID"] != oProveedor.IdProveedor)
                        {
                            MessageBox.Show("El código de proveedor ya existe. Por favor, ingrese un código único.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (oDr["Nombre"].ToString().Equals(oProveedor.Nombre, StringComparison.OrdinalIgnoreCase) &&
                            (int)oDr["ProveedorID"] != oProveedor.IdProveedor)
                        {
                            MessageBox.Show("El nombre de proveedor ya existe. Por favor, ingrese un nombre único.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                if (GestionStockService.GuardarProveedor(oProveedor))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (chkMismoNombreRazonSocial.Checked)
            {
                txtRazonSocial.Text = txtNombre.Text;
            }
        }
    }
}
