using ABSTRACCION;
using BE;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using static BE.BEReporte;

namespace BLL
{
    public class BLLReporte
    {
        DALReporte oDALReporte;

        public BLLReporte()
        {
            oDALReporte = new DALReporte();
        }

        public DataTable ObtenerReporte(TipoReporteEnum tipo, DateTime desde, DateTime hasta)
        {
            return oDALReporte.ObtenerReporte(tipo, desde, hasta);
        }
    }
}
