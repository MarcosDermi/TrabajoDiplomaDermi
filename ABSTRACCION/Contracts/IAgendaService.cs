using BE;
using System;
using System.Collections.Generic;
using System.Data;

namespace SERVICES.Interfaces
{
    public interface IAgendaService
    {
        List<BETurnoTomado> ObtenerTurnosTomados(int iProfesionalID, DateTime dtFecha);

        int ConfirmarReserva(BEReserva oReserva);
    }
}
