using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEHorario
    {
        public DateTime Hora { get; set; }
        public bool Disponible { get; set; }
        public bool Recomendado { get; set; }
        public string Estilista { get; set; }
        public string Servicio { get; set; }
    }
}
