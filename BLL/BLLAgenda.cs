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
            int total = 0;
            foreach (var id in serviciosSeleccionados)
            {
                var s = oDALServicio.ObtenerServicio(id);
                total += s.DuracionMin + s.BufferMin;
            }
            return total;
        }

        private bool ProfesionalSoportaServicios(int profesionalId, IEnumerable<int> serviciosSeleccionados, out string motivo)
        {
            var set = oDALProfesionalServicio.ObtenerServiciosDeProfesional(profesionalId);
            var faltantes = serviciosSeleccionados.Where(s => !set.Contains(s)).ToList();
            if (faltantes.Count == 0) { motivo = ""; return true; }
            motivo = "Este profesional no realiza: " + string.Join(", ", faltantes.Select(f => oDALServicio.ObtenerServicio(f).Nombre));
            return false;
        }

        public void CargarAgenda(int profesionalId)
        {
            var jornadas = oDALAgenda.ObtenerFranjasPorProfesional(profesionalId);
            _dicAgenda[profesionalId] = jornadas;
        }

        private List<BEFranja> ObtenerFranjasLaboralesDelDia(int profesionalId, DateTime fecha)
        {
            CargarAgenda(profesionalId);

            if (!_dicAgenda.TryGetValue(profesionalId, out var jornadas))
                return new List<BEFranja>();

            var jornada = jornadas.FirstOrDefault(x => x.Dia == fecha.DayOfWeek);
            if (jornada == null) return new List<BEFranja>();

            // Ajustamos las franjas al día seleccionado
            return jornada.Franjas.Select(f => new BEFranja
            {
                Inicio = new DateTime(fecha.Year, fecha.Month, fecha.Day, f.Inicio.Hour, f.Inicio.Minute, 0),
                Fin = new DateTime(fecha.Year, fecha.Month, fecha.Day, f.Fin.Hour, f.Fin.Minute, 0)
            }).ToList();
        }

        private static List<BEFranja> RestarOcupaciones(List<BEFranja> libres, List<BETurnoTomado> ocupados)
        {
            foreach (var t in ocupados)
                libres = SubtractInterval(libres, t.Inicio, t.Fin);
            return libres;
        }

        private static List<BEFranja> SubtractInterval(List<BEFranja> origen, DateTime oIni, DateTime oFin)
        {
            var result = new List<BEFranja>();

            foreach (var f in origen)
            {
                // Caso 1: sin solapamiento
                if (oFin <= f.Inicio || oIni >= f.Fin)
                {
                    result.Add(f);
                    continue;
                }

                // Caso 2: hay solapamiento → recortar
                if (oIni > f.Inicio)
                    result.Add(new BEFranja { Inicio = f.Inicio, Fin = oIni });

                if (oFin < f.Fin)
                    result.Add(new BEFranja { Inicio = oFin, Fin = f.Fin });
            }

            // Eliminar fragmentos inválidos (Fin <= Inicio)
            return result.Where(x => x.Fin > x.Inicio).ToList();
        }

        bool Solapa(DateTime aInicio, DateTime aFin, DateTime bInicio, DateTime bFin)
    => aInicio < bFin && bInicio < aFin;

        public List<DateTime> CalcularSlotsDisponibles(int profesionalId, DateTime fecha, IEnumerable<int> serviciosSeleccionados)
        {
            var slots = new List<DateTime>();

            // 0) validación
            if (!ProfesionalSoportaServicios(profesionalId, serviciosSeleccionados, out _))
                return slots;

            // 1) duración requerida
            var requeridosMin = DuracionTotalSeleccionadaMin(serviciosSeleccionados);
            if (requeridosMin <= 0) return slots;
            var dur = TimeSpan.FromMinutes(requeridosMin);

            // 2) franjas laborales
            var franjas = ObtenerFranjasLaboralesDelDia(profesionalId, fecha);
            if (franjas.Count == 0) return slots;

            // 3) reservas ocupadas desde BD (asumo objetos con Inicio/Fin DateTime)
            var ocupados = oBLLProfesional.GetTurnosTomados(profesionalId, fecha);

            // 4) Generar slots cada 15' en TODAS las franjas, filtrando por solape
            foreach (var f in franjas)
            {
                for (var inicio = f.Inicio; inicio.Add(dur) <= f.Fin; inicio = inicio.Add(Paso))
                {
                    var fin = inicio.Add(dur);
                    bool seSolapa = ocupados.Any(o => Solapa(inicio, fin, o.Inicio, o.Fin));
                    if (!seSolapa)
                        slots.Add(inicio);
                }
            }

            return slots.OrderBy(s => s).ToList();
        }

        public int ConfirmarReserva(BEReserva oReserva)
        {
            var slots = CalcularSlotsDisponibles(oReserva.ProfesionalID, oReserva.FechaInicio, oReserva.Servicios.Select(s => s.ServicioID));
            
            if (!slots.Contains(oReserva.FechaInicio))
                throw new Exception("El horario seleccionado ya no está disponible.");

            return oDALAgenda.ConfirmarReserva(oReserva);
        }

        public List<DateTime> ObtenerFechasConReservas(int idProfesional, DateTime mes)
        {
            return oDALAgenda.ObtenerFechasConReservas(idProfesional, mes);
        }

        public DataTable ObtenerReservaDiaPorFechayProfesional(int idProfesional, DateTime dtFecha)
        {
            return oDALAgenda.ObtenerReservaDiaPorFechayProfesional(idProfesional, dtFecha);
        }

        public void ReservaAcciones(int idReserva, ReservaAcciones AccionEnum)
        {
            oDALAgenda.ReservaAcciones(idReserva, AccionEnum);
        }

    }
}
