using ABSTRACCION.Contracts;
using BE;
using BLL;
using SERVICES.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Remoting.Messaging;

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
            { throw new Exception(); };
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
    }
}
