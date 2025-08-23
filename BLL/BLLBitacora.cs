using DAL;
using SERVICES;
using System;
using System.Data;

namespace BLL
{
    public class BLLBitacora
    {
        DALBitacora oDALBitacora;

        public BLLBitacora()
        {
            oDALBitacora = new DALBitacora();
        }

        public void GuardarBitacora(Bitacora oBitacora)
        {
            oDALBitacora.GuardarBitacora(oBitacora);
        }
        public DataTable BuscarBitacoraPorFiltrosVarios(string sUsuario, DateTime? dtFechaDesde, DateTime? dtFechaHasta, int? TipoBitacoraEnum)
        {
            return oDALBitacora.BuscarBitacoraPorFiltrosVarios(sUsuario, dtFechaDesde, dtFechaHasta, TipoBitacoraEnum);
        }

    }
}
