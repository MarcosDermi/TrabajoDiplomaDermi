using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BE;
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

            ConfigurarChart();
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

                CargarChart(oDtReporte);
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex.Message);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvResultados.DataSource == null)
            {
                MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel (*.xlsx)|*.xlsx",
                FileName = "Reporte_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx"
            };

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

        private void ConfigurarChart()
        {
            ChartReport.Series.Clear();
            ChartReport.ChartAreas.Clear();
            ChartReport.Legends.Clear();

            var chartArea = new ChartArea("MainArea")
            {
                AxisX =
                {
                    Title = "Categoría",
                    TitleFont = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold),
                    LabelStyle = { Angle = -45 },
                    MajorGrid = { LineColor = System.Drawing.Color.LightGray }
                },
                AxisY =
                {
                    Title = "Valor",
                    TitleFont = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold),
                    MajorGrid = { LineColor = System.Drawing.Color.LightGray }
                },
                BackColor = System.Drawing.Color.WhiteSmoke
            };

            ChartReport.ChartAreas.Add(chartArea);

            var legend = new Legend("MainLegend")
            {
                Docking = Docking.Top,
                Alignment = System.Drawing.StringAlignment.Center,
                Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Bold)
            };
            ChartReport.Legends.Add(legend);

            ChartReport.BackColor = System.Drawing.Color.White;
            ChartReport.BorderlineColor = System.Drawing.Color.Silver;
            ChartReport.BorderlineDashStyle = ChartDashStyle.Solid;
        }

        private void CargarChart(DataTable dt)
        {
            ChartReport.Series.Clear();

            if (dt == null || dt.Rows.Count == 0)
                return;

            string xMember = dt.Columns[0].ColumnName;
            string yMember = dt.Columns.Count > 1 ? dt.Columns[1].ColumnName : null;

            if (yMember == null)
                return;

            var serie = new Series("Datos")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                Font = new System.Drawing.Font("Segoe UI", 8),
                BorderWidth = 2
            };


            foreach (DataRow row in dt.Rows)
            {
                var xValue = row[xMember]?.ToString();
                if (decimal.TryParse(row[yMember]?.ToString(), out decimal yValue))
                {
                    var pointIndex = serie.Points.AddY(yValue);
                    serie.Points[pointIndex].AxisLabel = xValue;
                    serie.Points[pointIndex].Label = yValue.ToString();
                }
            }


            serie.Palette = ChartColorPalette.SeaGreen;
            serie.LabelForeColor = System.Drawing.Color.Black;

            ChartReport.Series.Add(serie);


            var area = ChartReport.ChartAreas["MainArea"];
            area.AxisX.Interval = 1; 
            area.AxisX.LabelStyle.Angle = -45;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;


            ChartReport.Titles.Clear();
            ChartReport.Titles.Add(new Title("Visualización del Reporte",
                Docking.Top,
                new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold),
                System.Drawing.Color.FromArgb(20, 95, 170)));
        }

    }
}
