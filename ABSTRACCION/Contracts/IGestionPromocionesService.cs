using BE;
using System;
using System.Collections.Generic;
using System.Data;

namespace ABSTRACCION.Contracts
{
    public interface IGestionPromocionesService
    {
        void GuardarPromocion(BEPromocion oBEPromocion);
        void EliminarPromocion(int PromocionID);
        DataTable BuscarPromocionesPorFiltrosVarios(string sNombre, DateTime FechaDesde, DateTime FechaHasta, bool IncluirInactivos);
        bool VerificarPromocionVigenteParaFecha(DateTime dtReservaFechaInicio);
        DataTable ObtenerPromocionesActivas();
        List<DateTime> ObtenerFechasConPromociones();
    }
}
