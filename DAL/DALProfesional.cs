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
    }

}
