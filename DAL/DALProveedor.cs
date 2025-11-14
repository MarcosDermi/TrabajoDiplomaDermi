using ABSTRACCION;
using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALProveedor : IGestor<BEProveedor>
    {
        Datos oDatos;
        Hashtable Hdatos;

        public DALProveedor()
        {
            oDatos = new Datos();
        }

        public bool Guardar(BEProveedor Objeto)
        {
            try
            {
                if (Objeto.IdProveedor != 0)
                {
                    var stpNombreUpdate = "ModificarProveedor";
                    Hdatos = new Hashtable();
                    Hdatos.Add("@ProveedorID", Objeto.IdProveedor);
                    Hdatos.Add("@Codigo", Objeto.Codigo);
                    Hdatos.Add("@Nombre", Objeto.Nombre);
                    Hdatos.Add("@RazonSocial", Objeto.RazonSocial);
                    return oDatos.Escribir(stpNombreUpdate, Hdatos);
                }
                else
                {
                    var stpNombre = "AltaProveedor";
                    Hdatos = new Hashtable();
                    Hdatos.Add("@Codigo", Objeto.Codigo);
                    Hdatos.Add("@Nombre", Objeto.Nombre);
                    Hdatos.Add("@RazonSocial", Objeto.RazonSocial);
                    return oDatos.Escribir(stpNombre, Hdatos);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Baja(BEProveedor Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEProveedor> ListarTodo(bool EsControlCambio, int iIdUsuario)
        {
            throw new NotImplementedException();
        }

        public BEProveedor GetOne(int iId)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            try
            {

                var stpNombre = "GetAllProveedores";
                Hdatos = new Hashtable();
                return oDatos.Leer(stpNombre, Hdatos);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BuscarProveedoresPorFiltrosVarios(string sCodigo, string sNombre, string sRazonSocial)
        {
            try
            {
                var stpNombre = "BuscarProveedoresPorFiltrosVarios";
                Hdatos = new Hashtable();
                Hdatos.Add("@Codigo", sCodigo);
                Hdatos.Add("@Nombre", sNombre);
                Hdatos.Add("@RazonSocial", sRazonSocial);

                return oDatos.Leer(stpNombre, Hdatos);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool BajaID(int iId)
        {
            try
            {
                var stpNombre = "BajaProveedor";
                Hdatos = new Hashtable();
                Hdatos.Add("@ProveedorID", iId);

                return oDatos.Escribir(stpNombre, Hdatos);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
