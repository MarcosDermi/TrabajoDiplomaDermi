using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace UI
{
    public partial class frmAgendaTurnos : BaseForm
    {
        private int _IdProfesionalSeleccionado = 1;
        private readonly BLLAgenda _bllAgenda = new BLLAgenda();
        private DateTime _fechaSeleccionada = DateTime.MinValue;
        private List<DateTime> _fechasConReservas = new List<DateTime>();

        public frmAgendaTurnos()
        {
            InitializeComponent();
        }

        private void frmAgendaTurnos_Load(object sender, EventArgs e)
        {
            ucCalendario.DiaSeleccionado += ucCalendario_DiaSeleccionado;

            _fechasConReservas = AgendaService.ObtenerFechasConReservas(_IdProfesionalSeleccionado, ucCalendario.FechaActual);

            ucCalendario.MarcarFechasConReservas(_fechasConReservas);
            dataGridViewHorarios.Columns.Add("Hora", "Hora");
            dataGridViewHorarios.Columns.Add("Estado", "Estado");

            ucCalendario.MesCambiado += (mesTexto) =>
            {
                lblMes.Text = mesTexto;
            };
            lblMes.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DateTime.Today.ToString("MMMM yyyy", new System.Globalization.CultureInfo("es-ES")));
        }

        private void ucCalendario_DiaSeleccionado(object sender, DateTime dtFechaSeleccionada)
        {
            dataGridViewHorarios.Rows.Clear();
            _fechaSeleccionada = dtFechaSeleccionada;

            RefrescarHorariosInteligentes();
        }
       

        private void RefrescarHorariosInteligentes()
        {
            if (_fechaSeleccionada == DateTime.MinValue) return;
            if (_IdProfesionalSeleccionado <= 0) return; // Validación extra

            dataGridViewHorarios.Rows.Clear();

            var reservasOcupadas = AgendaService.ObtenerTurnosTomados(_IdProfesionalSeleccionado, _fechaSeleccionada);

            if (reservasOcupadas == null || reservasOcupadas.Count == 0)
            {
                dataGridViewHorarios.Rows.Add("-", "Sin turnos reservados");
                dataGridViewHorarios.Rows[0].DefaultCellStyle.BackColor = Color.Gainsboro;
                return;
            }

            foreach (var reserva in reservasOcupadas.OrderBy(r => r.Inicio))
            {
                var rowIdx = dataGridViewHorarios.Rows.Add(
                    reserva.Inicio.ToString("HH:mm")
                    //$"Cliente: {reserva.} - Servicio: {reserva.ServicioNombre}"
                );

                var row = dataGridViewHorarios.Rows[rowIdx];
                row.ReadOnly = true;
            }

            dataGridViewHorarios.Sort(dataGridViewHorarios.Columns["Hora"], ListSortDirection.Ascending);
        }

        private void dataGridViewHorarios_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            grpTurnoSeleccionado.Visible = true;





        }

        private void btnMesSiguiente_Click(object sender, EventArgs e)
        {
            ucCalendario.CambiarMes(+1);
            ucCalendario.MarcarFechasConReservas(AgendaService.ObtenerFechasConReservas(_IdProfesionalSeleccionado, ucCalendario.FechaActual));

        }

        private void btnMesAnterior_Click(object sender, EventArgs e)
        {
            ucCalendario.CambiarMes(-1);
            ucCalendario.MarcarFechasConReservas(AgendaService.ObtenerFechasConReservas(_IdProfesionalSeleccionado, ucCalendario.FechaActual));

        }

        private void ucCalendario_Load(object sender, EventArgs e)
        {

        }

        private void ucCalendario_Click(object sender, EventArgs e)
        {

        }
    }
}
