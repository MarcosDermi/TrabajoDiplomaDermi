
using System.Collections.Generic;

namespace BE
{
    public class BEProfesional
    {
        public int ProfesionalID{ get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public List<BEServicio> Servicios { get; set; } = new List<BEServicio>();

    }
}
