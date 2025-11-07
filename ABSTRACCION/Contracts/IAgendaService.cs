using BE;
using System;
using System.Collections.Generic;
using System.Data;

namespace SERVICES.Interfaces
{
    public interface IAgendaService
    {
        List<BETurnoTomado> ObtenerTurnosTomados(int iProfesionalID, DateTime dtFecha);
        int ConfirmarReserva(BEReserva oReserva, int iIdUsuario);
        int DuracionTotalSeleccionadaMin(IEnumerable<int> serviciosSeleccionados);
        List<DateTime> CalcularSlotsDisponibles(int iProfesionalID, DateTime dtFecha, IEnumerable<int> serviciosSeleccionados);
        List<DateTime> ObtenerFechasConReservas(int iProfesionalID, DateTime dtMes);
        DataTable ObtenerReservaDiaPorFechayProfesional(int iProfesionalID, DateTime dtFecha);
        DataTable ObtenerReservaDiaPorFechayMail(string sMail, DateTime dtFecha);
        void ReservaAcciones(int iReservaID, ReservaAcciones AccionEnum);
        BEReserva ObtenerReserva(int idReserva);
        List<int> ObtenerIDsServiciosPorReservaID(int ReservaID);
        List<DateTime> ObtenerFechasConReservasCliente(string Mail, DateTime dtFecha);

        List<BETurnoTomado> ListarReservasClientesPorFechayMail(string sMail, DateTime fecha);
    }
}
