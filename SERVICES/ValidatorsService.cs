
using ABSTRACCION.Contracts;
using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace SERVICES
{
    public class ValidatorsService: IValidatorsService
    {
        public ValidatorsService() {  }

        #region Regexs

        public bool PassValidator(string Contraseña)
        {
            return true;
        }

        public bool validarPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }
            else
            {
                Regex re = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$");
                if (re.IsMatch(password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public  bool validarUsuario(string user)
        {
            return Regex.IsMatch(user, @"^[A-Za-z]+$|^[A-Za-z0-9]+$");
            //suponeindo que un usuario pueda contener caracteres solo letras y numeros, ejemplo JoeDamerdjian28 o JoeDamerdjian simpple
        }

        public bool validarMail(string mail)
        {
            return Regex.IsMatch(mail, @"^[A-Za-z0-9.]+@[A-Za-z0-9.]+$");
            //ej, joel.marcos@libra.com ,   joel28@dominio.com 

        }

        public bool validarNombreOApellido(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return false;
            }
            else
            {
                Regex re = new Regex(@"^[a-zA-Z]+(?:\\s[a-zA-Z]+){0,2}$");
                if (re.IsMatch(nombre))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool validarPalabra(string palabra)
        {
            if (string.IsNullOrEmpty(palabra))
            {
                return false;
            }
            else
            {
                Regex re = new Regex(@"^([A-Za-zÑñÁáÉéÍíÓóÚú]+['\-]{0,1}[A-Za-zÑñÁáÉéÍíÓóÚú]+)$");
                if (re.IsMatch(palabra))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool validarDni(string dni)
        {
            if (string.IsNullOrEmpty(dni))
            {
                return false;
            }
            else
            {
                Regex re = new Regex(@"^\d{7,8}$");
                if (re.IsMatch(dni))
                {
                    return true;
                }
                else
                {
                    return false;
                   
                }
            }
        }

        #endregion

        public bool ValidarCamposVacios(string NombreUsuario, string Clave)
        {
            bool validacion = false;

            if (NombreUsuario.Contains("Ingrese") || Clave.Contains("Ingrese")) validacion = true;
      
            return validacion;
        }

        public bool ValidarCamposVaciosModificar(string id,string nombre,string apellido,string usuario,string dni,string mail)
        {
            bool validacion = false;

            if (id==string.Empty || nombre.Contains("Ingrese") || apellido.Contains("Ingrese") || usuario.Contains("Ingrese") || dni.Contains("Ingrese") || mail.Contains("Ingrese")) validacion = true;


            return validacion;
        }

        public bool validarTelefono(string telefono)
        {
            throw new NotImplementedException();
        }

        public bool validarPrecio(string precio)
        {
            throw new NotImplementedException();
        }

        public bool validarDuracion(string duracion)
        {
            throw new NotImplementedException();
        }

        public bool validarBuffer(string buffer)
        {
            throw new NotImplementedException();
        }

        public bool validarDescripcion(string descripcion)
        {
            throw new NotImplementedException();
        }

        public bool validarComboBox(ComboBox combo)
        {
            throw new NotImplementedException();
        }

        public bool validarDataGridView(DataGridView dgv)
        {
            throw new NotImplementedException();
        }

        public bool validarListaServicios(IList<BEServicio> lista)
        {
            throw new NotImplementedException();
        }

        public bool validarFechaHora(DateTime fechaHora)
        {
            throw new NotImplementedException();
        }

        public bool validarDataTable(DataTable dt)
        {
            throw new NotImplementedException();
        }

        public bool validarEntero(string entero)
        {
            throw new NotImplementedException();
        }

        public bool validarDecimal(string decimalString)
        {
            decimal valor;
            return decimal.TryParse(
                decimalString,
                System.Globalization.NumberStyles.Number,
                System.Globalization.CultureInfo.CurrentCulture,
                out valor
            );
        }

        public bool validarTexto(string texto)
        {
            throw new NotImplementedException();
        }

        public bool validarListaString(IList<string> lista)
        {
            throw new NotImplementedException();
        }

        public bool validarListaEnteros(IList<int> lista)
        {
            throw new NotImplementedException();
        }

        public bool validarListaProfesionales(IList<BEProfesional> lista)
        {
            throw new NotImplementedException();
        }

        public bool validarListaServiciosCheckedListBox(CheckedListBox clb)
        {
            throw new NotImplementedException();
        }

        public bool validarListaProfesionalesCheckedListBox(CheckedListBox clb)
        {
            throw new NotImplementedException();
        }

        public bool validarListaStringCheckedListBox(CheckedListBox clb)
        {
            throw new NotImplementedException();
        }

        public bool validarListaEnterosCheckedListBox(CheckedListBox clb)
        {
            throw new NotImplementedException();
        }
    }
}
