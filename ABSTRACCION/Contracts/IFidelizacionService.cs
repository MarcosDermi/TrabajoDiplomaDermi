
using BE;
using System;
using System.Data;
using static BE.BEReporte;

namespace ABSTRACCION.Contracts
{
    public interface IFidelizacionService
    {
        DataTable ObtenerDescuentoPendiente(int ClienteID);

        DataTable ObtenerPorCliente(int ClienteID, string Mail);

        void ActualizarFidelizacionConClienteID(int ClienteID, string Mail);

        DataTable ObtenerHistorialCanjes(int ClienteID);

        void RegistrarDescuentoPendiente(int ClienteID, decimal PorcentajeDescuento, int PuntosCanjeados);
    }
}
