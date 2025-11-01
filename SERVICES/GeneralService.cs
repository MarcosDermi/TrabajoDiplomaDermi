using ABSTRACCION.Contracts;
using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERVICES
{
    public class GeneralService : IGeneralService
    {
        IDigitoVerificadorService DigitoVerificadorService = new DigitoVerificadorService();
        BLLMedioDePago oBLLMedioDePago;
        BLLProfesional oBLLProfesional;
        BLLUsuario oBLLUsuario;

        public GeneralService()
        {
            oBLLMedioDePago = new BLLMedioDePago();
            oBLLProfesional = new BLLProfesional();
            oBLLUsuario = new BLLUsuario(DigitoVerificadorService);
        }

        public DataTable LimpiarDataTable(DataTable oDt)
        {
            if (oDt.Columns.Contains("Deleted"))
            {
                oDt.Columns.Remove("Deleted");
            }

            if (oDt.Columns.Contains("RazonSocial"))
            {
                oDt.Columns["RazonSocial"].ColumnName = "Razon Social";
            }

            return oDt;
        }

        public void EsconderColumna(DataGridView oDgv, string sNombreColumna)
        {
            if (oDgv.Columns.Contains(sNombreColumna))
            {
                oDgv.Columns[sNombreColumna].Visible = false;
            }
        }

        public DataTable ObtenerMediosDePago()
        {
            return oBLLMedioDePago.GetAll();
        }

        public List<BEProfesional> ListarProfesionales()
        {
            return oBLLProfesional.ListarTodo(false, 0);
        }

        public BEProfesional ObtenerProfesionalPorUsuarioID(int UsuarioID)
        {
            return oBLLProfesional.ObtenerProfesionalPorUsuarioID(UsuarioID);
        }

        public BEUsuario ObtenerUsuarioPorUsuarioID(int UsuarioID)
        {
            return oBLLUsuario.GetOne(UsuarioID);
        }
    }
}
