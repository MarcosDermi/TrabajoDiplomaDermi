

using System;

namespace ABSTRACCION.Contracts
{
    public interface ILogErrorsService
    {
        void SaveLogError(Exception ex);
    }
}
