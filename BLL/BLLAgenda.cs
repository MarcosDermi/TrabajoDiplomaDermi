using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DAL;
using BE;

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

        private int DuracionTotalSeleccionadaMin(IEnumerable<int> serviciosSeleccionados)
        {
            int total = 0;
            foreach (var id in serviciosSeleccionados)
            {
                var s = oDALServicio.ObtenerServicio(id); // esto vendría de DALServicios
                total += s.DuracionMin + s.BufferMin;
            }
            return total;
        }

        private bool ProfesionalSoportaServicios(int profesionalId, IEnumerable<int> serviciosSeleccionados, out string motivo)
        {
            var set = oDALProfesionalServicio.ObtenerServiciosDeProfesional(profesionalId); // vendría de DALProfesionalServicio
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

        public List<DateTime> CalcularSlotsDisponibles(int profesionalId, DateTime fecha, IEnumerable<int> serviciosSeleccionados)
        {
            var slots = new List<DateTime>();

            // 0) validación de servicios soportados
            if (!ProfesionalSoportaServicios(profesionalId, serviciosSeleccionados, out _))
                return slots;

            // 1) duración requerida
            var requeridosMin = DuracionTotalSeleccionadaMin(serviciosSeleccionados);
            if (requeridosMin <= 0) return slots;
            var dur = TimeSpan.FromMinutes(requeridosMin);

            // 2) franjas laborales
            var franjas = ObtenerFranjasLaboralesDelDia(profesionalId, fecha);
            if (franjas.Count == 0) return slots;

            // 3) reservas ocupadas desde BD
            var ocupados = oBLLProfesional.GetTurnosTomados(profesionalId, fecha);
            var libres = RestarOcupaciones(franjas, ocupados);

            // 4) slots cada 15 minutos
            foreach (var f in libres)
            {
                for (var inicio = f.Inicio; inicio + dur <= f.Fin; inicio += Paso)
                    slots.Add(inicio);
            }
            return slots;
        }

        
    }
}
