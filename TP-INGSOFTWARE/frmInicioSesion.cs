using BE;
using BLL;
using SERVICES;
using BE.ClasesMultiLenguaje;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace TP_INGSOFTWARE
{
    public partial class frmInicioSesion : Form,IdiomaObserver
    {
        BLLUsuario oBLLUsuario = new BLLUsuario();
        Validators oValidators = new Validators();
        BLLPermisos oBLLPermisos = new BLLPermisos();
        BEUsuario oBEUsuario;

        public frmInicioSesion()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void frmInicioSesion_Load(object sender, EventArgs e)
        {
            CargarTextBoxs();
            txtUsuario.Text = "DD";
            txtClave.Text = "123";
            Observer.agregarObservador(this);
            ListarIdiomas();
            txtUsuario.KeyPress += txtUsuario_KeyPress;
            txtClave.KeyPress += txtClave_KeyPress;
        }

        // Método público para recargar idiomas desde otros formularios
        public void RecargarIdiomas()
        {
            ListarIdiomas();
        }

        private void ListarIdiomas()
        {
            try
            {
                BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
                var ListaIdiomas = Traductor.ObtenerIdiomas();

                cbIdioma.DataSource = null;
                cbIdioma.DataSource = ListaIdiomas;

                // Cargar traducciones de todos los idiomas en la sesión
                foreach (Idioma idioma in ListaIdiomas)
                {
                    var traducciones = Traductor.obtenertraducciones(idioma);
                    if (traducciones != null && traducciones.Count > 0)
                    {
                        SingletonSesion.instancia.AgregarTraduccionesIdioma(idioma.Nombre, traducciones);
                    }
                }

                // Seleccionar idioma default
                foreach (Idioma idioma in ListaIdiomas)
                {
                    if (idioma.Default)
                    {
                        cbIdioma.SelectedItem = idioma;
                        break;
                    }
                }
                
                // Seteo en la sesión el idioma elegido
                Idioma idiomaActual = (Idioma)cbIdioma.SelectedItem;
                if (idiomaActual != null)
                {
                    SingletonSesion.instancia.idioma = idiomaActual;
                }
                
                // Aplicar traducciones del idioma seleccionado
                if (idiomaActual != null)
                {
                    traducir();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar idiomas: " + ex.Message);
            }
        }



        public void CambiarIdioma(Idioma Idioma)
        {
            traducir();
        }

        private void traducir()
        {
            try
            {
                Idioma idioma = (Idioma)cbIdioma.SelectedItem;

                if (idioma.Default)
                {
                    VolverAidiomaOriginal(); //cambio al oriignal
                }
                else
                {
                    // Obtengo traducciones ya cargadas de la sesión
                    var traducciones = SingletonSesion.instancia.ObtenerTraduccionesPorIdioma(idioma.Nombre);

                    if (traducciones == null)
                    {
                        // Si no hay traducciones, volver al idioma original sin mostrar error
                        VolverAidiomaOriginal();
                        return;
                    }


                    if (chkMostrarContraseña.Tag != null && traducciones.ContainsKey(chkMostrarContraseña.Tag.ToString()))
                        this.chkMostrarContraseña.Text = traducciones[chkMostrarContraseña.Tag.ToString()].texto;

                    if (btnIniciarSesion.Tag != null && traducciones.ContainsKey(btnIniciarSesion.Tag.ToString()))
                        this.btnIniciarSesion.Text = traducciones[btnIniciarSesion.Tag.ToString()].texto;

                    if (btnRegistrarse.Tag != null && traducciones.ContainsKey(btnRegistrarse.Tag.ToString()))
                        this.btnRegistrarse.Text = traducciones[btnRegistrarse.Tag.ToString()].texto;

                    if (lblIdiomaIS.Tag != null && traducciones.ContainsKey(lblIdiomaIS.Tag.ToString()))
                        this.lblIdiomaIS.Text = traducciones[lblIdiomaIS.Tag.ToString()].texto;

                    if (txtUsuario.Tag != null && traducciones.ContainsKey(txtUsuario.Tag.ToString()))
                        this.txtUsuario.Text = traducciones[txtUsuario.Tag.ToString()].texto;

                    if (txtClave.Tag != null && traducciones.ContainsKey(txtClave.Tag.ToString()))
                        this.txtClave.Text = traducciones[txtClave.Tag.ToString()].texto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarTextBoxs()
        {
            txtUsuario.Text = "Ingrese nombre de usuario";
            txtUsuario.ForeColor = Color.Gray;

            txtClave.PasswordChar = '\0';
            txtClave.Text = "Ingrese una contraseña";
            txtClave.ForeColor = Color.Gray;

        }


        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Ingrese nombre de usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                txtUsuario.Text = "Ingrese nombre de usuario";
                txtUsuario.ForeColor = Color.Gray;
            }
        }


        private void OnBtnRegistrarseClick(object sender, EventArgs e)
        {
            frmRegistrarUsuario frmRegistrarUsuario = new frmRegistrarUsuario();

            this.Hide();

            if (frmRegistrarUsuario.ShowDialog() == DialogResult.OK)
            {
                // El registro fue exitoso, podés hacer algo
            }

            // Opcional: restaurás la ventana si estaba minimizada
            this.Show();
        }

        private void chkMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if(chkMostrarContraseña.Checked)txtClave.PasswordChar = '\0';
            else { txtClave.PasswordChar = '\u2022'; }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (!oValidators.ValidarCamposVacios(txtUsuario.Text, txtClave.Text))
            {
                try
                {
                    LoginResult result = oBLLUsuario.Login(txtUsuario.Text, txtClave.Text);
                    
                    if (result == LoginResult.ValidUser)
                    {
                        BLLDV oBLLDV = new BLLDV();
                        bool integridadSistema = oBLLDV.ValidarIntegridadSistema();
                        bool isAdmin = SingletonSesion.instancia.Usuario.isAdmin;

                        
                        if (integridadSistema)
                        {
                            frmSesion frmSesion = new frmSesion();
                            frmSesion.FormClosed += (s, args) => this.Show();
                            frmSesion.Show();
                            this.Hide();
                        }
                        else if (isAdmin && !integridadSistema)
                        {
                            
                            
                            frmErrorDV frmErrorDV = new frmErrorDV();
                            frmErrorDV.FormClosed += (s, args) => {
                                // Cuando se cierra el formulario de error, volver al login
                                this.Show();
                                // Limpiar campos de login
                                txtUsuario.Text = "";
                                txtClave.Text = "";
                                txtUsuario.Focus();
                            };
                            frmErrorDV.Show();
                            this.Hide();
                        }
                        else
                        {
                            // Limpiar la sesión para permitir intentar con otro usuario
                            if (SingletonSesion.instancia.IsLogged())
                            {
                                SingletonSesion.instancia.Logout();
                            }
                            
                            MessageBox.Show("❌ Error de Dígito Verificador\nSe detectó corrupción en los datos del sistema, acceso denegado.\n\nSesión cerrada. Puede intentar con otro usuario.",
                                "Error de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            
                            // Limpiar campos de login
                            txtUsuario.Text = "";
                            txtClave.Text = "";
                            txtUsuario.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (LoginException error)
                {
                    switch (error.Result)
                    {
                        case LoginResult.InvalidUsername:
                            MessageBox.Show("Usuario incorrecto", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case LoginResult.InvalidPassword:
                            MessageBox.Show("Clave Incorrecta", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        default:
                            MessageBox.Show("Error desconocido en el login", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos","Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtClave_Enter(object sender, EventArgs e)
        {
            if (txtClave.Text == "Ingrese una contraseña")
            {
                txtClave.PasswordChar = '\u2022';
                txtClave.Text = "";
                txtClave.ForeColor = Color.Black;
            }
        }

        private void txtClave_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                txtClave.Text = "Ingrese una contraseña";
                txtClave.ForeColor = Color.Gray;
            }
        }

        private void VolverAidiomaOriginal()
        {
            try
            {

                BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
                List<string> palabras = Traductor.obtenerIdiomaOriginal();

                if (chkMostrarContraseña.Tag != null && palabras.Contains(chkMostrarContraseña.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(chkMostrarContraseña.Tag.ToString()));
                    this.chkMostrarContraseña.Text = traduccion;
                }
                if (btnIniciarSesion.Tag != null && palabras.Contains(btnIniciarSesion.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(btnIniciarSesion.Tag.ToString()));
                    this.btnIniciarSesion.Text = traduccion;
                }
                if (btnRegistrarse.Tag != null && palabras.Contains(btnRegistrarse.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(btnRegistrarse.Tag.ToString()));
                    this.btnRegistrarse.Text = traduccion;
                }

                if (lblIdiomaIS.Tag != null && palabras.Contains(lblIdiomaIS.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(lblIdiomaIS.Tag.ToString()));
                    this.lblIdiomaIS.Text = traduccion;
                }
                if (txtUsuario.Tag != null && palabras.Contains(txtUsuario.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(txtUsuario.Tag.ToString()));
                    this.txtUsuario.Text = traduccion;
                }

                if (txtClave.Tag != null && palabras.Contains(txtClave.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(txtClave.Tag.ToString()));
                    this.txtClave.Text = traduccion;
                }

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbIdioma.SelectedItem == null)
                    return;

                Idioma idiomaSeleccionado = (Idioma)cbIdioma.SelectedItem;
                SingletonSesion.instancia.idioma = idiomaSeleccionado;
                Observer.cambiarIdioma(idiomaSeleccionado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar el idioma: " + ex.Message);
            }
        }


        private void btnIniciarSesion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnIniciarSesion.PerformClick();
            }
        }

        private void btnIniciarSesion_Enter(object sender, EventArgs e)
        {
            btnIniciarSesion.PerformClick();
        }

        private void btnIniciarSesion_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void frmInicioSesion_Enter(object sender, EventArgs e)
        {

        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnIniciarSesion.PerformClick();
                e.Handled = true;
            }
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnIniciarSesion.PerformClick();
                e.Handled = true;
            }
        }

        private void chkMostrarContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnIniciarSesion.PerformClick();
                e.Handled = true;
            }
        }
    }
}
