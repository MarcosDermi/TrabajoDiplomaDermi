using DAL;
using System;


namespace BLL
{
    public class BLLLogsErrors
    {
        DALLogsError oDALLogsError;
        public BLLLogsErrors() 
        { 
            oDALLogsError = new DALLogsError(); 
        }
        public void SaveLogError(Exception ex)
        {
            oDALLogsError.SaveLogError(ex);
        }
    }
}
