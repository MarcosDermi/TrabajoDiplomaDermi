using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABSTRACCION.Contracts
{
    public interface IGeneralService
    {
        DataTable LimpiarDataTable(DataTable oDt);
        void EsconderColumna(DataGridView oDgv, string sNombreColumna);
    }
}
