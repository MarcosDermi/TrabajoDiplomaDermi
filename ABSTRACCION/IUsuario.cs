

using System;
using System.Collections.Generic;

namespace ABSTRACCION
{
    public interface IUsuario
    {
        int Id { get; set; }
        string Usuario { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        string Mail { get; set; }
        string Clave { get; set; }
        int DNI { get; set; }
        DateTime FechaNac { get; set; }
        bool isAdmin { get; set; }

    }
}
