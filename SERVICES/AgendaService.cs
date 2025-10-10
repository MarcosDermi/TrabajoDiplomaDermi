using BE;
using BLL;
using SERVICES.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace SERVICES
{
    public class AgendaService : IAgendaService
    {
        BLLProfesional oBLLProfesional;

        public AgendaService()
        {
            oBLLProfesional = new BLLProfesional();
        }

        public List<BETurnoTomado> ObtenerTurnosTomados(int iProfesionalID, DateTime dtFecha)
        {
            return oBLLProfesional.GetTurnosTomados(iProfesionalID, dtFecha);
        }

        public int ConfirmarReserva(BEReserva oReserva)
        {
            BLLAgenda oBLLAgenda = new BLLAgenda();
            return oBLLAgenda.ConfirmarReserva(oReserva);
        }

        public int DuracionTotalSeleccionadaMin(IEnumerable<int> serviciosSeleccionados)
        {
            BLLAgenda oBLLAgenda = new BLLAgenda();
            return oBLLAgenda.DuracionTotalSeleccionadaMin(serviciosSeleccionados);
        }

        public List<DateTime> CalcularSlotsDisponibles(int profesionalId, DateTime fecha, IEnumerable<int> serviciosSeleccionados)
        {
            BLLAgenda oBLLAgenda = new BLLAgenda();
            return oBLLAgenda.CalcularSlotsDisponibles(profesionalId, fecha, serviciosSeleccionados);
        }

        public List<DateTime> ObtenerFechasConReservas(int idProfesional, DateTime mes)
        {
            BLLAgenda oBLLAgenda = new BLLAgenda();
            return oBLLAgenda.ObtenerFechasConReservas(idProfesional, mes);
        }

        public DataTable ObtenerReservaDiaPorFechayProfesional(int idProfesional, DateTime dtFecha)
        {
            BLLAgenda oBLLAgenda = new BLLAgenda();
            return oBLLAgenda.ObtenerReservaDiaPorFechayProfesional(idProfesional, dtFecha);
        }

        public void ReservaAcciones(int idReserva, ReservaAcciones AccionEnum)
        {

            BLLAgenda oBLLAgenda = new BLLAgenda();
            oBLLAgenda.ReservaAcciones(idReserva, AccionEnum);
        }
    }
}
