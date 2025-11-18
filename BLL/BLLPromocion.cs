using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static BLL.BLLPromocion;

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


        public bool HayPromocionEnFecha(DateTime fecha)
        {
            var dtPromos = oDALPromocion.ObtenerPromocionesActivas();
            return dtPromos.AsEnumerable()
                .Any(p => fecha.Date >= ((DateTime)p["FechaDesde"]).Date
                       && fecha.Date <= ((DateTime)p["FechaHasta"]).Date
                       && (bool)p["Activo"]);
        }

        public List<DateTime> ObtenerFechasConPromociones()
        {
            DALPromocion dal = new DALPromocion();
            DataTable dt = dal.ObtenerPromocionesActivas();

            List<DateTime> fechas = new List<DateTime>();

            foreach (DataRow row in dt.Rows)
            {
                DateTime desde = ((DateTime)row["FechaDesde"]).Date;
                DateTime hasta = ((DateTime)row["FechaHasta"]).Date;

                // recorrer rango de fechas
                for (DateTime f = desde; f <= hasta; f = f.AddDays(1))
                {
                    fechas.Add(f);
                }
            }

            return fechas;
        }

        public DataTable ObtenerPromocionesActivas()
        {
            return oDALPromocion.ObtenerPromocionesActivas();
        }
    }
}
