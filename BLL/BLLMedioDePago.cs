using ABSTRACCION;
using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLMedioDePago : IGestor<BEMedioDePago>
    {

        DALMedioDePago oDALMedioDePago;

        public BLLMedioDePago()
        {
            oDALMedioDePago = new DALMedioDePago();
        }

        public bool Baja(BEMedioDePago Objeto)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            return oDALMedioDePago.GetAll();
        }

        public BEMedioDePago GetOne(int iId)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEMedioDePago Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEMedioDePago> ListarTodo(bool EsControlCambio, int iIdUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
