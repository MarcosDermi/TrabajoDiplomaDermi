
using System;
using System.Data;
using static BE.BEReporte;

namespace ABSTRACCION.Contracts
{
    public interface IFidelizacionService
    {
        DataTable ObtenerDescuentoPendiente(int ClienteID);
    }
}
