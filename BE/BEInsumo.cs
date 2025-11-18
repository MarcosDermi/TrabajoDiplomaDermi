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
        public BECategoria Categoria { get; set; } = new BECategoria();
        public UnidadesEnum Presentacion { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal Descuento { get; set; }
        public decimal PrecioFinal { get; set; }
        public BEProveedor Proveedor { get; set; } = new BEProveedor();
        public decimal Stock { get; set; }
        public decimal StockMinimo { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }

    public enum UnidadesEnum
    {
        ml = 1,
        gr = 2,
        cajas = 3,
        unidades = 4
    }

    public class InsumoSeleccionado
    {
        public int InsumoID { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal CantidadStock { get; set; }
        public decimal CantidadUsar { get; set; }
    }
}
