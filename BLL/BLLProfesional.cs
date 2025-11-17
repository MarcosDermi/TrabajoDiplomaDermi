using ABSTRACCION;
using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLL
{
    public class BLLProfesional : IGestor<BEProfesional>
    {
        DALProfesional oDALProfesional;
        DALAgenda oDALAgenda;

        public BLLProfesional()
        {
            oDALProfesional = new DALProfesional();
            oDALAgenda = new DALAgenda();
        }

        public bool Baja(BEProfesional Objeto)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            return oDALProfesional.GetAll();
        }

        public BEProfesional GetOne(int iId)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEProfesional Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEProfesional> ListarTodo(bool EsControlCambio, int iIdUsuario)
        {
            return oDALProfesional.ListarTodo(EsControlCambio, iIdUsuario);
        }

        public List<BETurnoTomado> GetTurnosTomados(int iProfesionalID, DateTime dtFecha)
        {
            return oDALProfesional.ListarReservasPorFecha(iProfesionalID, dtFecha);
        }

        public bool BajaID(int iId)
        {
            throw new NotImplementedException();
        }

        public BEProfesional ObtenerProfesionalPorUsuarioID(int iUsuarioID)
        {
            return oDALProfesional.ObtenerProfesionalPorUsuarioID(iUsuarioID);
        }

        public DataTable ObtenerJornadaLaboralPorProfesionalID(int ProfesionalID)
        {
            return oDALProfesional.ObtenerJornadasLaboralesPorProfesionalID(ProfesionalID);
        }

        public DataTable ObtenerFranjaHorariaPorJornadaID(int JornadaID)
        {
            return oDALProfesional.ObtenerFranjaHorariaPorJornadaID(JornadaID);
        }

        public DataTable ObtenerReservasAfectadasPorCambioJornada(int ProfesionalID, List<int> oLstDiasSemana)
        {
            var oLstDiasActuales = oDALProfesional.ObtenerDiasSemanaPorProfesional(ProfesionalID);
            var oLstDiasSemanasEliminados = oLstDiasActuales.Except(oLstDiasSemana).ToList();

            return oDALAgenda.ObtenerReservasAfectadasPorCambioJornada(ProfesionalID, oLstDiasSemanasEliminados);
        }

        public void GuardarJornadaLaboral(int profesionalID, List<int> oLstDiasSemana)
        {
            // 1️⃣ Obtener los días actuales de la BD
            var oLstDiasActuales = oDALProfesional.ObtenerDiasSemanaPorProfesional(profesionalID);

            // 2️⃣ Calcular diferencias
            var oLstDiasSemanasAgregados = oLstDiasSemana.Except(oLstDiasActuales).ToList();
            var oLstDiasSemanasEliminados = oLstDiasActuales.Except(oLstDiasSemana).ToList();

            // 3️⃣ Si hay días eliminados → verificar reservas confirmadas
            if (oLstDiasSemanasEliminados.Any())
            {
                // Llamamos a un SP que nos devuelve las reservas afectadas
                var oDtReservasAfectadas = oDALAgenda.ObtenerReservasAfectadasPorCambioJornada(profesionalID, oLstDiasSemanasEliminados);

                // Si hay reservas confirmadas → cancelarlas
                foreach (DataRow row in oDtReservasAfectadas.Rows)
                {
                    int reservaID = (int)row["ReservaID"];
                    oDALAgenda.ReservaAcciones(reservaID, ReservaAcciones.Cancelada);
                }
            }

            // 4️⃣ Actualizar jornadas en base a los nuevos días
            oDALProfesional.ActualizarJornadasProfesional(profesionalID, oLstDiasSemana);
        }

        public void GuardarFranjaHoraria(int JornadaID, TimeSpan HoraInicio, TimeSpan HoraFin)
        {
            oDALProfesional.GuardarFranjaHoraria(JornadaID, HoraInicio, HoraFin);
        }

        public DataTable ObtenerReservasAfectadasPorCambioFranja(int FranjaHorariaID)
        {
            return oDALProfesional.ObtenerReservasAfectadasPorCambioFranja(FranjaHorariaID);
        }

        public void EliminarFranjaHoraria(int FranjaID)
        {
            oDALProfesional.EliminarFranjaHoraria(FranjaID);
        }
    }
}
