using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class DALProfesionalServicio
    {
        Datos oDatos;
        Hashtable Hdatos;

        public DALProfesionalServicio()
        {
            oDatos = new Datos();
        }

        public List<int> ObtenerServiciosDeProfesional(int iProfesionalID)
        {
            var oLstServiciosProfesional = new List<int>();

            try
            {
                var stpNombre = "ListarServiciosDeProfesional";
                Hdatos = new Hashtable
                {
                    { "@ProfesionalID", iProfesionalID }
                };

                var oDtServiciosProfesional = oDatos.Leer(stpNombre, Hdatos);

                oLstServiciosProfesional = oDtServiciosProfesional.AsEnumerable()
                    .Select(row => (int)row["ServicioID"])
                    .ToList();

                return oLstServiciosProfesional;
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
