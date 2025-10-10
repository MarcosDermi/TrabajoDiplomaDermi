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
        List<DateTime> CalcularSlotsDisponibles(int profesionalId, DateTime fecha, IEnumerable<int> serviciosSeleccionados);
        List<DateTime> ObtenerFechasConReservas(int idProfesional, DateTime mes);
        DataTable ObtenerReservaDiaPorFechayProfesional(int idProfesional, DateTime dtFecha);
        void ReservaAcciones(int idReserva, ReservaAcciones AccionEnum);
    }
}
