using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEFidelizacionCliente
    {
        public int FidelizacionID { get; set; }
        public int ClienteID { get; set; }
        public int PuntosAcumulados { get; set; }
        public DateTime FechaUltimaActualizacion { get; set; }
    }
}
