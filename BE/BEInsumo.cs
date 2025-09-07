using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEInsumo
    {
        public int IDInsumo { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public string Categoria { get; set; }

        public UnidadesEnum Presentacion { get; set; }

        public decimal PrecioCompra { get; set; }

        public decimal Descuento { get; set; }

        public decimal Cantidad { get; set; }

        public BEProveedor Proveedor { get; set; } = new BEProveedor();

        public decimal Stock { get; set; }

        public decimal StockMinimno { get; set; }

        public byte[] Imagen {  get; set; }
    }

    public enum UnidadesEnum
    {
        ml = 1,
        gr = 2,
        cajas = 3,
        unidades = 4
    }
}
