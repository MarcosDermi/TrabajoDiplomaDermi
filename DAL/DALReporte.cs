using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using static BE.BEReporte;

namespace DAL
{
    public class DALReporte
    {
        public DALReporte()
        {
            oDatos = new Datos();
            hDatos = new Hashtable();
        }

        Datos oDatos;
        Hashtable hDatos;

        public DataTable ObtenerReporte(TipoReporteEnum TipoReporteEnum, DateTime FechaDesde, DateTime FechaHasta)
        {
            hDatos = new Hashtable();
            hDatos.Add("@FechaDesde", FechaDesde);
            hDatos.Add("@FechaHasta", FechaHasta);

            string storedProcedure;

            switch (TipoReporteEnum)
            {
                case TipoReporteEnum.CantidadVentas:
                    storedProcedure = "stp_Reporteria_CantidadVentas";
                    break;

                case TipoReporteEnum.ServiciosMasContratados:
                    storedProcedure = "stp_Reporteria_ServiciosMasContratados";
                    break;

                case TipoReporteEnum.HorariosMasSolicitados:
                    storedProcedure = "stp_Reporteria_HorariosMasSolicitados";
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(TipoReporteEnum), TipoReporteEnum, null);
            }
            
            return oDatos.Leer(storedProcedure, hDatos);
        }

    }
}
