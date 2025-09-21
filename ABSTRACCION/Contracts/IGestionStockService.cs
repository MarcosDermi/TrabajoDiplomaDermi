using System.Data;

namespace SERVICES.Interfaces
{
    public interface IGestionStockService
    {
        DataTable ObtenerProveedores();
        void ActualizarStock(int productoId, int cantidad);
        DataTable BuscarProveedoresPorFiltrosVarios(string sCodigo, string sNombre, string sRazonSocial);
    }
}
