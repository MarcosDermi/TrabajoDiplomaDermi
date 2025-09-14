
using System.Text.RegularExpressions;


namespace SERVICES
{
    public class Validators
    {
        public Validators() {  }

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
                Regex re = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$");
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

       
    }
}
