using System;
using System.Collections.Generic;

namespace BE
{
    public class BEUsuario
    {
        #region Propiedades

        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Clave { get; set; }
        public int DNI { get; set; }
        public bool isAdmin { get; set; }
        public DateTime FechaNac { get; set; }
        public string DV { get; set; }

        public BEUsuario()
        {
            _permisos = new List<BEComponente>();
        }

        List<BEComponente> _permisos;

        public List<BEComponente> Permisos
        {
            get
            {
                return _permisos;
            }
        }

        public override string ToString()
        {
            return Nombre;
        }


        #endregion

    }
}
