using System;
using BE;
using BLL;
using SERVICES;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BE.ClasesMultiLenguaje;

namespace TP_INGSOFTWARE
{
    public partial class frmRegistrarUsuario : Form,IdiomaObserver
    {
        
        BLLUsuario oBLLUsuario = new BLLUsuario();
        Validators oValidators = new Validators();

        public frmRegistrarUsuario()
        {
            
            InitializeComponent();
        }

        private void frmRegistrarUsuario_Load(object sender, EventArgs e)
        {

            CargarTextBoxs();
            Observer.agregarObservador(this);
            ListarIdiomas();

        }
        public void CambiarIdioma(Idioma Idioma)
        {
            traducir();
        }

        private void traducir()
        {
            try
            {
                BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
                Idioma Idioma = null;

                Idioma = (Idioma)cbIdioma.SelectedItem; //casteo


                //Ya no lo vuelvo a listar, si la prop es default vuelvo al original
                if (Idioma.Default)
                {
                    VolverAidiomaOriginal();
                }
                else
                {
                    //Obtener traducciones deberia ejecutarse 1 sola vez.. 
                    //Esto seria sesion.idioma y lo busco desde aca..

                    var traducciones = SingletonSesion.instancia.ObtenerTraduccionesPorIdioma(Idioma.Nombre);

                    if (traducciones == null)
                    {
                        // Si no hay traducciones, volver al idioma original sin mostrar error
                        VolverAidiomaOriginal();
                        return;
                    }

                  
                    if (chkMostrarContraseña.Tag != null && traducciones.ContainsKey(chkMostrarContraseña.Tag.ToString()))
                        {
                            this.chkMostrarContraseña.Text = traducciones[chkMostrarContraseña.Tag.ToString()].texto;
                        }
                        if (btnRegistrarse.Tag != null && traducciones.ContainsKey(btnRegistrarse.Tag.ToString()))
                        {
                            this.btnRegistrarse.Text = traducciones[btnRegistrarse.Tag.ToString()].texto;
                        }
                        if (lblIdiomaIS.Tag != null && traducciones.ContainsKey(lblIdiomaIS.Tag.ToString()))
                        {
                            this.lblIdiomaIS.Text = traducciones[lblIdiomaIS.Tag.ToString()].texto;
                        }

                        if (txtUsuario.Tag!=null && traducciones.ContainsKey(txtUsuario.Tag.ToString()))
                        {
                            this.txtUsuario.Text = traducciones[txtUsuario.Tag.ToString()].texto;
                        }

                        if (txtNombre.Tag != null && traducciones.ContainsKey(txtNombre.Tag.ToString()))
                        {
                            this.txtNombre.Text = traducciones[txtNombre.Tag.ToString()].texto;
                        }

                        if (txtApellido.Tag != null && traducciones.ContainsKey(txtApellido.Tag.ToString()))
                        {
                            this.txtApellido.Text = traducciones[txtApellido.Tag.ToString()].texto;
                        }
                        if (txtMail.Tag != null && traducciones.ContainsKey(txtMail.Tag.ToString()))
                        {
                            this.txtMail.Text = traducciones[txtMail.Tag.ToString()].texto;
                        }
                        if (lblFechaNac.Tag != null && traducciones.ContainsKey(lblFechaNac.Tag.ToString()))
                        {
                            this.lblFechaNac.Text = traducciones[lblFechaNac.Tag.ToString()].texto;
                        }
                        if (txtDNI.Tag != null && traducciones.ContainsKey(txtDNI.Tag.ToString()))
                        {
                            this.txtDNI.Text = traducciones[txtDNI.Tag.ToString()].texto;
                        }
                        if (txtClave.Tag != null && traducciones.ContainsKey(txtClave.Tag.ToString()))
                        {
                            this.txtClave.Text = traducciones[txtClave.Tag.ToString()].texto;
                        }
                        if (txtClaveConfirmada.Tag != null && traducciones.ContainsKey(txtClaveConfirmada.Tag.ToString()))
                        {
                            this.txtClaveConfirmada.Text = traducciones[txtClaveConfirmada.Tag.ToString()].texto;
                        }

                }

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
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
                if (txtNombre.Tag != null && palabras.Contains(txtNombre.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(txtNombre.Tag.ToString()));
                    this.txtNombre.Text = traduccion;
                }
                if (txtApellido.Tag != null && palabras.Contains(txtApellido.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(txtApellido.Tag.ToString()));
                    this.txtApellido.Text = traduccion;
                }
                if(txtMail.Tag != null && palabras.Contains(txtMail.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(txtMail.Tag.ToString()));
                    this.txtMail.Text = traduccion;
                }
                if (lblFechaNac.Tag != null && palabras.Contains(lblFechaNac.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(lblFechaNac.Tag.ToString()));
                    this.lblFechaNac.Text = traduccion;
                }
                if (txtDNI.Tag != null && palabras.Contains(txtDNI.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(txtDNI.Tag.ToString()));
                    this.txtDNI.Text = traduccion;
                }
                if (txtClave.Tag != null && palabras.Contains(txtClave.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(txtClave.Tag.ToString()));
                    this.txtClave.Text = traduccion;
                }
                if (txtClaveConfirmada.Tag != null && palabras.Contains(txtClaveConfirmada.Tag.ToString()))
                {
                    string traduccion = palabras.Find(p => p.Equals(txtClaveConfirmada.Tag.ToString()));
                    this.txtClaveConfirmada.Text = traduccion;
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

        private void ListarIdiomas()
        {
            try
            {
                BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
                var ListaIdiomas = Traductor.ObtenerIdiomas();

                /* CORREGIDO, lo traigo de un datasc */

                cbIdioma.DataSource = null;
                cbIdioma.DataSource = ListaIdiomas;

                //AHORA lo seteo x propiedad, en este caso default.

                foreach (Idioma idioma in ListaIdiomas)
                {
                    if (idioma.Default)
                    {
                        cbIdioma.SelectedItem = idioma;
                        break;
                    }
                }
                
                // Aplicar traducciones del idioma seleccionado
                Idioma idiomaActual = (Idioma)cbIdioma.SelectedItem;
                if (idiomaActual != null)
                {
                    SingletonSesion.instancia.idioma = idiomaActual;
                    traducir();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool ValidarCamposVacios()
        {
            bool validacion = false;

            try
            {
                if (txtUsuario.Text.Contains("Ingrese") || txtNombre.Text.Contains("Ingrese") || txtApellido.Text.Contains("apellido") || txtClave.Text.Contains("Ingrese")|| txtMail.Text.Contains("Ingrese") || txtDNI.Text.Contains("Ingrese"))
                {
                  
                    validacion = true;
                    throw new Exception("Debe completar todos los campos");

                }
                if (txtUsuario.Text.Contains("Enter") || txtNombre.Text.Contains("Enter") || txtApellido.Text.Contains("Last") || txtClave.Text.Contains("Enter") || txtMail.Text.Contains("Enter") || txtDNI.Text.Contains("Enter"))
                {

                    validacion = true;
                    throw new Exception("Debe completar todos los campos");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return validacion;
           

        }

        private void OnbtnRegistrarseClick(object sender, EventArgs e)
        {
            BEUsuario oBEUsuario = new BEUsuario();

            try
            {

               if (!ValidarCamposVacios())
                {
                    oBEUsuario.Usuario = txtUsuario.Text;
                    oBEUsuario.Nombre = txtNombre.Text;
                    oBEUsuario.Apellido = txtApellido.Text;
                    oBEUsuario.Mail = txtMail.Text;
                    oBEUsuario.DNI = Convert.ToInt32(txtDNI.Text);

                    if (dtpFechaNac.Value.Date > DateTime.Now)
                    {
                        throw new ArgumentException("La fecha de nacimiento no puede ser superior a la fecha actual, pancho");
                    }

                    var iFecha = DateTime.Now.Year - dtpFechaNac.Value.Date.Year;

                    if (iFecha < 18)
                    {
                        throw new ArgumentException("Menor de 18 años");
                    }
                    
                    oBEUsuario.FechaNac = dtpFechaNac.Value.Date;
                    
                    oBEUsuario.Clave = txtClave.Text;
                    oBEUsuario.Id = 0;

                    if (txtClave.Text != txtClaveConfirmada.Text)
                    {
                        txtClave.BackColor = Color.RosyBrown;
                        txtClaveConfirmada.BackColor = Color.RosyBrown;
                        throw new Exception("Las contraseñas no coinciden.");
                    }
                    else
                    {

                        oBLLUsuario.GuardarConDV(oBEUsuario);
                        AltaExitosa(oBEUsuario);
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

               

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void chkMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrarContraseña.Checked) { txtClave.PasswordChar = '\0'; txtClaveConfirmada.PasswordChar = '\0'; }
            else { txtClave.PasswordChar = '\u2022'; txtClaveConfirmada.PasswordChar = '\u2022'; }
           
        }

        private void CargarTextBoxs()
        {
            
            txtUsuario.ForeColor = Color.Gray;

            txtNombre.ForeColor = Color.Gray;

            txtApellido.ForeColor = Color.Gray;

            txtMail.ForeColor = Color.Gray;

            txtDNI.ForeColor = Color.Gray;

            txtClave.PasswordChar = '\0';
            txtClave.ForeColor = Color.Gray;

            txtClaveConfirmada.PasswordChar = '\0';
            txtClaveConfirmada.ForeColor = Color.Gray;

        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            
            if (txtUsuario.Text == "Ingrese nombre de usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
            if (txtUsuario.Text == "Enter username")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
            
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
      
        {
        
        }


        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Ingrese nombre")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.Black;
            }
            if (txtNombre.Text == "Enter name")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.Black;
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
        }

        private void txtApellido_Enter(object sender, EventArgs e)
        {
            if (txtApellido.Text == "Ingrese su apellido")
            {
                txtApellido.Text = "";
                txtApellido.ForeColor = Color.Black;
            }
            if (txtApellido.Text == "Last name")
            {
                txtApellido.Text = "";
                txtApellido.ForeColor = Color.Black;
            }
        }

        private void txtApellido_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtMail_Enter(object sender, EventArgs e)
        {
            if (txtMail.Text == "Ingrese su mail")
            {
                txtMail.Text = "";
                txtMail.ForeColor = Color.Black;
            }
            if (txtMail.Text == "Enter you email")
            {
                txtMail.Text = "";
                txtMail.ForeColor = Color.Black;
            }
        }

        private void txtMail_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtDNI_Enter(object sender, EventArgs e)
        {
            if (txtDNI.Text == "Ingrese su DNI")
            {
                txtDNI.Text = "";
                txtDNI.ForeColor = Color.Black;
            }
            if (txtDNI.Text == "Enter your ID")
            {
                txtDNI.Text = "";
                txtDNI.ForeColor = Color.Black;
            }
        }

        private void txtDNI_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtClave.Text == "Ingrese una contraseña")
            {
                txtClave.PasswordChar = '\u2022';
                txtClave.Text = "";
                txtClave.ForeColor = Color.Black;
            }
            if (txtClave.Text == "Enter you password")
            {

                txtClave.PasswordChar = '\u2022';
                txtClave.Text = "";
                txtClave.ForeColor = Color.Black;
            }

        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtConfirmarContraseña_Enter(object sender, EventArgs e)
        {
            if (txtClaveConfirmada.Text == "Repita la contraseña")
            {
                txtClaveConfirmada.PasswordChar = '\u2022';
                txtClaveConfirmada.Text = "";
                txtClaveConfirmada.ForeColor = Color.Black;
            }
            if (txtClaveConfirmada.Text == "Repeat your password")
            {

                txtClaveConfirmada.PasswordChar = '\u2022';
                txtClaveConfirmada.Text = "";
                txtClaveConfirmada.ForeColor = Color.Black;
            }
        }

        private void txtConfirmarContraseña_Leave(object sender, EventArgs e)
        {
        }

        private void AltaExitosa(BEUsuario oBEUsuario)
        {
            MessageBox.Show(string.Format("El usuario: '{0}' fue guardado exitosamente.", oBEUsuario.Nombre, MessageBoxButtons.OK));
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

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
