using BE;
using DAL;
using System;
using System.Data;

namespace BLL
{
    public class BLLPromocion
    {
        DALPromocion oDALPromocion;

        public BLLPromocion()
        {
            oDALPromocion = new DALPromocion();
        }

        public void GuardarPromocion(BEPromocion oBEPromocion)
        {
            try
            {
                oDALPromocion.GuardarPromocion(oBEPromocion);
            }
            catch (Exception ex)
            { throw new Exception(); }
            ;
        }

        public DataTable BuscarPromocionesPorFiltrosVarios(string sNombre, DateTime FechaDesde, DateTime FechaHasta, bool IncluirInactivos)
        {
            try
            {
                return oDALPromocion.BuscarPromocionesPorFiltrosVarios(sNombre, FechaDesde, FechaHasta, IncluirInactivos);
            }
            catch (Exception ex)
            { throw new Exception(); }
            ;
        }

        public void EliminarPromocion(int PromocionID)
        {
            oDALPromocion.EliminarPromocion(PromocionID);
        }
    }
}
