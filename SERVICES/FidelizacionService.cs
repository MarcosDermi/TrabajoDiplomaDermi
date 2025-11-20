using ABSTRACCION.Contracts;
using System;
using BLL;
using System.Data;
using static BE.BEReporte;

namespace SERVICES
{
    public class FidelizacionService : IFidelizacionService
    {
        BLLFidelizacion oBLLFidelizacion;

        public FidelizacionService()
        {
            oBLLFidelizacion= new BLLFidelizacion();
        }

        public DataTable ObtenerDescuentoPendiente(int ClienteID)
        {
            return oBLLFidelizacion.ObtenerDescuentoPendiente(ClienteID);
        }
    }
}
