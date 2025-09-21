using ABSTRACCION.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERVICES
{
    public class GeneralService: IGeneralService
    {
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

    }
}
