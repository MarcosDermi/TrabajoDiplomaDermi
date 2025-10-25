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
        public frmGestionProveedoresEdit()
        {
            InitializeComponent();
            oProveedor = new BEProveedor();
            oProveedorBLL = new BLLProveedor();
        }

        BEProveedor oProveedor;
        BLLProveedor oProveedorBLL;
        private void frmGestionProveedoresEdit_Load(object sender, EventArgs e)
        {
            txtRazonSocial.Enabled = false;
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
            oProveedor = new BEProveedor
            {
                Codigo = txtCodigo.Text,
                Nombre = txtNombre.Text,
                RazonSocial = txtRazonSocial.Text,
            };

            if (oProveedorBLL.Guardar(oProveedor))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            ;
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
