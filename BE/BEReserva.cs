using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEReserva
    {
        public int ReservaID { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public BEUsuario Cliente { get; set; }
        public int ProfesionalID { get; set; }
        public int MedioDePagoID { get; set; }
        public List<BEServicio> Servicios { get; set; }
        public decimal PrecioTotal { get; set; }
    }

    public enum ReservaAcciones
    {
        Confirmada = 1,
        Atendida = 2,
        Cancelada = 3
    }
}
