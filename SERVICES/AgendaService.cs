using BE;
using BLL;
using SERVICES.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace SERVICES
{
    public class AgendaService : IAgendaService
    {
        BLLProfesional oBLLProfesional;

        public AgendaService()
        {
            oBLLProfesional = new BLLProfesional();
        }

        public List<BETurnoTomado> ObtenerTurnosTomados(int iProfesionalID, DateTime dtFecha)
        {
            return oBLLProfesional.GetTurnosTomados(iProfesionalID, dtFecha);
        }
    }
}
