using BE;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLL
{
    public class BLLAgenda
    {
        DALAgenda oDALAgenda;
        BLLProfesional oBLLProfesional;
        DALServicios oDALServicio;
        DALProfesionalServicio oDALProfesionalServicio;
        private readonly Dictionary<int, List<BEJornadaLaboral>> _dicAgenda = new Dictionary<int, List<BEJornadaLaboral>>();
        private static readonly TimeSpan Paso = TimeSpan.FromMinutes(15);

        public BLLAgenda()
        {
            oDALAgenda = new DALAgenda();
            oBLLProfesional = new BLLProfesional();
            oDALServicio = new DALServicios();
            oDALProfesionalServicio = new DALProfesionalServicio();
        }

        public int DuracionTotalSeleccionadaMin(IEnumerable<int> serviciosSeleccionados)
        {
            int iTotal = 0;
            foreach (var id in serviciosSeleccionados)
            {
                var oServicio = oDALServicio.ObtenerServicio(id);
                iTotal += oServicio.DuracionMin + oServicio.BufferMin;
            }
            return iTotal;
        }

        private bool ProfesionalSoportaServicios(int iProfesionalID, IEnumerable<int> serviciosSeleccionados)
        {
            var oLstServiciosProfesional = oDALProfesionalServicio.ObtenerServiciosDeProfesional(iProfesionalID);
            // Servicios que el profesional NO tiene asignados
            var oLstServiciosNoSoportados = serviciosSeleccionados.Where(s => !oLstServiciosProfesional.Contains(s)).ToList();

            if (oLstServiciosNoSoportados.Count == 0) { return true; }
            return false;
        }

        public void CargarAgenda(int iProfesionalID)
        {
            var oLstJornadasProfesional = oDALAgenda.ObtenerFranjasPorProfesional(iProfesionalID);
            _dicAgenda[iProfesionalID] = oLstJornadasProfesional;
        }

        private List<BEFranja> ObtenerFranjasLaboralesDelDia(int iProfesionalID, DateTime oDtFecha)
        {
            CargarAgenda(iProfesionalID);

            //Si existe la clave iProfesionalID, oLstJornadasProfesional va a contener la lista de franjas laborales
            if (!_dicAgenda.TryGetValue(iProfesionalID, out var oLstJornadasProfesional)) return new List<BEFranja>();

            var oJornadaLaboral = oLstJornadasProfesional.FirstOrDefault(x => x.Dia == oDtFecha.DayOfWeek);

            if (oJornadaLaboral == null) return new List<BEFranja>();

            // Se ajustan las franjas al dia especifico y devolvemos la lista de franjas dentro de la jornada laboral.
            return oJornadaLaboral.Franjas.Select(f => new BEFranja
            {
                Inicio = new DateTime(oDtFecha.Year, oDtFecha.Month, oDtFecha.Day, f.Inicio.Hour, f.Inicio.Minute, 0),
                Fin = new DateTime(oDtFecha.Year, oDtFecha.Month, oDtFecha.Day, f.Fin.Hour, f.Fin.Minute, 0)
            }).ToList();
        }

        public List<DateTime> CalcularSlotsDisponibles(int iProfesionalID, DateTime oDtFecha, IEnumerable<int> serviciosSeleccionados)
        {
            var oLstSlotsDisponibles = new List<DateTime>();

            // 0 - Validacion
            if (!ProfesionalSoportaServicios(iProfesionalID, serviciosSeleccionados)) return oLstSlotsDisponibles;

            // 1-  Duracion requerida
            var iDuracionRequeridaMin = DuracionTotalSeleccionadaMin(serviciosSeleccionados);
            if (iDuracionRequeridaMin <= 0) return oLstSlotsDisponibles;
            var tsDuracionRequeridaMin = TimeSpan.FromMinutes(iDuracionRequeridaMin);

            // 2) franjas laborales
            var oLstFranjasLaborales = ObtenerFranjasLaboralesDelDia(iProfesionalID, oDtFecha);
            if (oLstFranjasLaborales.Count == 0) return oLstSlotsDisponibles;

            // 3) reservas ocupadas desde BD
            var oLstTurnosOcupados = oBLLProfesional.GetTurnosTomados(iProfesionalID, oDtFecha);

            // 4) Generar slots cada 15'(paso) en todas las franjas, filtrando por solapamiento.
            foreach (var Franja in oLstFranjasLaborales)
            {
                for (var oDtInicio = Franja.Inicio; oDtInicio.Add(tsDuracionRequeridaMin) <= Franja.Fin; oDtInicio = oDtInicio.Add(Paso))
                {
                    var oDtFin = oDtInicio.Add(tsDuracionRequeridaMin);

                    bool seSolapa = oLstTurnosOcupados.Any(o => Solapa(oDtInicio, oDtFin, o.Inicio, o.Fin));

                    if (!seSolapa)
                        oLstSlotsDisponibles.Add(oDtInicio);
                }
            }

            return oLstSlotsDisponibles.OrderBy(slot => slot).ToList();
        }

        bool Solapa(DateTime aInicio, DateTime aFin, DateTime bInicio, DateTime bFin) => aInicio < bFin && bInicio < aFin;

        public int ConfirmarReserva(BEReserva oReserva)
        {
            var slots = CalcularSlotsDisponibles(oReserva.ProfesionalID, oReserva.FechaInicio, oReserva.Servicios.Select(s => s.ServicioID));

            //Si hay usuarios en simultaneo
            if (!slots.Contains(oReserva.FechaInicio))
                throw new Exception("El horario seleccionado ya no está disponible.");

            return oDALAgenda.ConfirmarReserva(oReserva);
        }

        public List<DateTime> ObtenerFechasConReservas(int iProfesionalID, DateTime oDtMes)
        {
            return oDALAgenda.ObtenerFechasConReservas(iProfesionalID, oDtMes);
        }

        public DataTable ObtenerReservaDiaPorFechayProfesional(int iProfesionalID, DateTime oDtFecha)
        {
            return oDALAgenda.ObtenerReservaDiaPorFechayProfesional(iProfesionalID, oDtFecha);
        }

        public void ReservaAcciones(int idReserva, ReservaAcciones AccionEnum)
        {
            oDALAgenda.ReservaAcciones(idReserva, AccionEnum);
        }

        public BEReserva ObtenerReserva(int idReserva)
        {
            return oDALAgenda.ObtenerReserva(idReserva);
        }

    }
}
