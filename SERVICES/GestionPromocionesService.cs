using ABSTRACCION.Contracts;
using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;

namespace SERVICES
{
    public class GestionPromocionesService : IGestionPromocionesService
    {
        BLLProveedor oBLLProovedor;
        BLLCategorias oBLLCategoria;
        BLLInsumo oBLLInsumo;
        BLLServicios oBLLServicios;
        BLLPromocion oBLLPromocion;

        public GestionPromocionesService()
        {
            oBLLProovedor = new BLLProveedor();
            oBLLCategoria = new BLLCategorias();
            oBLLInsumo = new BLLInsumo();
            oBLLServicios = new BLLServicios();
            oBLLPromocion = new BLLPromocion();
        }

        public DataTable ObtenerServiciosPorProfesional(int ProfesionalID)
        {
            try
            {
                return oBLLServicios.ObtenerServiciosPorProfesional(ProfesionalID);
            }
            catch (Exception ex)
            { throw new Exception(); }
            ;
        }

        public DataTable ObtenerObtenerInsumosPorServicio(int ServicioID)
        {
            try
            {
                return oBLLServicios.ObtenerObtenerInsumosPorServicio(ServicioID);
            }
            catch (Exception ex)
            { throw new Exception(); }
            ;
        }

        public void GuardarPromocion(BEPromocion oBEPromocion)
        {
            try
            {
                oBLLPromocion.GuardarPromocion(oBEPromocion);
            }
            catch (Exception ex)
            { throw new Exception(); }
            ;
        }

        public DataTable BuscarPromocionesPorFiltrosVarios(string sNombre, DateTime FechaDesde, DateTime FechaHasta, bool IncluirInactivos)
        {
            try
            {
                return oBLLPromocion.BuscarPromocionesPorFiltrosVarios(sNombre, FechaDesde, FechaHasta, IncluirInactivos);
            }
            catch (Exception ex)
            { throw new Exception(); }
            ;
        }

        public void EliminarPromocion(int PromocionID)
        {
            oBLLPromocion.EliminarPromocion(PromocionID);
        }

        public bool VerificarPromocionVigenteParaFecha(DateTime dtReservaFechaInicio)
        {
            return oBLLPromocion.HayPromocionEnFecha(dtReservaFechaInicio);
        }

        public DataTable ObtenerPromocionesActivas()
        {
            return oBLLPromocion.ObtenerPromocionesActivas();
        }
    }
}
