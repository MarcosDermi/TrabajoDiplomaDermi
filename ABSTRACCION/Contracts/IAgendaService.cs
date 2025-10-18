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
        int DuracionTotalSeleccionadaMin(IEnumerable<int> serviciosSeleccionados);
        List<DateTime> CalcularSlotsDisponibles(int iProfesionalID, DateTime dtFecha, IEnumerable<int> serviciosSeleccionados);
        List<DateTime> ObtenerFechasConReservas(int iProfesionalID, DateTime dtMes);
        DataTable ObtenerReservaDiaPorFechayProfesional(int iProfesionalID, DateTime dtFecha);
        void ReservaAcciones(int iReservaID, ReservaAcciones AccionEnum);
        BEReserva ObtenerReserva(int idReserva);
    }
}
