using ABSTRACCION.Contracts;
using System;
using BLL;

namespace SERVICES
{
    public class LogErrorsService: ILogErrorsService
    {
        public void SaveLogError(Exception ex)
        {
            var oBLLLogsError = new BLLLogsErrors();
            oBLLLogsError.SaveLogError(ex);
        }
    }
}
