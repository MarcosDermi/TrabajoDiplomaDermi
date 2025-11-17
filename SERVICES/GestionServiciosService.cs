using ABSTRACCION.Contracts;
using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;

namespace SERVICES
{
    public class GestionServiciosService : IGestionServicioService
    {
        BLLProveedor oBLLProovedor;
        BLLCategorias oBLLCategoria;
        BLLInsumo oBLLInsumo;
        BLLServicios oBLLServicios;

        public GestionServiciosService()
        {
            oBLLProovedor = new BLLProveedor();
            oBLLCategoria = new BLLCategorias();
            oBLLInsumo = new BLLInsumo();
            oBLLServicios = new BLLServicios();
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

        public void GuardarInsumosServicio(BEServicio oBEServicio, List<InsumoSeleccionado> oLstInsumos, List<int> oLstProfesionalesAsignadosIds)
        {
            try
            {
                oBLLServicios.GuardarInsumosServicio(oBEServicio, oLstInsumos, oLstProfesionalesAsignadosIds);
            }
            catch (Exception ex)
            { throw new Exception(); }
            ;
        }

        public BEServicio ObtenerServicio(int ServicioID)
        {
            return oBLLServicios.GetOne(ServicioID);
        }

        public DataTable ObtenerProfesionalServicioPorServicioID(int ServicioID)
        {
            return oBLLServicios.ObtenerProfesionalServicioPorServicioID(ServicioID);
        }

        public DataTable ObtenerServicios()
        {
            return oBLLServicios.ObtenerServicios();
        }

        public bool EliminarServicio(int ServicioID)
        {
            return oBLLServicios.BajaID(ServicioID);
        }
    }
}
