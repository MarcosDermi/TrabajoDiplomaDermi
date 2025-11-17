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
    public class DALProfesional : IGestor<BEProfesional>
    {
        Datos oDatos;
        Hashtable Hdatos;

        public DALProfesional()
        {
            oDatos = new Datos();
        }

        public bool Baja(BEProfesional Objeto)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            try
            {
                var stpNombre = "GetAllProfesionales";
                Hdatos = new Hashtable();

                return oDatos.Leer(stpNombre, Hdatos);

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

        public BEProfesional GetOne(int iId)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEProfesional Objeto)
        {
            throw new NotImplementedException();
        }

        public DataTable TraerListadoProfesionalesSinServicios()
        {
            try
            {
                var stpNombre = "GetProfesionalesSinServicios";
                Hdatos = new Hashtable();
                return oDatos.Leer(stpNombre, Hdatos);
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

        public List<BEProfesional> ListarTodo(bool EsControlCambio, int iIdUsuario)
        {
            var oLstProfesionales = new List<BEProfesional>();
            try
            {
                var stpNombre = "GetAllProfesionales";
                Hdatos = new Hashtable();

                var oDtProfesionales = oDatos.Leer(stpNombre, Hdatos);

                foreach (DataRow oDr in oDtProfesionales.AsEnumerable())
                {
                    var oBEProfesional = new BEProfesional
                    {
                        ProfesionalID = (int)oDr["Id"],
                        Nombre = (string)oDr["Nombre"],
                        Apellido = (string)oDr["Apellido"],
                        Email = (string)oDr["Mail"]
                    };

                    var oDtServicios = oDatos.Leer("ObtenerServiciosPorProfesional", new Hashtable() { { "@ProfesionalID", oBEProfesional.ProfesionalID } });

                    foreach (DataRow oDrServicio in oDtServicios.AsEnumerable())
                    {
                        var oBEServicio = new BEServicio
                        {
                            ServicioID = (int)oDrServicio["ServicioID"],
                            Nombre = (string)oDrServicio["Nombre"],
                            Precio = (decimal)oDrServicio["Precio"],
                            DuracionMin = (int)oDrServicio["DuracionMin"],
                            BufferMin = (int)oDrServicio["BufferMin"]
                        };
                        oBEProfesional.Servicios.Add(oBEServicio);
                    }

                    oLstProfesionales.Add(oBEProfesional);
                }

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

        public bool BajaID(int iId)
        {
            throw new NotImplementedException();
        }

        public BEProfesional ObtenerProfesionalPorUsuarioID(int iUsuarioID)
        {
            Hdatos = new Hashtable();
            Hdatos.Add("@UsuarioID", iUsuarioID);

            var oDtProfesional = oDatos.Leer("ObtenerProfesionalPorUsuarioID", Hdatos);

            foreach (DataRow row in oDtProfesional.Rows)
            {
                return new BEProfesional
                {
                    ProfesionalID = (int)row["Id"],
                    Nombre = (string)row["Nombre"],
                    Apellido = (string)row["Apellido"],
                    Email = (string)row["Mail"]
                };
            }

            return new BEProfesional();
        }

        public DataTable ObtenerJornadasLaboralesPorProfesionalID(int ProfesionalID)
        {
            try
            {

                Hdatos = new Hashtable();
                Hdatos.Add("@ProfesionalID", ProfesionalID);
                return oDatos.Leer("stpJornadaLaboral_S_X_ProfesionalID", Hdatos);
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

        public DataTable ObtenerFranjaHorariaPorJornadaID(int JornadaID)
        {
            try
            {
                Hdatos = new Hashtable();
                Hdatos.Add("@JornadaID", JornadaID);
                return oDatos.Leer("stpFranjaHoraria_S_X_JornadaID", Hdatos);
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

        public List<int> ObtenerDiasSemanaPorProfesional(int profesionalID)
        {
            var oLstDiasSemana = new List<int>();

            Hdatos = new Hashtable();
            Hdatos.Add("@ProfesionalID", profesionalID);

            var oDtDiasSemana = oDatos.Leer("stpProfesionalDiaSemana_S_X_ProfesionalID", Hdatos);

            foreach (DataRow row in oDtDiasSemana.Rows)
            {
                oLstDiasSemana.Add((int)row["DiaSemanaID"]);
            }
            return oLstDiasSemana;
        }

        public void ActualizarJornadasProfesional(int profesionalID, List<int> oLstDiasSemana)
        {
            var xmlDias = new XElement("Dias", oLstDiasSemana.Select(d => new XElement("Dia", d)));

            var hdatos = new Hashtable
    {
        { "@ProfesionalID", profesionalID },
        { "@DiasSemana", xmlDias.ToString() }
    };

            oDatos.Escribir("stpJornadaLaboral_U_Completo", hdatos);
        }

        public void GuardarFranjaHoraria(int JornadaID, TimeSpan HoraInicio, TimeSpan HoraFin)
        {
            var hdatos = new Hashtable
            {
                { "@JornadaID", JornadaID },
                { "@HoraInicio", HoraInicio },
                { "@HoraFin", HoraFin }
            };

            oDatos.Escribir("stpFranjaHoraria_I", hdatos);
        }

        public void EliminarFranjaHoraria(int FranjaHorariaID)
        {
            try
            {
                var hdatos = new Hashtable
            {
                { "@FranjaHorariaID", FranjaHorariaID }
            };
                oDatos.Escribir("stpFranjaHoraria_D", hdatos);
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

        public DataTable ObtenerReservasAfectadasPorCambioFranja(int FranjaHorariaID)
        {
            try
            {
                Hdatos = new Hashtable();
                Hdatos.Add("@FranjaID", FranjaHorariaID);
                return oDatos.Leer("stpReservas_S_AfectadasPorFranjaEliminada", Hdatos);
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
