using ABSTRACCION;
using BE;
using BLL;
using SERVICES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_INGSOFTWARE
{
    public partial class frmGestionUsuarios : Form
    {
        public frmGestionUsuarios()
        {
            InitializeComponent();
            oBLLUsuario = new BLLUsuario();
            oBEUsuario = new BEUsuario();
            oValidators = new Validators();
            oBLLPermisos = new BLLPermisos();
            oBLLBitacora = new BLLBitacora();
            this.cboUsuarios.DataSource = oBLLUsuario.ListarTodo(false, 0);
            this.cboFamilias.DataSource = oBLLPermisos.GetAllFamilias();
            this.cboPatentes.DataSource = oBLLPermisos.GetAllPatentes();
        }

        #region ObjetosParaElFormulario

        BLLUsuario oBLLUsuario;
        BLLPermisos oBLLPermisos;
        BEUsuario oBEUsuario;
        BEUsuario oBEUsuarioTemp;
        Validators oValidators;
        BLLBitacora oBLLBitacora;

        #endregion

        public void CargarUsuariosData()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = oBLLUsuario.ListarTodo(false, 0);
            dgvUsuarios.Columns["Clave"].Visible = false;
            dgvUsuarios.Columns["DV"].Visible = false;

        }


        private void frmGestionUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuariosData();
            CargarTextBoxs();
            EstilizarDataGridView();
        }

        private void EstilizarDataGridView()
        {
            dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(63, 47, 81);
            dgvUsuarios.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;

            dgvUsuarios.RowsDefaultCellStyle.BackColor = Color.White;
            dgvUsuarios.RowsDefaultCellStyle.ForeColor = Color.Black;

            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumPurple;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsuarios.EnableHeadersVisualStyles = false;

            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.DarkSlateBlue;
            dgvUsuarios.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvUsuarios.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }


        private void CargarTextBoxs()
        {
            txtUsuario.Text = "Ingrese su nombre de usuario";
            txtUsuario.ForeColor = Color.Black;

            txtNombre.Text = "Ingrese su nombre";
            txtNombre.ForeColor = Color.Black;

            txtApellido.Text = "Ingrese su apellido";
            txtApellido.ForeColor = Color.Black;

            txtMail.Text = "Ingrese su mail";
            txtMail.ForeColor = Color.Black;

            txtDNI.Text = "Ingrese su DNI";
            txtDNI.ForeColor = Color.Black;

        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Ingrese su nombre de usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                txtUsuario.Text = "Ingrese su nombre de usuario";
                txtUsuario.ForeColor = Color.Gray;
            }
        }

        private void txtMail_Enter(object sender, EventArgs e)
        {
            if (txtMail.Text == "Ingrese su mail")
            {
                txtMail.Text = "";
                txtMail.ForeColor = Color.Black;
            }
        }

        private void txtMail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMail.Text))
            {
                txtMail.Text = "Ingrese su mail";
                txtMail.ForeColor = Color.Gray;
            }
        }

        private void txtDNI_Enter(object sender, EventArgs e)
        {
            if (txtDNI.Text == "Ingrese su DNI")
            {
                txtDNI.Text = "";
                txtDNI.ForeColor = Color.Black;
            }
        }

        private void txtDNI_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                txtDNI.Text = "Ingrese su DNI";
                txtDNI.ForeColor = Color.Gray;
            }
        }

        private void txtApellido_Enter(object sender, EventArgs e)
        {
            if (txtApellido.Text == "Ingrese su apellido")
            {
                txtApellido.Text = "";
                txtApellido.ForeColor = Color.Black;
            }
        }

        private void txtApellido_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                txtApellido.Text = "Ingrese su apellido";
                txtApellido.ForeColor = Color.Gray;
            }
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Ingrese su nombre")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.Black;
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombre.Text = "Ingrese su nombre";
                txtNombre.ForeColor = Color.Gray;
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            oBEUsuario = (BEUsuario)dgvUsuarios.CurrentRow.DataBoundItem;
            txtId.Text = oBEUsuario.Id.ToString();
            txtNombre.Text = oBEUsuario.Nombre.ToString();
            txtApellido.Text = oBEUsuario.Apellido.ToString();
            txtUsuario.Text = oBEUsuario.Usuario.ToString();
            txtDNI.Text = oBEUsuario.DNI.ToString();
            dtpFechaNac.Value = oBEUsuario.FechaNac;
            txtMail.Text = oBEUsuario.Mail.ToString();
            if (oBEUsuario.isAdmin)
            {
                chBoxAdmin.Checked = true;
            }
            else
            {
                chBoxAdmin.Checked = false;
            }
        }

        void AsignarValores()
        {
            oBEUsuario.Id = Convert.ToInt32(txtId.Text);
            oBEUsuario.Nombre = txtNombre.Text;
            oBEUsuario.Apellido = txtApellido.Text;
            oBEUsuario.Usuario = txtUsuario.Text;
            oBEUsuario.DNI = Convert.ToInt32(txtDNI.Text);
            oBEUsuario.Mail = txtMail.Text;
            oBEUsuario.FechaNac = dtpFechaNac.Value;
            if (chBoxAdmin.Checked)
            {
                oBEUsuario.isAdmin = true;
            }
            else
            {
                oBEUsuario.isAdmin = false;
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (oValidators.ValidarCamposVaciosModificar(txtId.Text, txtNombre.Text, txtApellido.Text, txtUsuario.Text, txtDNI.Text, txtMail.Text))
                {
                    throw new ArgumentException("¡Debe completar todos los campos de textos para modificar!");
                }
                if (dgvUsuarios.SelectedRows.Count > 0)
                {

                    AsignarValores();

                    if (oBLLUsuario.Guardar(oBEUsuario))
                    {

                        Bitacora oBitacora = new Bitacora()
                        {
                            Detalle = string.Format("Se produjo un: {0} en el usuario: {1}", TipoBitacoraEnum.CambioUsuario.GetDescription(), oBEUsuario.Usuario),
                            UsuarioResponsable = SingletonSesion.instancia.Usuario,
                            BitacoraEnum = TipoBitacoraEnum.CambioUsuario,
                            Fecha = DateTime.Now,
                        };

                        oBLLBitacora.GuardarBitacora(oBitacora);

                        // Actualizar DV del sistema después de modificar usuario
                        BLLDV oBLLDV = new BLLDV();
                        bool dvActualizado = oBLLDV.ActualizarDVSistema();
                        
                        if (dvActualizado)
                        {
                            MessageBox.Show("¡Usuario modificado correctamente!\n✅ DV del sistema actualizado.", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("⚠️ Usuario modificado, pero error al actualizar DV del sistema.", "Modificación Parcial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        
                        CargarUsuariosData();
                        LimpiarCampos();

                    }

                }
                else
                {
                    throw new ArgumentException("¡Debe seleccionar un usuario para modificar!");
                }

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        void LimpiarCampos()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtMail.Text = string.Empty;
            txtDNI.Text = string.Empty;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Respuesta;

            try
            {
                if (dgvUsuarios.SelectedRows.Count > 0)
                {
                    Respuesta = MessageBox.Show("¿Seguro que quiere eliminar al Usuario? ", "Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (Respuesta == DialogResult.Yes)
                    {
                        AsignarValores();

                        if (oBLLUsuario.Baja(oBEUsuario))
                        {
                            // Actualizar DV del sistema después de eliminar usuario
                            BLLDV oBLLDV = new BLLDV();
                            bool dvActualizado = oBLLDV.ActualizarDVSistema();
                            
                            if (dvActualizado)
                            {
                                MessageBox.Show("¡Usuario eliminado correctamente!\n✅ DV del sistema actualizado.", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("⚠️ Usuario eliminado, pero error al actualizar DV del sistema.", "Eliminación Parcial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            
                            CargarUsuariosData();
                            LimpiarCampos();
                        }
                        else
                        {
                            throw new ArgumentException("No se ha podido eliminar a la persona");
                        }

                    }
                }
                else
                {
                    throw new ArgumentException("¡Debe seleccionar un usuario para eliminar!");
                }

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        void LlenarTreeView(TreeNode padre, BEComponente c)
        {
            TreeNode hijo = new TreeNode(c.Nombre);
            hijo.Tag = c;
            padre.Nodes.Add(hijo);

            foreach (var item in c.Hijos)
            {
                LlenarTreeView(hijo, item);
            }

        }

        void MostrarPermisos(BEUsuario u)
        {
            this.treeView1.Nodes.Clear();
            TreeNode root = new TreeNode(u.Nombre);

            foreach (var item in u.Permisos)
            {
                LlenarTreeView(root, item);
            }

            this.treeView1.Nodes.Add(root);
            this.treeView1.ExpandAll();
        }

        private void CmdConfigurar_Click(object sender, EventArgs e)
        {
            oBEUsuario = (BEUsuario)this.cboUsuarios.SelectedItem;

            //hago una copia del objeto para no modificr el que esta en el combo.
            oBEUsuarioTemp = new BEUsuario();
            oBEUsuarioTemp.Id = oBEUsuario.Id;
            oBEUsuarioTemp.Nombre = oBEUsuario.Nombre;
            oBLLPermisos.FillUserComponents(oBEUsuarioTemp);

            MostrarPermisos(oBEUsuarioTemp);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (oBEUsuarioTemp != null)
            {
                var patente = (BEPatente)cboPatentes.SelectedItem;
                if (patente != null)
                {
                    var esta = false;

                    foreach (var item in oBEUsuarioTemp.Permisos)
                    {
                        if (oBLLPermisos.Existe(item, patente.Id))
                        {
                            esta = true;
                            break;
                        }
                    }
                    if (esta)
                        MessageBox.Show("El usuario ya tiene la patente indicada");
                    else
                    {
                        {
                            oBEUsuarioTemp.Permisos.Add(patente);
                            MostrarPermisos(oBEUsuarioTemp);
                        }
                    }
                }
            }
            else
                MessageBox.Show("Seleccione un usuario");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (oBEUsuarioTemp != null)
            {
                var flia = (BEFamilia)cboFamilias.SelectedItem;
                if (flia != null)
                {
                    var esta = false;
                    //verifico que ya no tenga el permiso. TODO: Esto debe ser parte de otra capa.
                    foreach (var item in oBEUsuarioTemp.Permisos)
                    {
                        if (oBLLPermisos.Existe(item, flia.Id))
                        {
                            esta = true;
                        }
                    }

                    if (esta)
                        MessageBox.Show("El usuario ya tiene la familia indicada");
                    else
                    {
                        {
                            oBLLPermisos.FillFamilyComponents(flia);

                            oBEUsuarioTemp.Permisos.Add(flia);
                            MostrarPermisos(oBEUsuarioTemp);
                        }
                    }
                }
            }
            else
                MessageBox.Show("Seleccione un usuario");
        }

        private void CmdGuardarFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                oBLLUsuario.GuardarPermisos(oBEUsuarioTemp);
                MessageBox.Show("Usuario guardado correctamente");
            }
            catch (Exception)
            {

                MessageBox.Show("Error al guardar el usuario");
            }
        }

        private void cboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
