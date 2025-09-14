using BE;
using BE.ClasesMultiLenguaje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSTRACCION.Contracts
{
    public interface ISingletonSesionService
    {
        void Login(BEUsuario usuario);
        void Logout();
        bool IsLoggedIn();
        BEUsuario Usuario { get; }
        void CambiarIdioma(Idioma idioma);
        bool IsInRole(TipoPermiso permiso);
        void AgregarTraduccionesIdioma(string nombreIdioma, Dictionary<string, Traduccion> traducciones);
        Dictionary<string, Traduccion> ObtenerTraduccionesPorIdioma(string nombreIdioma);
    }
}
