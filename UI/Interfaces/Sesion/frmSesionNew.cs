using BLL;
using SERVICES;
using System;
using System.Drawing;
using System.Windows.Forms;
using ABSTRACCION.Contracts;
using UI;
using UI.Interfaces.InicioSesion;
using UI.Interfaces.Sesion.Administrar;
using UI.Interfaces.Sesion.Stock.GestionarStock;
using UI.Interfaces.Sesion.Servicios;
using UI.Interfaces.Sesion.Promociones;

namespace UI.Interfaces.Sesion
{
    public partial class frmSesionNew: BaseForm
    {
        private Form ActiveForm = null;
        public frmGestionUsuarios oGestionUsuarios;
        public frmGestionPermisos oGestionPermisos;
        public frmGestionIdiomas oGestionIdiomas;
        public frmGestionBitacoras oGestionBitacoras;
        public frmGestionIntegridad oGestionIntegridad;
        public frmErrorDV oErrorDV;
        public frmGestionControlDeCambios oGestionControlDeCambios;
        public frmGestionStock oGestionStock;
        public frmGestionProveedores oGestionProveedores;
        BLLUsuario _BLLUsuario;
        BLLPermisos _BLLPermisos;
        BLLSingletonSesion _oSingletonSesion;

        public frmSesionNew()
        {
            IDigitoVerificadorService iDigitoVerificadorService = new DigitoVerificadorService();
            _oSingletonSesion = BLLSingletonSesion.Instancia;
            _BLLUsuario = new BLLUsuario(iDigitoVerificadorService);
            _BLLPermisos = new BLLPermisos();
            InitializeComponent();
            ValidarForm();
        }

        #region Old
        private void gestionarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oGestionUsuarios = new frmGestionUsuarios();

            if (!FormAbierto(typeof(frmGestionUsuarios)))
            {
                oGestionUsuarios.MdiParent = this;
                oGestionUsuarios.Show();
            }
            else
            {
                MessageBox.Show("El formulario ya se encuentra abierto.");
            }
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro?", "Confirme", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _BLLUsuario.Logout();
                //ValidarForm();
            }
        }

        private void frmSesion_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("¿Está seguro?", "Confirme", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            if (BLLSingletonSesion.Instancia.IsLoggedIn())
            {
                _BLLUsuario.Logout();
            }
            //}
        }

        public static bool FormAbierto(Type Form)
        {
            foreach (Form formulario in Application.OpenForms)
            {
                if (formulario.GetType() == Form)
                {
                    return true;
                }
            }
            return false;
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oGestionPermisos = new frmGestionPermisos(_oSingletonSesion);
            if (!FormAbierto(typeof(frmGestionPermisos)))
            {
                oGestionPermisos.MdiParent = this;
                oGestionPermisos.Show();
            }
            else
            {
                MessageBox.Show("El formulario ya se encuentra abierto.");
            }
        }

        private void idiomasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oGestionIdiomas = new frmGestionIdiomas();
            if (!FormAbierto(typeof(frmGestionIdiomas)))
            {
                oGestionIdiomas.MdiParent = this;
                oGestionIdiomas.Show();
            }
            else
            {
                MessageBox.Show("El formulario ya se encuentra abierto.");
            }
        }

        private void PermisosHabilitadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bitacorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oGestionBitacoras = new frmGestionBitacoras();

            if (!FormAbierto(typeof(frmGestionBitacoras)))
            {
                oGestionBitacoras.MdiParent = this;
                oGestionBitacoras.Show();
            }
            else
            {
                MessageBox.Show("El formulario ya se encuentra abierto.");
            }
        }

        private void gestionIntegridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oGestionIntegridad = new frmGestionIntegridad();

            if (!FormAbierto(typeof(frmGestionIntegridad)))
            {
                oGestionIntegridad.MdiParent = this;
                oGestionIntegridad.Show();
            }
            else
            {
                MessageBox.Show("El formulario ya se encuentra abierto.");
            }
        }

        private void controlDeCambiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oGestionControlDeCambios = new frmGestionControlDeCambios();

            if (!FormAbierto(typeof(frmGestionControlDeCambios)))
            {
                oGestionControlDeCambios.MdiParent = this;
                oGestionControlDeCambios.Show();
            }
            else
            {
                MessageBox.Show("El formulario ya se encuentra abierto.");
            }
        }

        private void administrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gestionDeStocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oGestionStock = new frmGestionStock();

            if (!FormAbierto(typeof(frmGestionStock)))
            {
                oGestionStock.MdiParent = this;
                oGestionStock.Show();
            }
            else
            {
                MessageBox.Show("El formulario ya se encuentra abierto.");
            }
        }

        private void gestionDeProovedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oGestionProveedores = new frmGestionProveedores();

            if (!FormAbierto(typeof(frmGestionProveedores)))
            {
                oGestionProveedores.MdiParent = this;
                oGestionProveedores.Show();
            }
            else
            {
                MessageBox.Show("El formulario ya se encuentra abierto.");
            }
        }
        #endregion

        private void OpenChildForm(Form childForm)
        {
            if (ActiveForm != null) ActiveForm.Close();
            ActiveForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlChildForm.Controls.Add(childForm);
            pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void hideSubMenu(Panel subMenu)
        {
            if (subMenu.Visible) subMenu.Visible = false;
        }

        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu(subMenu);
                subMenu.Visible = true;
            }
            else subMenu.Visible = false;
        }

        public void ValidarForm()
        {
            if (_oSingletonSesion.IsLoggedIn())
            {
                this.lblUsuarioNombre.Text = _oSingletonSesion.Usuario.Usuario;
                if (_oSingletonSesion.Usuario.isAdmin)
                { btnAdministrar.Visible = true;}
            }
        }

        private void frmSesion_Load(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient mdiClient)
                {
                    mdiClient.BackColor = Color.FromArgb(73,73,73);

                    break;
                }
            }

            ValidarPermisos();
        }

        void ValidarPermisos()
        {
            if (_oSingletonSesion.IsLoggedIn())
            {
                //this.ToolStripMenuItem.Visible = _oSingletonSesion.IsInRole(TipoPermiso.Leer);
                //this.crearToolStripMenuItem.Visible = _oSingletonSesion.IsInRole(TipoPermiso.Crear);
                //this.editarToolStripMenuItem.Visible = _oSingletonSesion.IsInRole(TipoPermiso.Editar);
                //this.eliminarToolStripMenuItem.Visible = _oSingletonSesion.IsInRole(TipoPermiso.Eliminar);
                //this.verToolStripMenuItem.Visible = _oSingletonSesion.IsInRole(TipoPermiso.Leer);
                //this.administrarToolStripMenuItem.Visible = _oSingletonSesion.IsInRole(TipoPermiso.ConfigurarSistema);
                //this.controlDeCambiosToolStripMenuItem.Visible = _oSingletonSesion.IsInRole(TipoPermiso.ConfigurarSistema);
                //this.gestionDeProovedoresToolStripMenuItem.Visible = _oSingletonSesion.IsInRole(TipoPermiso.Crear);
                //this.gestionDeStocksToolStripMenuItem.Visible = _oSingletonSesion.IsInRole(TipoPermiso.Crear);
            }
            else
            {
                //this.ToolStripMenuItem.Enabled = false;
                //this.crearToolStripMenuItem.Enabled = false;
                //this.editarToolStripMenuItem.Enabled = false;
                //this.eliminarToolStripMenuItem.Enabled = false;
                //this.verToolStripMenuItem.Enabled = false;

            }
        }

        

        private void btnCalendario_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlSubMenuCalendario);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //codigo

            hideSubMenu(pnlSubMenuCalendario);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //
            hideSubMenu(pnlSubMenuCalendario);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //
            hideSubMenu(pnlSubMenuCalendario);
        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {
                 }

        private void panel37_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlStockSubMenu);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlHelpSubMenu);
        }

        
        

        private void btnGestionStock_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmGestionStock());
            hideSubMenu(pnlStockSubMenu);
        }

        private void btnStock_Click_1(object sender, EventArgs e)
        {
            ShowSubMenu(pnlStockSubMenu);
        }

        private void btnAdministar_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlAdminSubMenu);
        }

        private void btnHelp_Click_1(object sender, EventArgs e)
        {
            ShowSubMenu(pnlHelpSubMenu);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro? \n Puedes volver a iniciar sesión en cualquier momento.", "Confirme", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _BLLUsuario.Logout();
                this.Hide();

                frmInicioSesion login = new frmInicioSesion();
                login.ShowDialog();

                // Cuando cierres el login (o inicies de nuevo)
                if (login.DialogResult != DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmGestionProveedores());
            hideSubMenu(pnlStockSubMenu);
        }

        private void btnManualUsuario_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new frmGestionProveedores());
            hideSubMenu(pnlHelpSubMenu);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new frmGestionProveedores());
            hideSubMenu(pnlHelpSubMenu);
        }

        private void btnNotasVersion_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new frmGestionProveedores());
            hideSubMenu(pnlHelpSubMenu);
        }

        private void btnUusarios_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmGestionUsuarios());
            hideSubMenu(pnlAdminSubMenu);
        }

        private void btnPermisos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmGestionPermisos(_oSingletonSesion));
            hideSubMenu(pnlAdminSubMenu);
        }

        private void btnIdiomas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmGestionIdiomas());
            hideSubMenu(pnlAdminSubMenu);
        }

        private void btnBitacoras_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmGestionBitacoras());
            hideSubMenu(pnlAdminSubMenu);
        }

        private void btnIntegridad_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmGestionIntegridad());
            hideSubMenu(pnlAdminSubMenu);
        }

        private void btnControlCambios_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmGestionControlDeCambios());
            hideSubMenu(pnlAdminSubMenu);
        }

        private void btnAgendaTurnos_Click(object sender, EventArgs e)
        {
            try
            {
                var iIdProfesional = GeneralService.ObtenerProfesionalPorUsuarioID(_oSingletonSesion.Usuario.Id).ProfesionalID;

                if (iIdProfesional != 0)
                {
                    OpenChildForm(new frmAgendaTurnos(GeneralService.ObtenerProfesionalPorUsuarioID(_oSingletonSesion.Usuario.Id).ProfesionalID));

                    hideSubMenu(pnlSubMenuCalendario);
                }
                else
                {
                    MessageBox.Show("El usuario no es un profesional asociado. Por favor, contacte con el administrador.");
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }

        private void btnPromociones_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlPromocionesSubMenu);
        }

        private void btnMenuCliente_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlMenuClienteSubMenu);
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlServiciosSubMenu);
        }

        private void btnGestionarServicios_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmGestionarServicios());
            hideSubMenu(pnlServiciosSubMenu);
        }

        private void btnGestionarPromociones_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmGestionarPromociones());
            hideSubMenu(pnlPromocionesSubMenu);
        }
    }
}
