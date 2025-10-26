using BE;
using BE.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;

namespace DAL
{
    public class DALServicios
    {
        Datos oDatos;
        Hashtable Hdatos;

        public DALServicios()
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
                            Nombre = (string)s["NombreServicio"],
                            Precio = (decimal)s["PrecioServicio"],
                            DuracionMin = (int)s["DuracionMin"],
                            BufferMin = (int)s["BufferMin"]
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

        public BEServicio ObtenerServicio(int iId)
        {
            try
            {
                var stpNombre = "ObtenerServicio";
                Hdatos = new Hashtable();
                Hdatos.Add("@ServicioID", iId);

                var oDtServicio = oDatos.Leer(stpNombre, Hdatos);

                if (oDtServicio.Rows.Count > 0)
                {
                    var row = oDtServicio.Rows[0];
                    return new BEServicio
                    {
                        ServicioID = (int)row["ServicioID"],
                        Nombre = (string)row["Nombre"],
                        DuracionMin = (int)row["DuracionMin"],
                        BufferMin = (int)row["BufferMin"],
                        Precio = (decimal)row["Precio"]
                    };
                }

                throw new ServicioNoEncontradoException(iId);
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

        public List<BEServicio> ListarServicios()
        {
            try
            {
                var stpNombre = "ListarServicios";
                Hdatos = new Hashtable();
                var oDtServicios = oDatos.Leer(stpNombre, Hdatos);

                if (oDtServicios.Rows.Count > 0)
                {
                    return oDtServicios.AsEnumerable()
                        .Select(row => new BEServicio
                        {
                            ServicioID = (int)row["ServicioID"],
                            Nombre = (string)row["Nombre"],
                            DuracionMin = (int)row["DuracionMin"],
                            BufferMin = (int)row["BufferMin"],
                            Precio = (decimal)row["Precio"]
                        }).ToList();
                }

                return new List<BEServicio>();
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

        public DataTable ObtenerServiciosPorProfesional(int ProfesionalID)
        {
            try
            {
                Hdatos = new Hashtable();
                Hdatos.Add("@ProfesionalID", ProfesionalID);
                return oDatos.Leer("ObtenerServiciosPorProfesional", Hdatos);
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
        public DataTable ObtenerObtenerInsumosPorServicio(int ServicioID)
        {
            try
            {
                Hdatos = new Hashtable();
                Hdatos.Add("@ServicioID", ServicioID);
                return oDatos.Leer("ObtenerObtenerInsumosPorServicio", Hdatos);
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
