using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES
{
    public class Bitacora
    {
        public int ID {  get; set; }

        public string Detalle {  get; set; }

        public BEUsuario UsuarioResponsable { get; set; }

        public DateTime Fecha { get; set; }

        public TipoBitacoraEnum BitacoraEnum { get; set; }

        public Bitacora() { }

        
    }
}
