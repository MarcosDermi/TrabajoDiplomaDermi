using ABSTRACCION.Contracts;
using BE;
using BE.ClasesMultiLenguaje;
using System.Collections.Generic;

namespace BLL
{
    public class BLLSingletonSesion : ISingletonSesionService
    {
        private static Sesion _instancia;
        private static readonly object _lock = new object();

        public static BLLSingletonSesion Instancia { get; } = new BLLSingletonSesion();

        private BLLSingletonSesion() { }

        private Sesion SesionInterna
        {
            get
            {
                lock (_lock)
                {
                    if (_instancia == null) _instancia = new Sesion();
                    return _instancia;
                }
            }
        }

        public void Login(BEUsuario usuario) => SesionInterna.Login(usuario);
        public void Logout() => SesionInterna.Logout();
        public bool IsLoggedIn() => SesionInterna.IsLogged();
        public BEUsuario Usuario => SesionInterna.Usuario;
        public void CambiarIdioma(Idioma idioma) => SesionInterna.CambiarIdioma(idioma);
        public bool IsInRole(TipoPermiso permiso) => SesionInterna.IsInRole(permiso);
        public void AgregarTraduccionesIdioma(string nombreIdioma, Dictionary<string, Traduccion> traducciones) => SesionInterna.AgregarTraduccionesIdioma(nombreIdioma, traducciones);
        public Dictionary<string, Traduccion> ObtenerTraduccionesPorIdioma(string nombreIdioma) => SesionInterna.ObtenerTraduccionesPorIdioma(nombreIdioma);
    }
}
