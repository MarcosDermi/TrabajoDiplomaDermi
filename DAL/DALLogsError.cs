using System;
using System.Collections;

namespace DAL
{
    public class DALLogsError
    {
        Datos oDatos;
        Hashtable Hdatos;

        public DALLogsError()
        {
            oDatos = new Datos();
        }

        public void SaveLogError(Exception ex)
        {
            try
            {
                Hdatos = new Hashtable();
                Hdatos.Add("@ExceptionType", ex.GetType());
                Hdatos.Add("@Message", ex.Message);
                Hdatos.Add("@Source", ex.Source);

                oDatos.Escribir("SaveLogError", Hdatos);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }

}
