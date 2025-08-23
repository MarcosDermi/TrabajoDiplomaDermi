using BLL;
using BE;
using SERVICES;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace TP_INGSOFTWARE
{
    public partial class frmSesion: Form
    {
        public frmSesion()
        {
            InitializeComponent();
            ValidarForm();
            _BLLUsuario = new BLLUsuario();
            _BLLPermisos = new BLLPermisos();
            _oSingletonSesion = new SingletonSesion();
            this.FormClosing += frmSesion_FormClosing;
        }

        public frmGestionUsuarios oGestionUsuarios;
        public frmGestionPermisos oGestionPermisos;
        public frmGestionIdiomas oGestionIdiomas;
        public frmGestionBitacoras oGestionBitacoras;
        public frmGestionIntegridad oGestionIntegridad;
        public frmErrorDV oErrorDV;
        public frmGestionControlDeCambios oGestionControlDeCambios;
        BLLUsuario _BLLUsuario;
        BLLPermisos _BLLPermisos;
        SingletonSesion _oSingletonSesion;

        public void ValidarForm()
        {
            this.itemLogout.Enabled = SingletonSesion.instancia.IsLogged();

            if (SingletonSesion.instancia.IsLogged())
            {
                this.toolStripSesion.Text = SingletonSesion.instancia.Usuario.Usuario;
                if (SingletonSesion.instancia.Usuario.isAdmin) this.administrarToolStripMenuItem.Enabled = true;
            }
            else
            { this.toolStripSesion.Text = "[Sesión no iniciada]"; this.Close(); }

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

        private void Usuario_Click(object sender, EventArgs e)
        {
            BEUsuario oBEUsuario = (BEUsuario)((ToolStripMenuItem)sender).Tag;

            this.toolStripSesion.Text = oBEUsuario.Nombre;

            ValidarPermisos();
        }

        void ValidarPermisos()
        {
            if (_oSingletonSesion.IsLoggedIn())
            {
                this.ToolStripMenuItem.Visible = _oSingletonSesion.IsInRole(TipoPermiso.Leer);
                this.crearToolStripMenuItem.Visible = _oSingletonSesion.IsInRole(TipoPermiso.Crear);
                this.editarToolStripMenuItem.Visible = _oSingletonSesion.IsInRole(TipoPermiso.Editar);
                this.eliminarToolStripMenuItem.Visible = _oSingletonSesion.IsInRole(TipoPermiso.Eliminar);
                this.verToolStripMenuItem.Visible = _oSingletonSesion.IsInRole(TipoPermiso.Leer);
                this.administrarToolStripMenuItem.Visible = _oSingletonSesion.IsInRole(TipoPermiso.ConfigurarSistema);
                this.controlDeCambiosToolStripMenuItem.Visible = _oSingletonSesion.IsInRole(TipoPermiso.ConfigurarSistema);
            }
            else
            {
                this.ToolStripMenuItem.Enabled = false;
                this.crearToolStripMenuItem.Enabled = false;
                this.editarToolStripMenuItem.Enabled = false;
                this.eliminarToolStripMenuItem.Enabled = false;
                this.verToolStripMenuItem.Enabled = false;

            }
        }

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
            ValidarForm();
            }
        }

        private void frmSesion_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("¿Está seguro?", "Confirme", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
                if (SingletonSesion.instancia.IsLogged())
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
    }
}
