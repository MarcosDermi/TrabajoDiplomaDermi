using BE;
using BLL;
using SERVICES.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Remoting.Messaging;

namespace SERVICES
{
    public class GestionStockService : IGestionStockService
    {
        BLLProveedor oBLLProovedor;
        BLLCategorias oBLLCategoria;
        BLLInsumo oBLLInsumo;

        public GestionStockService()
        {
            oBLLProovedor = new BLLProveedor();
            oBLLCategoria = new BLLCategorias();
            oBLLInsumo = new BLLInsumo();
        }


        public void ActualizarStock(int productoId, int cantidad)
        {
            throw new System.NotImplementedException();
        }

        public DataTable ObtenerProveedores(bool EsLista)
        {
            var oDt = oBLLProovedor.GetAll();

            if (!EsLista) return oDt;

            DataTable oDtLista = new DataTable();
            oDtLista.Columns.Add("ProveedorID", typeof(int));
            oDtLista.Columns.Add("RazonSocial", typeof(string));

            foreach (DataRow row in oDt.Rows)
            {
                DataRow newRow = oDtLista.NewRow();
                newRow["ProveedorID"] = row["ProveedorID"];
                newRow["RazonSocial"] = row["RazonSocial"];
                oDtLista.Rows.Add(newRow);
            }
            return oDtLista;
        }

        public DataTable BuscarProveedoresPorFiltrosVarios(string sCodigo, string sNombre, string sRazonSocial)
        {
            return oBLLProovedor.BuscarProveedoresPorFiltrosVarios(sCodigo, sNombre, sRazonSocial);
        }

        public List<UnidadesEnum> ObtenerInsumosPresentaciones()
        {
            var oLst = new List<UnidadesEnum>();

            foreach (UnidadesEnum item in System.Enum.GetValues(typeof(UnidadesEnum)))
            {
                oLst.Add(item);
            }

            return oLst;
        }

        public DataTable ObtenerCategorias(bool EsLista)
        {
            var oDt = oBLLCategoria.ObtenerCategorias();

            if (!EsLista) return oDt;

            DataTable oDtLista = new DataTable();
            oDtLista.Columns.Add("CategoriaID", typeof(int));
            oDtLista.Columns.Add("Nombre", typeof(string));

            foreach (DataRow row in oDt.Rows)
            {
                DataRow newRow = oDtLista.NewRow();
                newRow["CategoriaID"] = row["CategoriaID"];
                newRow["Nombre"] = row["Nombre"];
                oDtLista.Rows.Add(newRow);
            }
            return oDtLista;
        }

        public DataTable ObtenerSubcategorias(bool EsLista)
        {
            var oDt = oBLLCategoria.ObtenerSubcategorias();

            if (!EsLista) return oDt;

            DataTable oDtLista = new DataTable();
            oDtLista.Columns.Add("CategoriaID", typeof(int));
            oDtLista.Columns.Add("Nombre", typeof(string));
            oDtLista.Columns.Add("CategoriaPadreID", typeof(int));

            foreach (DataRow row in oDt.Rows)
            {
                DataRow newRow = oDtLista.NewRow();
                newRow["CategoriaID"] = row["CategoriaID"];
                newRow["Nombre"] = row["Nombre"];
                newRow["CategoriaPadreID"] = row["CategoriaPadreID"];
                oDtLista.Rows.Add(newRow);
            }
            return oDtLista;
        }

        public DataTable ObtenerSubcategoriasPorCategoria(int CategoriaID)
        {
            return oBLLCategoria.ObtenerSubcategoriasPorCategoria(CategoriaID);
        }

        public DataTable OrdenarSubcategoriasPorCategoria(DataTable oDtSubCategoria, string sCategoriaValueMember)
        {
            var oDtResultado = oDtSubCategoria.Clone();

            foreach (DataRow row in oDtSubCategoria.Rows)
            {
                if (row["CategoriaPadreID"].ToString() == sCategoriaValueMember)
                {
                    DataRow newRow = oDtResultado.NewRow();
                    newRow["CategoriaID"] = row["CategoriaID"];
                    newRow["SubcategoriaNombre"] = row["SubcategoriaNombre"];
                    newRow["CategoriaPadreID"] = row["CategoriaPadreID"];
                    oDtResultado.Rows.Add(newRow);
                }
            }

            return oDtResultado;
        }

        public bool GuardarInsumo(BEInsumo oInsumo)
        {
            return oBLLInsumo.Guardar(oInsumo);
        }

        public DataTable BuscarInsumosPorFiltrosVarios(string sCodigo, string sNombre, int ProveedorID, int CategoriaID, int PresentacionID)
        {
            var oDt = oBLLInsumo.BuscarInsumosPorFiltrosVarios(sCodigo, sNombre, ProveedorID, CategoriaID, PresentacionID);

            oDt.Columns.Add("Presentacion", typeof(string));

            foreach (var oDr in oDt.AsEnumerable())
            {
                var iPresentacionID = (int)oDr["PresentacionID"];

                var sUnidad = iPresentacionID == (int)UnidadesEnum.cajas ? UnidadesEnum.cajas.ToString() :
                 iPresentacionID == (int)UnidadesEnum.gr ? UnidadesEnum.gr.ToString() :
                 iPresentacionID == (int)UnidadesEnum.ml ? UnidadesEnum.ml.ToString() :
                 UnidadesEnum.unidades.ToString();

                oDr["Presentacion"] = sUnidad;
            }

            oDt.Columns.Remove("PresentacionID");
            oDt.Columns["CategoriaNombre"].ColumnName = "Categoria";
            oDt.Columns["ProveedorRazonSocial"].ColumnName = "Proveedor";

            return oDt;
        }

        public bool EliminarInsumo(int iInsumoID)
        {
            return oBLLInsumo.BajaID(iInsumoID);
        }

        public void ActualizarStockInsumoPorServicioID(List<int> oLstServicioID)
        {
            oBLLInsumo.ActualizarStockInsumoPorServicioID(oLstServicioID);
        }

        public BEInsumo ObtenerInsumo(int InsumoID)
        {
           return oBLLInsumo.GetOne(InsumoID);
        }
    }
}
