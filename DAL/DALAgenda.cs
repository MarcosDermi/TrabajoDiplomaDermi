using ABSTRACCION;
using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class DALAgenda
    {
        Datos oDatos;
        Hashtable Hdatos;

        public DALAgenda()
        {
            oDatos = new Datos();
        }

        public List<BEProfesional> ListarTodo(bool EsControlCambio, int iIdUsuario)
        {
            var oLstProfesionales = new List<BEProfesional>();
            try
            {
                var stpNombre = "GetAllProfesionales";
                Hdatos = new Hashtable();

                var oDtProfesionales = oDatos.Leer(stpNombre, Hdatos);

                oLstProfesionales = oDtProfesionales.AsEnumerable()
                    .GroupBy(row => new
                    {
                        ProfesionalID = (int)row["ProfesionalID"],
                        Nombre = (string)row["Nombre"],
                        Apellido = (string)row["Apellido"],
                        Telefono = (string)row["Telefono"],
                        Email = (string)row["Email"]
                    })
                    .Select(g => new BEProfesional
                    {
                        ProfesionalID = g.Key.ProfesionalID,
                        Nombre = g.Key.Nombre,
                        Apellido = g.Key.Apellido,
                        Telefono = g.Key.Telefono,
                        Email = g.Key.Email,
                        Servicios = g.Select(s => new BEServicio
                        {
                            ServicioID = (int)s["ServicioID"],
                            Nombre = (string)s["NombreServicio"]
                        }).ToList()
                    })
                    .ToList();


                return oLstProfesionales;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BETurnoTomado> ListarReservasPorFecha(int ProfesionalID, DateTime fecha)
        {

            var stpNombre = "ObtenerReservasPorProfesionalyFecha";
            Hdatos = new Hashtable();
            Hdatos.Add("@ProfesionalID", ProfesionalID);
            Hdatos.Add("@Fecha", fecha.Date);

            var oDtProfesionales = oDatos.Leer(stpNombre, Hdatos);

            return oDtProfesionales.AsEnumerable()
                .Select(row => new BETurnoTomado
                {
                    ProfesionalID = (int)row["ProfesionalID"],
                    Inicio = (DateTime)row["FechaInicio"],
                    Fin = (DateTime)row["FechaFin"]
                }).ToList();
        }

        public List<BEJornadaLaboral> ObtenerFranjasPorProfesional(int profesionalId)
        {
            var oLstJornadas = new List<BEJornadaLaboral>();

            try
            {
                var stpNombre = "ObtenerFranjasPorProfesional";
                Hdatos = new Hashtable
                {
                    { "@ProfesionalID", profesionalId }
                };

                var oDtFranjas = oDatos.Leer(stpNombre, Hdatos);

                oLstJornadas = oDtFranjas.AsEnumerable()
                    .GroupBy(row => new
                    {
                        DiaSemana = Convert.ToInt32(row["DiaSemana"])
                    })
                    .Select(g => new BEJornadaLaboral
                    {
                        Dia = (DayOfWeek)g.Key.DiaSemana,
                        Franjas = g.Select(f => new BEFranja
                        {
                            Inicio = DateTime.Today.Add((TimeSpan)f["HoraInicio"]),
                            Fin = DateTime.Today.Add((TimeSpan)f["HoraFin"])
                        }).ToList()
                    })
                    .ToList();

                return oLstJornadas;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL al obtener franjas del profesional.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general al obtener franjas del profesional.", ex);
            }
        }

        public int ConfirmarReserva(BEReserva oReserva)
        {
            var stpNombre = "ConfirmarReserva";
            Hdatos = new Hashtable
            {
                { "@ClienteID", oReserva.Cliente.Id },
                { "@ProfesionalID", oReserva.ProfesionalID },
                { "@FechaInicio", oReserva.FechaInicio },
                { "@FechaFin", oReserva.FechaFin },
                { "@MedioDePagoID", oReserva.MedioDePagoID },
                { "@PrecioTotal", oReserva.PrecioTotal },
                { "@EmailConfirmacion", oReserva.Cliente.Mail }
            };

            int _ = 0;

            try
            {
                oDatos.Escribir(stpNombre, Hdatos, out int ReservaID, true);

                foreach (var servicio in oReserva.Servicios)
                {
                    Hdatos = new Hashtable
                        {
                            { "@ReservaID", ReservaID },
                            { "@ServicioID", servicio.ServicioID }
                        };

                    oDatos.Escribir("InsertReservaServicio", Hdatos);
                }

                return ReservaID;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DateTime> ObtenerFechasConReservas(int idProfesional, DateTime mes)
        {
            var inicioMes = new DateTime(mes.Year, mes.Month, 1);
            var finMes = inicioMes.AddMonths(1).AddDays(-1);

            // Llamás a tu DAL o SP para obtener reservas entre inicio y fin del mes
            var oDtFechasReservasPorProfesional = oDatos.Leer("ObtenerFechasReservasPorProfesional", new Hashtable
                {
                    { "@ProfesionalID", idProfesional },
                    { "@FechaDesde", inicioMes },
                    { "@FechaHasta", finMes }
                });

            var oLstFechasReserva = oDtFechasReservasPorProfesional.AsEnumerable()
                .Select(r => ((DateTime)r["FechaReserva"]).Date)
                .Distinct()
                .ToList();

            return oLstFechasReserva;
        }


    }
}
