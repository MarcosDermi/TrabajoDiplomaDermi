using BE;
using System;
using System.Collections.Generic;
using System.Data;

namespace SERVICES.Interfaces
{
    public interface IGestionStockService
    {
        DataTable ObtenerProveedores(bool EsLista);
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
    }
}
