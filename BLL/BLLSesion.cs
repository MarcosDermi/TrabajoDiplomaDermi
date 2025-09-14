using ABSTRACCION;
using ABSTRACCION.Contracts;
using BE;
using BE.ClasesMultiLenguaje;
using DAL;
using SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BLL
{
    public class Sesion
    {
        private BEUsuario _Usuario { get; set; }
        public Idioma Idioma { get; set; }

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

        public void CambiarIdioma(Idioma idioma)
        {
            this.Idioma = idioma;
            foreach (var obs in Observadores)
            {
                obs.CambiarIdioma(idioma);
            }
        }

        public bool IsInRole(TipoPermiso permiso)
        {
            foreach (var oPermiso in _Usuario.Permisos)
            {
                if (oPermiso.Permiso.Equals(permiso)) return true;
                if (oPermiso.Hijos != null && oPermiso.Hijos.Any())
                    if (IsInRoleHijos(oPermiso.Hijos, permiso)) return true;
            }
            return false;
        }
        private bool IsInRoleHijos(IEnumerable<BEComponente> hijos, TipoPermiso permiso)
        {
            foreach (var hijo in hijos)
            {
                if (hijo.Permiso.Equals(permiso)) return true;
                if (hijo.Hijos != null && hijo.Hijos.Any())
                    if (IsInRoleHijos(hijo.Hijos, permiso)) return true;
            }
            return false;
        }
    }
}
