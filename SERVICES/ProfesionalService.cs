using ABSTRACCION.Contracts;
using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;

namespace SERVICES
{
    public class ProfesionalService : IProfesionalService
    {
        BLLProveedor oBLLProovedor;
        BLLCategorias oBLLCategoria;
        BLLInsumo oBLLInsumo;
        BLLServicios oBLLServicios;
        BLLProfesional oBLLProfesional;

        public ProfesionalService()
        {
            oBLLProovedor = new BLLProveedor();
            oBLLCategoria = new BLLCategorias();
            oBLLInsumo = new BLLInsumo();
            oBLLServicios = new BLLServicios();
            oBLLProfesional = new BLLProfesional();
        }

        public DataTable ObtenerJornadaLaboralPorProfesionalID(int ProfesionalID)
        {
            return oBLLProfesional.ObtenerJornadaLaboralPorProfesionalID(ProfesionalID);
        }

        public DataTable ObtenerFranjaHorariaPorJornadaID(int JornadaID)
        {
            return oBLLProfesional.ObtenerFranjaHorariaPorJornadaID(JornadaID);
        }

        public DataTable ObtenerReservasAfectadasPorCambioJornada(int ProfesionalID, List<int> DiasSemanaIDs)
        {
            return oBLLProfesional.ObtenerReservasAfectadasPorCambioJornada(ProfesionalID, DiasSemanaIDs);
        }

        public void GuardarJornadaLaboral(int ProfesionalID, List<int> DiasSemanaIDs)
        {
            oBLLProfesional.GuardarJornadaLaboral(ProfesionalID, DiasSemanaIDs);
        }

        public void GuardarFranjaHoraria(int JornadaID, TimeSpan HoraInicio, TimeSpan HoraFin)
        {
            oBLLProfesional.GuardarFranjaHoraria(JornadaID, HoraInicio, HoraFin);
        }

        public DataTable ObtenerReservasAfectadasPorCambioFranja(int FranjaHorariaID)
        {
            return oBLLProfesional.ObtenerReservasAfectadasPorCambioFranja(FranjaHorariaID);
        }

        public void EliminarFranjaHoraria(int FranjaID)
        {
            oBLLProfesional.EliminarFranjaHoraria(FranjaID);
        }

        
    }
}
