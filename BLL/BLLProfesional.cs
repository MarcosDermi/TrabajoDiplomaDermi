using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE.ClasesMultiLenguaje;
using ABSTRACCION;
using BE;
using System.Runtime.Remoting.Messaging;

namespace BLL
{
    public class BLLProfesional : IGestor<BEProfesional>
    {
        DALProfesional oDALProfesional;
        private readonly Dictionary<int, List<BEJornadaLaboral>> _dicAgenda = new Dictionary<int, List<BEJornadaLaboral>>();

        public BLLProfesional()
        {
            oDALProfesional = new DALProfesional();
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

        public void InitAgendaEjemplo()
        {
            foreach (var profId in _dicAgenda.Keys)
            {
                var lista = new List<BEJornadaLaboral>();
                for (int i = 1; i <= 6; i++) // Lunes a Sábado
                {
                    lista.Add(new BEJornadaLaboral
                    {
                        Dia = (DayOfWeek)i,
                        Franjas = new List<BEFranja>
                    {
                        new BEFranja{ Inicio=DateTime.Today.AddHours(10), Fin=DateTime.Today.AddHours(13) },
                        new BEFranja{ Inicio=DateTime.Today.AddHours(14), Fin=DateTime.Today.AddHours(19) },
                    }
                    });
                }
                _dicAgenda[profId] = lista;
            }
        }

        public List<BETurnoTomado> GetTurnosTomados(int iProfesionalID, DateTime dtFecha)
        {
            return oDALProfesional.ListarReservasPorFecha(iProfesionalID, dtFecha);
        }

        public bool BajaID(int iId)
        {
            throw new NotImplementedException();
        }
    }
}
