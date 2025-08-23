using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;

namespace DAL
{
    public class Datos
    {
        private SqlConnection oCnn = new SqlConnection(ConfigurationManager.ConnectionStrings["IS"].ConnectionString);

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
            oCnn.Open();
            SqlTransaction oSQLTrans;
            oCmd = new SqlCommand(stpNombre, oCnn);
            oCmd.CommandType = CommandType.StoredProcedure;

            oSQLTrans = oCnn.BeginTransaction();

            try
            {
                if (HDatos != null)
                {
                    foreach (string oDato in HDatos.Keys)
                    {
                        oCmd.Parameters.AddWithValue(oDato, HDatos[oDato]);
                    }
                }
                oCmd.Transaction = oSQLTrans;
                int Respuesta = oCmd.ExecuteNonQuery();
                oSQLTrans.Commit();
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
