
using ABSTRACCION.Contracts;
using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        // ---------------------------
        // CAMPOS DE TEXTO BÁSICOS
        // ---------------------------

        public bool validarTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                return false;

            // Solo números, espacios, guiones y paréntesis, entre 7 y 15 dígitos
            return Regex.IsMatch(telefono, @"^[0-9\s\-\(\)]{7,15}$");
        }

        public bool validarPrecio(string precio)
        {
            if (string.IsNullOrWhiteSpace(precio))
                return false;

            // Admite coma o punto decimal
            return decimal.TryParse(
                precio,
                System.Globalization.NumberStyles.AllowDecimalPoint,
                System.Globalization.CultureInfo.InvariantCulture,
                out decimal valor
            ) && valor >= 0;
        }

        public bool validarDuracion(string duracion)
        {
            if (string.IsNullOrWhiteSpace(duracion))
                return false;

            // Acepta números enteros (minutos)
            return int.TryParse(duracion, out int minutos) && minutos > 0 && minutos <= 600;
        }

        public bool validarBuffer(string buffer)
        {
            if (string.IsNullOrWhiteSpace(buffer))
                return false;

            return int.TryParse(buffer, out int valor) && valor >= 0 && valor <= 120;
        }

        public bool validarDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                return false;

            // Evita descripciones muy cortas o extremadamente largas
            return descripcion.Length >= 3 && descripcion.Length <= 500;
        }

        public bool validarTexto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return false;

            // Solo letras, espacios y algunos acentos comunes
            return Regex.IsMatch(texto, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$");
        }

        public bool validarEntero(string entero)
        {
            return int.TryParse(entero, out int valor);
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

        // ---------------------------
        // VALIDACIONES DE FECHA / HORA
        // ---------------------------

        public bool validarFechaHora(DateTime fechaHora)
        {
            // Debe ser mayor o igual a la fecha actual
            return fechaHora >= DateTime.Now;
        }

        // ---------------------------
        // VALIDACIONES DE CONTROLES
        // ---------------------------

        public bool validarComboBox(ComboBox combo)
        {
            // Debe tener un elemento seleccionado
            return combo != null && combo.SelectedIndex >= 0;
        }

        public bool validarDataGridView(DataGridView dgv)
        {
            // Debe contener al menos una fila válida
            return dgv != null && dgv.Rows.Count > 0;
        }

        public bool validarCheckedListBox(CheckedListBox clb)
        {
            // Al menos un elemento debe estar seleccionado
            return clb != null && clb.CheckedItems.Count > 0;
        }

        // ---------------------------
        // VALIDACIONES DE LISTAS
        // ---------------------------

        public bool validarListaServicios(IList<BEServicio> lista)
        {
            return lista != null && lista.Any();
        }

        public bool validarListaString(IList<string> lista)
        {
            return lista != null && lista.Any(x => !string.IsNullOrWhiteSpace(x));
        }

        public bool validarListaEnteros(IList<int> lista)
        {
            return lista != null && lista.Any();
        }

        public bool validarListaProfesionales(IList<BEProfesional> lista)
        {
            return lista != null && lista.Any();
        }

        public bool validarDataTable(DataTable dt)
        {
            return dt != null && dt.Rows.Count > 0;
        }

        // ---------------------------
        // CHECKED LIST BOX ESPECÍFICOS
        // ---------------------------

        public bool validarListaServiciosCheckedListBox(CheckedListBox clb)
        {
            return validarCheckedListBox(clb);
        }

        public bool validarListaProfesionalesCheckedListBox(CheckedListBox clb)
        {
            return validarCheckedListBox(clb);
        }

        public bool validarListaStringCheckedListBox(CheckedListBox clb)
        {
            return validarCheckedListBox(clb);
        }

        public bool validarListaEnterosCheckedListBox(CheckedListBox clb)
        {
            return validarCheckedListBox(clb);
        }
    }
}
