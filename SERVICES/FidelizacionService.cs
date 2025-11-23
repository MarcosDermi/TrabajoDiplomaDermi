using ABSTRACCION.Contracts;
using System.Data;

namespace SERVICES
{
    public class FidelizacionService : IFidelizacionService
    {
        BLLFidelizacion oBLLFidelizacion;

        public FidelizacionService()
        {
            oBLLFidelizacion= new BLLFidelizacion();
        }

        public void ActualizarFidelizacionConClienteID(int ClienteID, string Mail)
        {
            oBLLFidelizacion.ActualizarFidelizacionConClienteID(ClienteID, Mail);
        }

        public DataTable ObtenerDescuentoPendiente(int ClienteID)
        {
            return oBLLFidelizacion.ObtenerDescuentoPendiente(ClienteID);
        }

        public DataTable ObtenerHistorialCanjes(int ClienteID)
        {
            return oBLLFidelizacion.ObtenerHistorialCanjes(ClienteID);
        }

        public DataTable ObtenerPorCliente(int ClienteID, string Mail)
        {
            return oBLLFidelizacion.ObtenerPorCliente(ClienteID, Mail);
        }

        public void RegistrarDescuentoPendiente(int ClienteID, decimal PorcentajeDescuento, int PuntosCanjeados)
        {
            oBLLFidelizacion.RegistrarDescuentoPendiente(ClienteID, PorcentajeDescuento, PuntosCanjeados);
        }
    }
}
