using BE;
using BLL;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using SERVICES;
using SERVICES.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_INGSOFTWARE
{
    public partial class frmTurnosLogOut : BaseForm
    {
        private int _IdProfesionalSeleccionado = 0;
        private readonly BLLAgenda _bllAgenda = new BLLAgenda();
        private DateTime _fechaSeleccionada = DateTime.MinValue;
        public frmTurnosLogOut()
        {
            InitializeComponent();
        }

        private void frmTurnosLogOut_Load(object sender, EventArgs e)
        {
            ucCalendario.DiaSeleccionado += ucCalendario_DiaSeleccionado;

            dataGridViewHorarios.Columns.Add("Hora", "Hora");
            dataGridViewHorarios.Columns.Add("Estado", "Estado");


            cmbMediosDePago.DisplayMember = "Nombre";
            cmbMediosDePago.ValueMember = "MedioPagoID";
            cmbMediosDePago.DataSource = GeneralService.ObtenerMediosDePago();

            cmbProfesional.DisplayMember = "Nombre";
            cmbProfesional.ValueMember = "ProfesionalID";
            cmbProfesional.DataSource = GeneralService.ListarProfesionales();

            ucCalendario.MesCambiado += (mesTexto) =>
            {
                lblMes.Text = mesTexto;
            };
            lblMes.Text = DateTime.Today.ToString("MMMM yyyy", new System.Globalization.CultureInfo("es-ES"));
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTotalServicios();
        }

        private void cmbProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            var profesionalSeleccionado = cmbProfesional.SelectedItem as BEProfesional;
            if (profesionalSeleccionado == null) return;

            _IdProfesionalSeleccionado = profesionalSeleccionado.ProfesionalID;
            RefrescarHorariosInteligentes();

            // Limpiar la lista
            checkedListBoxServicios.Items.Clear();

            // Cargar con objetos BEServicio
            foreach (var servicio in profesionalSeleccionado.Servicios)
            {
                checkedListBoxServicios.Items.Add(servicio, false);
            }

            // Mostrar Nombre pero conservar el objeto
            checkedListBoxServicios.DisplayMember = "Nombre";

            ActualizarTotalServicios();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ucCalendario.CambiarMes(+1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ucCalendario.CambiarMes(-1);
        }

        private void ucCalendario_DiaSeleccionado(object sender, DateTime dtFechaSeleccionada)
        {
            dataGridViewHorarios.Rows.Clear();
            _fechaSeleccionada = dtFechaSeleccionada;

            RefrescarHorariosInteligentes();
        }


        private void ucCalendario_Load(object sender, EventArgs e)
        {

        }

        private void ucCalendario_Click(object sender, EventArgs e)
        {

        }

        private void RefrescarHorariosInteligentes()
        {
            if (_fechaSeleccionada == DateTime.MinValue) return;
            if (cmbProfesional.SelectedItem == null) return;

            // servicios elegidos
            var serviciosSel = checkedListBoxServicios.CheckedItems
    .Cast<BEServicio>()
    .Select(s => s.ServicioID)
    .ToList();


            dataGridViewHorarios.Rows.Clear();

            // slots desde BLL
            var slots = _bllAgenda.CalcularSlotsDisponibles(_IdProfesionalSeleccionado, _fechaSeleccionada, serviciosSel);

            if (slots.Count == 0)
            {
                dataGridViewHorarios.Rows.Add("-", "No hay horarios disponibles");
                dataGridViewHorarios.Rows[0].DefaultCellStyle.BackColor = Color.Gainsboro;
                return;
            }

            foreach (var s in slots)
            {
                int idx = dataGridViewHorarios.Rows.Add(s.ToString("HH:mm"), "Disponible");
                dataGridViewHorarios.Rows[idx].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void checkedListBoxServicios_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            BeginInvoke(new Action(ActualizarTotalServicios));
        }

        private void ActualizarTotalServicios()
        {
            var serviciosSeleccionados = checkedListBoxServicios.CheckedItems
                .Cast<BEServicio>()
                .ToList();

            if (!serviciosSeleccionados.Any())
            {
                lblTotal.Text = "-";
                return;
            }

            var total = serviciosSeleccionados.Sum(s => s.Precio);
            lblTotal.Text = total.ToString("C2", CultureInfo.CurrentCulture);
        }
    }
}
