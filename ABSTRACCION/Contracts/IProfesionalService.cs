using BE;
using System;
using System.Collections.Generic;
using System.Data;

namespace ABSTRACCION.Contracts
{
    public interface IProfesionalService
    {
        DataTable ObtenerJornadaLaboralPorProfesionalID(int ProfesionalID);
        DataTable ObtenerFranjaHorariaPorJornadaID(int JornadaID);
        DataTable ObtenerReservasAfectadasPorCambioJornada(int Profesional, List<int> DiasSemanaIDs);
        void GuardarJornadaLaboral(int ProfesionalID, List<int> DiasSemanaIDs);
        void GuardarFranjaHoraria(int JornadaID, TimeSpan HoraInicio, TimeSpan HoraFin);
        void EliminarFranjaHoraria(int FranjaID);
        DataTable ObtenerReservasAfectadasPorCambioFranja(int FranjaHorariaID);

    }
}
