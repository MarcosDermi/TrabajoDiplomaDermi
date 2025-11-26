using BE;
using System;
using System.Collections.Generic;
using System.Data;

namespace SERVICES.Interfaces
{
    public interface IGestionStockService
    {
        BEInsumo ObtenerInsumo(int InsumoID);
        DataTable ObtenerProveedores(bool EsLista);
        bool GuardarProveedor(BEProveedor oProveedor);
        void ActualizarStock(int productoId, int cantidad);
        DataTable BuscarProveedoresPorFiltrosVarios(string sCodigo, string sNombre, string sRazonSocial);
        List<UnidadesEnum> ObtenerInsumosPresentaciones();
        DataTable ObtenerCategorias(bool EsLista);
        DataTable ObtenerSubcategorias(bool EsLista);
        DataTable ObtenerSubcategoriasPorCategoria(int CategoriaID);
        DataTable OrdenarSubcategoriasPorCategoria(DataTable oDtSubCategoria, string sCategoriaValueMember);
        bool GuardarInsumo(BEInsumo oInsumo);
        DataTable BuscarInsumosPorFiltrosVarios(string sCodigo, string sNombre, int ProveedorID, int CategoriaID, int PresentacionID);
        bool EliminarInsumo(int iInsumoID);
        void ActualizarStockInsumoPorServicioID(List<int> oLstServicioID);
        void EliminarProveedor(int ProveedorID);
        List<int>ObtenerIdsInsumosConStockBajo();
    }
}
