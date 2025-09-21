using ABSTRACCION;
using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Interfaces
{
    public interface IGestionStockService
    {
        DataTable ObtenerProveedores();
        void ActualizarStock(int productoId, int cantidad);
        DataTable BuscarProveedoresPorFiltrosVarios(string sCodigo, string sNombre, string sRazonSocial);
    }
}
