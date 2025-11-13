using BE;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static BE.BEReporte;

namespace UI.Interfaces.Sesion.Reporteria
{
    public partial class frmReporteria : BaseForm
    {
        public frmReporteria()
        {
            InitializeComponent();
        }

        private void frmReporteria_Load(object sender, EventArgs e)
        {
            var oLstTipoReporteEnum = Enum.GetValues(typeof(BEReporte.TipoReporteEnum))
                .Cast<BEReporte.TipoReporteEnum>()
                .Select(x => new
                {
                    Valor = x,
                    Descripcion = x.GetDescription()
                })
                .ToList();

            cmbTipoReporte.DataSource = oLstTipoReporteEnum;
            cmbTipoReporte.DisplayMember = "Descripcion";
            cmbTipoReporte.ValueMember = "Valor";
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                var TipoReporteEnum = (TipoReporteEnum)cmbTipoReporte.SelectedValue;
                var FechaDesde = dtpDesde.Value.Date;
                var FechaHasta = dtpHasta.Value.Date;

                var oDtReporte = ReporteriaService.ObtenerReporte(TipoReporteEnum, FechaDesde, FechaHasta);

                dgvResultados.DataSource = oDtReporte;
                lblCantRegistros.Text = oDtReporte.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvResultados.DataSource == null)
            {
                MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = "Reporte_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var wb = new ClosedXML.Excel.XLWorkbook())
                    {
                        var dt = (DataTable)dgvResultados.DataSource;
                        wb.Worksheets.Add(dt, "Reporte");

                        wb.SaveAs(saveFileDialog.FileName);
                    }

                    MessageBox.Show("Reporte exportado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
