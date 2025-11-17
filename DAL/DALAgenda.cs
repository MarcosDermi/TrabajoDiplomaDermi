using ABSTRACCION;
using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;

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
                { "@UserID", null },
                { "@ProfesionalID", oReserva.ProfesionalID },
                { "@FechaInicio", oReserva.FechaInicio },
                { "@FechaFin", oReserva.FechaFin },
                { "@MedioDePagoID", oReserva.MedioDePagoID },
                { "@PrecioTotal", oReserva.PrecioTotal },
                { "@EmailConfirmacion", oReserva.Cliente.Mail }
            };

            if (oReserva.Cliente.Id != 0)
            {
                Hdatos.Add("@UserID", oReserva.Cliente.Id);
            }

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

        public List<DateTime> ObtenerFechasConReservasCliente(string Mail, DateTime mes)
        {
            var inicioMes = new DateTime(mes.Year, mes.Month, 1);
            var finMes = inicioMes.AddMonths(1).AddDays(-1);

            var oDtFechasReservasPorProfesional = oDatos.Leer("ObtenerFechasReservasPorMailRegistro", new Hashtable
                {
                    { "@Mail", Mail },
                    { "@FechaDesde", inicioMes },
                    { "@FechaHasta", finMes }
                });

            var oLstFechasReserva = oDtFechasReservasPorProfesional.AsEnumerable()
                .Select(r => ((DateTime)r["FechaReserva"]).Date)
                .Distinct()
                .ToList();

            return oLstFechasReserva;
        }

        public DataTable ObtenerReservaDiaPorFechayProfesional(int idProfesional, DateTime dtFecha)
        {
            try
            {
                return oDatos.Leer("ObtenerReservaDiaPorFechayProfesional", new Hashtable
                {
                    { "@ProfesionalID", idProfesional },
                    { "@Fecha", dtFecha }
                });

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

        public void ReservaAcciones(int idReserva, ReservaAcciones AccionEnum)
        {
            try
            {
                string stpNombre;
                Hdatos = new Hashtable
                {
                    { "@ReservaID", idReserva },
                    { "@Accion", (int)AccionEnum }
                };

                if (AccionEnum == BE.ReservaAcciones.Confirmada)
                {
                    stpNombre = "InsertReservaEstado";
                }
                else
                {
                    stpNombre = "UpdateReservaEstado";
                }

                oDatos.Escribir(stpNombre, Hdatos);

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

        public BEReserva ObtenerReserva(int idReserva)
        {
            try
            {
                var oDtReserva = oDatos.Leer("ObtenerReservaPorID", new Hashtable
                {
                    { "@ReservaID", idReserva }
                });
                if (oDtReserva.Rows.Count == 0)
                    throw new Exception("No se encontró la reserva solicitada.");
                var oDr = oDtReserva.Rows[0];
                var oReserva = new BEReserva
                {
                    ReservaID = (int)oDr["ReservaID"],
                    Cliente = new BEUsuario
                    {
                        Mail = (string)oDr["EmailConfirmacion"]
                    },
                    ProfesionalID = (int)oDr["ProfesionalID"],
                    FechaInicio = (DateTime)oDr["FechaInicio"],
                    FechaFin = (DateTime)oDr["FechaFin"],
                    MedioDePagoID = (int)oDr["MedioDePagoID"],
                    PrecioTotal = (decimal)oDr["PrecioTotal"]
                };

                var oDtServicios = oDatos.Leer("ObtenerServiciosPorReservaID", new Hashtable
                {
                    { "@ReservaID", idReserva }
                });

                foreach (DataRow oDrServicios in oDtServicios.Rows)
                {
                    var oServicio = new BEServicio
                    {
                        ServicioID = (int)oDrServicios["ServicioID"],
                        Nombre = (string)oDrServicios["Nombre"],
                        DuracionMin = (int)oDrServicios["DuracionMin"],
                        BufferMin = (int)oDrServicios["BufferMin"],
                        Precio = (decimal)oDrServicios["Precio"]
                    };

                    oReserva.Servicios.Add(oServicio);
                }
                return oReserva;
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

        public List<int> ObtenerIDsServiciosPorReservaID(int ReservaID)
        {
            try
            {
                var oDtServicios = oDatos.Leer("ObtenerServiciosPorReservaID", new Hashtable
                {
                    { "@ReservaID", ReservaID }
                });
                return oDtServicios.AsEnumerable()
                    .Select(x => (int)x["ServicioID"])
                    .ToList();
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

        public List<BETurnoTomado> ListarReservasClientesPorFechayMail(string sMail, DateTime fecha)
        {
            try
            {
                var oDtReservas = oDatos.Leer("ObtenerReservasPorFechayMail", new Hashtable
                {
                    { "@Mail", sMail },
                    { "@Fecha", fecha.Date } });

                return oDtReservas.AsEnumerable()
                    .Select(row => new BETurnoTomado
                    {
                        ProfesionalID = (int)row["ProfesionalID"],
                        Inicio = (DateTime)row["FechaInicio"],
                        Fin = (DateTime)row["FechaFin"]
                    }).ToList();

            }
            catch (Exception)
            {
                throw;
            }

        }

        public DataTable ObtenerReservaDiaPorFechayMail(string sMail, DateTime dtFecha)
        {
            try
            {
                return oDatos.Leer("ObtenerReservaDiaPorFechayMail", new Hashtable
                {
                    { "@Mail", sMail },
                    { "@Fecha", dtFecha }
                });

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

        public DataTable ObtenerReservasAfectadasPorCambioJornada(int ProfesionalID, List<int> oLstDiasSemanasEliminados)
        {
            try
            {
                var xmlDias = new XElement("Dias", oLstDiasSemanasEliminados.Select(d => new XElement("Dia", d)));

                var hdatos = new Hashtable
                    {
                        { "@ProfesionalID", ProfesionalID },
                        { "@DiasSemana", xmlDias.ToString() }
                    };

                return oDatos.Leer("stpReservas_S_AfectadasPorCambioJornada", hdatos);
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
    }
}
