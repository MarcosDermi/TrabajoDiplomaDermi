using BE;
using System;
using System.Collections;
using System.Data;

namespace DAL
{
    public class DALPromocion
    {
        Datos oDatos;
        Hashtable Hdatos;

        public DALPromocion()
        {
            oDatos = new Datos();
        }

        public void GuardarPromocion(BEPromocion oBEPromocion)
        {
            try
            {
                Hdatos = new Hashtable();
                Hdatos.Add("@IdPromocion", oBEPromocion.IdPromocion);
                Hdatos.Add("@Nombre", oBEPromocion.Nombre);
                Hdatos.Add("@FechaDesde", oBEPromocion.FechaDesde);
                Hdatos.Add("@FechaHasta", oBEPromocion.FechaHasta);
                Hdatos.Add("@Descuento", oBEPromocion.Descuento);
                Hdatos.Add("@Activo", oBEPromocion.Activo);

                oDatos.Escribir("GuardarPromocion", Hdatos);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable BuscarPromocionesPorFiltrosVarios(string sNombre, DateTime FechaDesde, DateTime FechaHasta, bool IncluirInactivos)
        {
            try
            {
                Hdatos = new Hashtable();
                Hdatos.Add("@Nombre", sNombre);
                Hdatos.Add("@FechaDesde", FechaDesde);
                Hdatos.Add("@FechaHasta", FechaHasta);
                Hdatos.Add("@IncluirInactivas", IncluirInactivos);
                return oDatos.Leer("stpPromocion_S_Listado_X_Filtros", Hdatos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
