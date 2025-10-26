using BE;
using System;
using System.Collections.Generic;
using System.Data;

namespace ABSTRACCION.Contracts
{
    public interface IGestionServicioService
    {
        DataTable ObtenerServiciosPorProfesional(int ProfesionalID);
        DataTable ObtenerObtenerInsumosPorServicio(int ServicioID);
    }
}
