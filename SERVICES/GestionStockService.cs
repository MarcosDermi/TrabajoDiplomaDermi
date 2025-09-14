using SERVICES.Interfaces;
using System.Data;

namespace SERVICES
{
    public class GestionStockService: IGestionStockService
    {
        public GestionStockService() {
        }
        public DataTable ObtenerProovedores()
        {
            DataTable oDtProveedores = new DataTable();



            return oDtProveedores;
        }
    }
}
