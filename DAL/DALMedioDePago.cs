using ABSTRACCION;
using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALMedioDePago : IGestor<BEProveedor>
    {
        Datos oDatos;
        Hashtable Hdatos;

        public DALMedioDePago()
        {
            oDatos = new Datos();
        }

        public bool Baja(BEProveedor Objeto)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            try
            {

                var stpNombre = "GetAllMediosDePago";
                Hdatos = new Hashtable();
                return oDatos.Leer(stpNombre, Hdatos);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BEProveedor GetOne(int iId)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEProveedor Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEProveedor> ListarTodo(bool EsControlCambio, int iIdUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
