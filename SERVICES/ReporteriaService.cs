using ABSTRACCION.Contracts;
using System;
using BLL;
using System.Data;
using static BE.BEReporte;

namespace SERVICES
{
    public class ReporteriaService: IReporteriaService
    {
        BLLReporte oBLLReporte;

        public ReporteriaService()
        {
            oBLLReporte = new BLLReporte();
        }
        public DataTable ObtenerReporte(TipoReporteEnum TipoReporteEnum, DateTime FechaDesde, DateTime FechaHasta)
        {
            oBLLReporte = new BLLReporte();
            return oBLLReporte.ObtenerReporte(TipoReporteEnum, FechaDesde, FechaHasta);
        }
    }
}
