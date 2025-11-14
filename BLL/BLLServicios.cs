using ABSTRACCION;
using BE;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class BLLServicios : IGestor<BEServicio>
    {
        DALAgenda oDALAgenda;
        BLLProfesional oBLLProfesional;
        DALServicios oDALServicio;
        DALProfesionalServicio oDALProfesionalServicio;
        DALInsumo oDAlInsumo;

        public BLLServicios()
        {
            oDALAgenda = new DALAgenda();
            oBLLProfesional = new BLLProfesional();
            oDALServicio = new DALServicios();
            oDALProfesionalServicio = new DALProfesionalServicio();
            oDAlInsumo = new DALInsumo();
        }

        public bool Baja(BEServicio Objeto)
        {
            throw new NotImplementedException();
        }

        public bool BajaID(int iId)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            DALInsumo oDALInsumo = new DALInsumo();
            return oDALInsumo.GetAll();
        }

        public BEServicio GetOne(int iId)
        {
            return oDALServicio.ObtenerServicio(iId);
        }

        public bool Guardar(BEServicio Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEServicio> ListarTodo(bool EsControlCambio, int iIdUsuario)
        {
            throw new NotImplementedException();
        }

        public DataTable ObtenerServiciosPorProfesional(int ProfesionalID)
        {
            return oDALServicio.ObtenerServiciosPorProfesional(ProfesionalID);
        }

        public DataTable ObtenerObtenerInsumosPorServicio(int ServicioID)
        {
            return oDALServicio.ObtenerObtenerInsumosPorServicio(ServicioID);
        }

        public DataTable ObtenerProfesionalServicioPorServicioID(int ServicioID)
        {
            return oDALServicio.ObtenerProfesionalServicioPorServicioID(ServicioID);
        }

        public void GuardarInsumosServicio(BEServicio oBEServicio, List<InsumoSeleccionado> oLstInsumos, List<BEProfesional> oLstProfesionales)
        {
            oDALServicio.GuardarInsumosServicio(oBEServicio, oLstInsumos, oLstProfesionales);
        }
    }
}
