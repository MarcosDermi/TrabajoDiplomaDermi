using BLL;
using SERVICES.Interfaces;
using System.Data;

namespace SERVICES
{
    public class GestionStockService: IGestionStockService
    {
        BLLProveedor oBLLProovedor;

        public GestionStockService() {
            oBLLProovedor = new BLLProveedor();
        }

        
        public void ActualizarStock(int productoId, int cantidad)
        {
            throw new System.NotImplementedException();
        }

        public DataTable ObtenerProveedores()
        {
            return oBLLProovedor.GetAll();
        }

        public DataTable BuscarProveedoresPorFiltrosVarios(string sCodigo, string sNombre, string sRazonSocial)
        {
            return oBLLProovedor.BuscarProveedoresPorFiltrosVarios(sCodigo, sNombre, sRazonSocial);
        }
    }
}
