using ABSTRACCION;
using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALInsumo : IGestor<BEInsumo>
    {
        public DALInsumo()
        {
            oDatos = new Datos();
            hDatos = new Hashtable();
        }

        Datos oDatos;
        Hashtable hDatos;

        public bool ValidarLogin(BEUsuario oUsuario)
        {
            return false;
        }

        public bool Guardar(BEInsumo oBEInsumo)
        {
            oDatos = new Datos();

            if (oBEInsumo.IDInsumo == 0)
            {
                hDatos = new Hashtable();
                hDatos.Add("@InsumoID", oBEInsumo.IDInsumo == 0 ? (object)DBNull.Value : oBEInsumo.IDInsumo);
                hDatos.Add("@Codigo", oBEInsumo.Codigo);
                hDatos.Add("@Nombre", oBEInsumo.Nombre);
                hDatos.Add("@Categoria", oBEInsumo.Categoria.IdCategoria);
                hDatos.Add("@Presentacion", oBEInsumo.Presentacion);
                hDatos.Add("@Descuento", oBEInsumo.Descuento);
                hDatos.Add("@Cantidad", oBEInsumo.Cantidad);
                hDatos.Add("@Stock", oBEInsumo.Stock);
                hDatos.Add("@PrecioCompra", oBEInsumo.PrecioCompra);
                hDatos.Add("@ProveedorID", oBEInsumo.Proveedor.IdProveedor);
                hDatos.Add("@StockMinimo", oBEInsumo.StockMinimo);
                hDatos.Add("@PrecioFinal", oBEInsumo.PrecioFinal);
                hDatos.Add("@FechaVencimiento", oBEInsumo.FechaVencimiento);

            }
            else
            {
                hDatos = new Hashtable();
                hDatos.Add("@InsumoID", oBEInsumo.IDInsumo);
                hDatos.Add("@Codigo", oBEInsumo.Codigo);
                hDatos.Add("@Nombre", oBEInsumo.Nombre);
                hDatos.Add("@Categoria", oBEInsumo.Categoria.IdCategoria);
                hDatos.Add("@Presentacion", oBEInsumo.Presentacion);
                hDatos.Add("@Descuento", oBEInsumo.Descuento);
                hDatos.Add("@Cantidad", oBEInsumo.Cantidad);
                hDatos.Add("@Stock", oBEInsumo.Stock);
                hDatos.Add("@ProveedorID", oBEInsumo.Proveedor.IdProveedor);
                hDatos.Add("@StockMinimo", oBEInsumo.StockMinimo);
                hDatos.Add("@PrecioFinal", oBEInsumo.PrecioFinal);
                hDatos.Add("@PrecioCompra", oBEInsumo.PrecioCompra);
                hDatos.Add("@FechaVencimiento", oBEInsumo.FechaVencimiento);
            }

            return oDatos.Escribir("GuardarInsumo", hDatos);
        }

        public bool Baja(BEInsumo oBEInsumo)
        {
            throw new NotImplementedException();
        }

        List<BEInsumo> IGestor<BEInsumo>.ListarTodo(bool EsControlCambio, int iIdUsuario)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            throw new NotImplementedException();
        }

        public BEInsumo GetOne(int iId)
        {
            try
            {
                hDatos = new Hashtable();
                hDatos.Add("@InsumoID", iId);

                DataTable oDt = oDatos.Leer("Insumo_S_PorID", hDatos);

                var oBEInsumo = new BEInsumo();

                foreach (DataRow oDr in oDt.AsEnumerable())
                {
                    oBEInsumo.IDInsumo = Convert.ToInt32(oDr["InsumoID"]);
                    oBEInsumo.Codigo = oDr["Codigo"].ToString();
                    oBEInsumo.Nombre = oDr["Nombre"].ToString();
                    oBEInsumo.Presentacion = (UnidadesEnum)oDr["Presentacion"];
                    oBEInsumo.PrecioCompra = Convert.ToDecimal(oDr["PrecioCompra"]);
                    oBEInsumo.Descuento = Convert.ToDecimal(oDr["Descuento"]);
                    oBEInsumo.Cantidad = Convert.ToDecimal(oDr["Cantidad"]);
                    oBEInsumo.Proveedor.IdProveedor = Convert.ToInt32(oDr["ProveedorID"]);
                    oBEInsumo.PrecioFinal = Convert.ToDecimal(oDr["PrecioFinal"]);
                    oBEInsumo.FechaVencimiento = Convert.ToDateTime(oDr["FechaVencimiento"]);
                    oBEInsumo.Categoria.IdCategoria = Convert.ToInt32(oDr["CategoriaID"]);
                    oBEInsumo.Categoria.IdCategoriaPadre = Convert.ToInt32(oDr["CategoriaPadreID"]);
                    oBEInsumo.Stock = Convert.ToDecimal(oDr["Stock"]);
                    oBEInsumo.StockMinimo = Convert.ToDecimal(oDr["StockMinimo"]);
                }

                return oBEInsumo;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public DataTable BuscarInsumosPorFiltrosVarios(string sCodigo, string sNombre, int ProveedorID, int CategoriaID, int PresentacionID)
        {
            hDatos = new Hashtable();
            hDatos.Add("@Codigo", string.IsNullOrWhiteSpace(sCodigo) ? (object)DBNull.Value : sCodigo);
            hDatos.Add("@Nombre", string.IsNullOrWhiteSpace(sNombre) ? (object)DBNull.Value : sNombre);
            hDatos.Add("@ProveedorID", ProveedorID == 0 ? (object)DBNull.Value : ProveedorID);
            hDatos.Add("@CategoriaID", CategoriaID == 0 ? (object)DBNull.Value : CategoriaID);
            hDatos.Add("@PresentacionID", PresentacionID == 0 ? (object)DBNull.Value : PresentacionID);

            return oDatos.Leer("BuscarInsumosPorFiltrosVarios", hDatos);
        }

        public bool BajaID(int iId)
        {
            oDatos = new Datos();

            if (iId != 0)
            {
                hDatos = new Hashtable();
                hDatos.Add("InsumoID", iId);

                return oDatos.Escribir("BajaInsumo", hDatos);
            }
            else
            {
                return false;
            }
        }

        public void ActualizarStockInsumoPorServicioID(List<int> oLstServicioID)
        {
            try
            {
                foreach (var idServicio in oLstServicioID)
                {
                    oDatos.Escribir("ActualizarStockPorServicioID", new Hashtable
                    {
                        { "@ServicioID", idServicio }
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
