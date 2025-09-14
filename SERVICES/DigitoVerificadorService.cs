using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using BE;
using ABSTRACCION.Contracts;

namespace SERVICES
{
    public class DigitoVerificadorService: IDigitoVerificadorService
    {
        public string CalcularDVUsuario(BEUsuario usuario)
        {
            if (usuario == null) return string.Empty;

            Type tipoUsuario = usuario.GetType();
            string dvUsuario = string.Empty;
            var propiedades = tipoUsuario.GetProperties();

            foreach (var propiedad in propiedades)
            {
                if (propiedad.Name != "DV" && propiedad.Name != "Permisos" && propiedad.Name != "Id")
                {
                    var valor = propiedad.GetValue(usuario);
                    if (valor != null)
                    {
                        if (propiedad.PropertyType == typeof(DateTime))
                        {
                            DateTime fecha = (DateTime)valor;
                            dvUsuario += fecha.ToString("ddMMyyyyHHmmss");
                        }
                        else
                        {
                            dvUsuario += valor.ToString();
                        }
                    }
                }
            }

            return GenerarSHA(dvUsuario);
        }

        public string GenerarSHA(string cadena)
        {
            UnicodeEncoding ueCodigo = new UnicodeEncoding();
            byte[] ByteSourceText = ueCodigo.GetBytes(cadena);
            SHA1CryptoServiceProvider SHA = new SHA1CryptoServiceProvider();
            byte[] ByteHash = SHA.ComputeHash(ueCodigo.GetBytes(cadena));
            return Convert.ToBase64String(ByteHash);
        }

        public string CalcularDVSistema(List<BEUsuario> usuarios)
        {
            if (usuarios == null || usuarios.Count == 0)
                return string.Empty;

            List<string> dvsUsuarios = new List<string>();
            
            foreach (var usuario in usuarios)
            {
                dvsUsuarios.Add(CalcularDVUsuario(usuario));
            }

            return GenerarSHA(string.Join("", dvsUsuarios));
        }

       
    }
} 