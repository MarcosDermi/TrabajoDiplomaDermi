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
        void GuardarInsumosServicio(BEServicio oBEServicio, List<InsumoSeleccionado> oLstInsumos, List<int> oLstProfesionalesAsignadosIds);
        BEServicio ObtenerServicio(int ServicioID);
        DataTable ObtenerProfesionalServicioPorServicioID(int ServicioID);
        DataTable ObtenerServicios();
        bool EliminarServicio(int ServicioID);
    }
}
