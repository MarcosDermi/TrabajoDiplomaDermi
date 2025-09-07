using BLL;
using SERVICES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialDesignThemes;

namespace TP_INGSOFTWARE
{
    public partial class frmGestionBitacoras : Form
    {
        public frmGestionBitacoras()
        {
            InitializeComponent();
            oBLLBitacora = new BLLBitacora();
        }

        BLLBitacora oBLLBitacora;

        private void button1_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = string.Empty;
            var dtFechaDesde = dtpFechaDesde.Value;
            var dtFechaHasta = dtpFechaHasta.Value;
            var iTipoBitacora = (int)cmbTipoBitacoraEnum.SelectedValue;
        }

        private void frmGestionBitacoras_Load(object sender, EventArgs e)
        {
            dgvBitacoras.DefaultCellStyle.ForeColor = Color.Black;
            dgvBitacoras.DataSource = oBLLBitacora.BuscarBitacoraPorFiltrosVarios(null, null, null, null);
            dgvBitacoras.Columns["BitacoraTipoID"].Visible = false;
            //cmbTipoBitacoraEnum.DataSource = Enum.GetValues(typeof(TipoBitacoraEnum));
            CargarCombo();
        }

        private void CargarCombo()
        {
            var items = Enum.GetValues(typeof(TipoBitacoraEnum))
                                        .Cast<TipoBitacoraEnum>()
                                        .Select(e => new EnumItem<TipoBitacoraEnum>
        {
        Valor = e,
        Descripcion = e.GetDescription()
        })
    .   ToList();

            cmbTipoBitacoraEnum.DataSource = items;
            cmbTipoBitacoraEnum.DisplayMember = "Descripcion";
            cmbTipoBitacoraEnum.ValueMember = "Valor";

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var sNombreUsuario = txtUsuario.Text;
            var dtFechaDesde = dtpFechaDesde.Value.Date.AddHours(0).AddMinutes(0).AddSeconds(0);
            var dtFechaHasta = dtpFechaHasta.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            var iTipoBitacora = (int)cmbTipoBitacoraEnum.SelectedValue;

            dgvBitacoras.DataSource = oBLLBitacora.BuscarBitacoraPorFiltrosVarios(sNombreUsuario, dtFechaDesde, dtFechaHasta, iTipoBitacora);
        }
    }
    public class EnumItem<T>
    {
        public string Descripcion { get; set; }
        public T Valor { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
