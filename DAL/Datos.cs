using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;

namespace DAL
{
    public class Datos
    {
        //Server=tcp:trabajodiplomaserver.database.windows.net,1433;Initial Catalog=TrabajoDiploma;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication="Active Directory Default";
        //Server=tcp:trabajodiplomaserver.database.windows.net,1433;Initial Catalog=TrabajoDiploma;Persist Security Info=False;User ID=MarcosDermi;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
        private SqlConnection oCnn = new SqlConnection(ConfigurationManager.ConnectionStrings["TD"].ConnectionString);

        SqlCommand oCmd;

        public DataTable Leer(string stpNombre, Hashtable oDatos)
        {
            DataTable oDataTable = new DataTable();
            SqlDataAdapter oDa;
            oCmd = new SqlCommand(stpNombre, oCnn);
            oCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                oDa = new SqlDataAdapter(oCmd);
                if (oDatos != null)
                {
                    foreach (string oDato in oDatos.Keys)
                    {
                        oCmd.Parameters.AddWithValue(oDato, oDatos[oDato]);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            oDa.Fill(oDataTable);
            return oDataTable;
        }

        public bool Escribir(string stpNombre, Hashtable HDatos)
        {
            int dummy;
            return Escribir(stpNombre, HDatos, out dummy);
        }

        public bool Escribir(string stpNombre, Hashtable HDatos, out int idGenerado)
        {
            oCnn.Open();
            SqlTransaction oSQLTrans;
            oCmd = new SqlCommand(stpNombre, oCnn);
            oCmd.CommandType = CommandType.StoredProcedure;

            oSQLTrans = oCnn.BeginTransaction();
            idGenerado = 0;
            try
            {
                if (HDatos != null)
                {
                    foreach (string oDato in HDatos.Keys)
                    {
                        oCmd.Parameters.AddWithValue(oDato, HDatos[oDato]);
                    }
                }

                if (!oCmd.Parameters.Contains("@IdGenerado"))
                {
                    var paramId = new SqlParameter("@IdGenerado", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    oCmd.Parameters.Add(paramId);
                }

                oCmd.Transaction = oSQLTrans;
                int Respuesta = oCmd.ExecuteNonQuery();
                oSQLTrans.Commit();

                if (oCmd.Parameters["@IdGenerado"].Value != DBNull.Value) 
                { idGenerado = Convert.ToInt32(oCmd.Parameters["@IdGenerado"].Value); }
                    

                return true;
            }
            catch (SqlException ex)
            {
                oSQLTrans.Rollback();
                throw ex;
            }
            catch (Exception ex) 
            {
                oSQLTrans.Rollback();
                throw ex;
            }
            finally { oCnn.Close(); } 
        }



    }
}
