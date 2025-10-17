using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ABSTRACCION;
using BE;

namespace BLL
{
    public class BLLProfesional : IGestor<BEProfesional>
    {
        DALProfesional oDALProfesional;

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
    }
}
