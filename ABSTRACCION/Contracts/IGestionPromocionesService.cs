using BE;
using System;
using System.Collections.Generic;
using System.Data;

namespace ABSTRACCION.Contracts
{
    public interface IGestionPromocionesService
    {
        void GuardarPromocion(BEPromocion oBEPromocion);

        DataTable BuscarPromocionesPorFiltrosVarios(string sNombre, DateTime FechaDesde, DateTime FechaHasta, bool IncluirInactivos);
    }
}
