using BE;
using BE.ClasesMultiLenguaje;
using System.Collections.Generic;


namespace SERVICES
{
    public class Sesion
    {
        private BEUsuario _Usuario { get; set; } 
        public Idioma idioma { get; set; }

        static IList<IdiomaObserver> Observadores = new List<IdiomaObserver>();  //creo lista de observadores

        public Dictionary<string, Dictionary<string, Traduccion>> traduccionesPorIdioma { get; private set; }

        // Método para agregar traducciones para un idioma si no existen


        public Sesion()
        {
           traduccionesPorIdioma = new Dictionary<string, Dictionary<string, Traduccion>>();
        }
        public void AgregarTraduccionesIdioma(string nombreIdioma, Dictionary<string, Traduccion> traducciones)
        {
            if (!traduccionesPorIdioma.ContainsKey(nombreIdioma))
            {
                traduccionesPorIdioma.Add(nombreIdioma, traducciones);
            }
            // Si querés actualizar traducciones existentes, agregar lógica acá
        }

        // Método para obtener traducciones de un idioma
        public Dictionary<string, Traduccion> ObtenerTraduccionesPorIdioma(string nombreIdioma)
        {
            if (traduccionesPorIdioma.ContainsKey(nombreIdioma))
                return traduccionesPorIdioma[nombreIdioma];
            return null;
        }


        public BEUsuario Usuario
        {
            get
            {
                return _Usuario;
            }
        }

        public void Login(BEUsuario usuario)
        {
            _Usuario = usuario;
        }

        public void Logout()
        {
            _Usuario = null;
        }

        public bool IsLogged()
        {
            return _Usuario != null;
        }
    }
}
