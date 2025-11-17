using BE;
using BE.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Linq;

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

        public DataTable ObtenerProfesionalServicioPorServicioID(int ServicioID)
        {
            try
            {
                Hdatos = new Hashtable();
                Hdatos.Add("@ServicioID", ServicioID);
                return oDatos.Leer("ObtenerProfesionalServicioPorServicioID", Hdatos);
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

        public void GuardarInsumosServicio(BEServicio oBEServicio, List<InsumoSeleccionado> oLstInsumos, List<int> oLstProfesionalesSeleccionadosIds)
        {
            try
            {
                if (oBEServicio.ServicioID == 0)
                {
                    Hdatos = new Hashtable
            {
                { "@Nombre", oBEServicio.Nombre },
                { "@DuracionMin", oBEServicio.DuracionMin },
                { "@BufferMin", oBEServicio.BufferMin },
                { "@Precio", oBEServicio.Precio }
            };

                    var dt = oDatos.Leer("stpServicios_I_Basico", Hdatos);
                    oBEServicio.ServicioID = Convert.ToInt32(dt.Rows[0]["NuevoServicioID"]);
                }
                else
                {
                    Hdatos = new Hashtable
            {
                { "@ServicioID", oBEServicio.ServicioID },
                { "@Nombre", oBEServicio.Nombre },
                { "@DuracionMin", oBEServicio.DuracionMin },
                { "@BufferMin", oBEServicio.BufferMin },
                { "@Precio", oBEServicio.Precio }
            };
                    oDatos.Escribir("stpServicios_U_Basico", Hdatos);
                }

                Hdatos = new Hashtable { { "@ServicioID", oBEServicio.ServicioID } };
                var oDtProfesionalesActuales = oDatos.Leer("ObtenerProfesionalIDPorServicioID", Hdatos);
                var oLstProfesionalesActualesIds = oDtProfesionalesActuales.AsEnumerable().Select(x => (int)x["ProfesionalID"]).ToList();

                // a) Eliminar los que ya no están
                foreach (var iProfesionalID in oLstProfesionalesActualesIds.Except(oLstProfesionalesSeleccionadosIds))
                {
                    Hdatos = new Hashtable
                    {
                        { "@ProfesionalID", iProfesionalID },
                        { "@ServicioID", oBEServicio.ServicioID }
                    };

                    oDatos.Escribir("stpProfesionalesServicios_D_X_ServicioID_ProfesionalID", Hdatos);
                }


                // b) Insertar los nuevos
                foreach (var iProfesionalID in oLstProfesionalesSeleccionadosIds.Except(oLstProfesionalesActualesIds))
                {
                    Hdatos = new Hashtable
                    {
                        { "@ProfesionalID", iProfesionalID },
                        { "@ServicioID", oBEServicio.ServicioID }
                    };

                    oDatos.Escribir("stpProfesionalesServicios_I_X_ServicioID_ProfesionalID", Hdatos);
                }


                // 3️⃣ Actualizar relaciones INSUMOS
                // Construimos el diccionario a partir de la lista
                var oDicInsumos = oLstInsumos
                    .GroupBy(i => i.InsumoID)
                    .ToDictionary(g => g.Key, g => g.Sum(i => Convert.ToDecimal(i.CantidadUsar)));

                // Leemos los insumos actuales del servicio
                Hdatos = new Hashtable { { "@ServicioID", oBEServicio.ServicioID } };
                var oDtInsumosActuales = oDatos.Leer("ObtenerInsumosServicioPorServicioID", Hdatos);
                var oDicInsumosActuales = oDtInsumosActuales.AsEnumerable().ToDictionary(r => (int)r["InsumoID"], r => Convert.ToDecimal(r["CantidadUtilizada"]));

                // a) Eliminar los que ya no están
                foreach (var iInsumoID in oDicInsumosActuales.Keys.Except(oDicInsumos.Keys))
                {
                    Hdatos = new Hashtable
                    {
                        { "@ServicioID", oBEServicio.ServicioID },
                        { "@InsumoID", iInsumoID }
                    };
                    oDatos.Escribir("stpServiciosInsumos_D_X_ServicioID_InsumoID", Hdatos);
                }

                // b) Actualizar o insertar según corresponda
                foreach (var oKvp in oDicInsumos)
                {
                    if (oDicInsumosActuales.ContainsKey(oKvp.Key))
                    {
                        // Solo actualizamos si cambió la cantidad
                        if (oDicInsumosActuales[oKvp.Key] != oKvp.Value)
                        {
                            Hdatos = new Hashtable
                            {
                                { "@ServicioID", oBEServicio.ServicioID },
                                { "@InsumoID", oKvp.Key },
                                { "@CantidadUtilizada", oKvp.Value }
                            };

                            oDatos.Escribir("stpServiciosInsumos_U_X_ServicioID_InsumoID_CantidadUtilizada", Hdatos);
                        }

                    }
                    else
                    {
                        Hdatos = new Hashtable
                            {
                                { "@ServicioID", oBEServicio.ServicioID },
                                { "@InsumoID", oKvp.Key },
                                { "@CantidadUtilizada", oKvp.Value }
                            };

                        oDatos.Escribir("stpServiciosInsumos_I_X_ServicioID_InsumoID_CantidadUtilizada", Hdatos);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar o actualizar el servicio con sus insumos y profesionales.", ex);
            }
        }

        public DataTable ObtenerServicios()
        {
            try
            {
                Hdatos = new Hashtable();
                return oDatos.Leer("ObtenerServicios", Hdatos);
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

        public bool EliminarServicio(int ServicioID)
        {
            try
            {
                Hdatos = new Hashtable
                {
                    { "@ServicioID", ServicioID }
                };
                return oDatos.Escribir("BajaServicio", Hdatos);
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
