
using System;
using System.Data;
using static BE.BEReporte;

namespace ABSTRACCION.Contracts
{
    public interface IReporteriaService
    {
        DataTable ObtenerReporte(TipoReporteEnum TipoReporteEnum, DateTime FechaDesde, DateTime FechasHasta);
    }
}
