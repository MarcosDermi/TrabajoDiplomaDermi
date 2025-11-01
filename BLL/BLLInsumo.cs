using ABSTRACCION;
using BE;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class BLLInsumo : IGestor<BEInsumo>
    {
        DALAgenda oDALAgenda;
        BLLProfesional oBLLProfesional;
        DALServicios oDALServicio;
        DALProfesionalServicio oDALProfesionalServicio;
        DALInsumo oDAlInsumo;

        public BLLInsumo()
        {
            oDALAgenda = new DALAgenda();
            oBLLProfesional = new BLLProfesional();
            oDALServicio = new DALServicios();
            oDALProfesionalServicio = new DALProfesionalServicio();
            oDAlInsumo = new DALInsumo();
        }

        public DataTable GetAll()
        {
            DALInsumo oDALInsumo = new DALInsumo();
            return oDALInsumo.GetAll();
        }

        public bool Guardar(BEInsumo oBEInsumo)
        {
            return oDAlInsumo.Guardar(oBEInsumo);
        }

        public bool Baja(BEInsumo Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEInsumo> ListarTodo(bool EsControlCambio, int iIdUsuario)
        {
            throw new NotImplementedException();
        }

        public BEInsumo GetOne(int iId)
        {
            throw new NotImplementedException();
        }

        public DataTable BuscarInsumosPorFiltrosVarios(string sCodigo, string sNombre, int ProveedorID, int CategoriaID, int PresentacionID)
        {
            return oDAlInsumo.BuscarInsumosPorFiltrosVarios(sCodigo, sNombre, ProveedorID, CategoriaID, PresentacionID);
        }

        public bool BajaID(int iId)
        {
            return oDAlInsumo.BajaID(iId);
        }

        public void ActualizarStockInsumoPorServicioID(List<int> oLstServicioID)
        {
            oDAlInsumo.ActualizarStockInsumoPorServicioID(oLstServicioID);
        }
    }
}
