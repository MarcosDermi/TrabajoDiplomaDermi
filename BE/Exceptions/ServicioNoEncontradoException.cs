using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Exceptions
{
    public class ServicioNoEncontradoException : Exception
    {
        public ServicioNoEncontradoException(int iId) :
            base($"El servicio con ID: {iId} solicitado no fue encontrado.")
        {
        }
    }
}
