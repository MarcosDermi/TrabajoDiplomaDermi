using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEProveedor
    {
        public int IDProveedor { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public string RazonSocial { get; set; }

        public List<BEInsumo> Insumos { get; set; } = new List<BEInsumo>();
    }
}
