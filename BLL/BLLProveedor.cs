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
    public class BLLProveedor: IGestor<BEProveedor>
    {
        DALProveedor oDALProveedor;

        public BLLProveedor()
        {
            oDALProveedor = new DALProveedor();
        }

        public bool Baja(BEProveedor Objeto)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            return oDALProveedor.GetAll();
        }

        public BEProveedor GetOne(int iId)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEProveedor Objeto)
        {
            return oDALProveedor.Guardar(Objeto);
        }

        public List<BEProveedor> ListarTodo(bool EsControlCambio, int iIdUsuario)
        {
            throw new NotImplementedException();
        }

        public DataTable BuscarProveedoresPorFiltrosVarios(string sCodigo, string sNombre, string sRazonSocial)
        {
            return oDALProveedor.BuscarProveedoresPorFiltrosVarios(sCodigo, sNombre, sRazonSocial);
        }

        public bool BajaID(int iId)
        {
            return oDALProveedor.BajaID(iId);
        }
    }
}
