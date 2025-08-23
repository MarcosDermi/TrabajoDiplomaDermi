using BE.ClasesMultiLenguaje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace SERVICES
{
    public class SingletonSesion
    {
        private static Sesion _instancia;
        private static Object _lock = new Object();

        static IList<IdiomaObserver> Observadores = new List<IdiomaObserver>();  //creo lista de observadores
       
        public void cambiarIdioma(Idioma idioma)
        {
            instancia.idioma = idioma;
            Observer.cambiarIdioma(idioma);
        }

        public static Sesion instancia
        {
            get
            {
                lock (_lock)
                {
                    if (_instancia == null) _instancia = new Sesion();
                }
                return _instancia;
            }
        }

        public bool IsLoggedIn()
        {
            return _instancia != null;
        }

        bool isInRole(BEComponente oComponente, TipoPermiso enumPermiso, bool bExiste)
        {
            if(oComponente.Permiso.Equals(enumPermiso)) bExiste = true;
            else
            {
                foreach (var oHijos in oComponente.Hijos)
                {
                    bExiste = isInRole(oHijos, enumPermiso, bExiste);
                    if (bExiste) return true;
                }
            }

            return bExiste;
        }

        public bool IsInRole(TipoPermiso enumPermiso)
        {
            bool bExiste = false;
            foreach(var oPermiso in _instancia.Usuario.Permisos)
            {
                if(oPermiso.Permiso.Equals(enumPermiso)) return true;
                else
                {
                    bExiste = isInRole(oPermiso, enumPermiso, bExiste);
                    if (bExiste) return true;
                }
            }

            return bExiste;
        }
    }
}
