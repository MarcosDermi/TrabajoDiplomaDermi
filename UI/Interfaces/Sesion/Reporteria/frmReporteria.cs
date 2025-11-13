using BE;
using System;
using System.Linq;
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
    }
}
