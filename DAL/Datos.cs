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

        public bool Escribir(string stpNombre, Hashtable HDatos, out int idGenerado, bool devuelveIdGenerado = false, string outputParamName = "@IdGenerado")
        {
            idGenerado = 0;
            oCnn.Open();
            var oSQLTrans = oCnn.BeginTransaction();

            try
            {
                using (var cmd = new SqlCommand(stpNombre, oCnn, oSQLTrans))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (HDatos != null)
                    {
                        foreach (DictionaryEntry kv in HDatos)
                            cmd.Parameters.AddWithValue((string)kv.Key, kv.Value ?? DBNull.Value);
                    }

                    SqlParameter outParam = null;
                    if (devuelveIdGenerado)
                    {
                        outParam = new SqlParameter(outputParamName, SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outParam);
                    }

                    cmd.ExecuteNonQuery();
                    oSQLTrans.Commit();

                    if (devuelveIdGenerado && outParam?.Value != DBNull.Value)
                        idGenerado = Convert.ToInt32(outParam.Value);

                    return true;
                }
            }
            catch
            {
                oSQLTrans.Rollback();
                throw;
            }
            finally
            {
                oCnn.Close();
            }
        }




    }
}
