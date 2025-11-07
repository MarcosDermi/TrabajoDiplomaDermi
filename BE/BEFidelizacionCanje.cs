using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEFidelizacionCanje
    {
        public int CanjeID { get; set; }
        public int ClienteID { get; set; }
        public string Recompensa { get; set; }
        public int PuntosUsados { get; set; }
        public DateTime FechaCanje { get; set; }
    }
}
