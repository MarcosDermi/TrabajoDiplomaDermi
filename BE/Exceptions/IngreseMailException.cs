using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Exceptions
{
    public class IngreseMailException : Exception
    {
        public IngreseMailException() :
            base($"Ingrese un mail para confirmarla reserva.")
        {
        }
    }
}
