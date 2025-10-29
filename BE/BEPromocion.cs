using System;

namespace BE
{
    public class BEPromocion
    {
        public int IdPromocion { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public decimal Descuento { get; set; }
        public bool Activo { get; set; }
    }
}
