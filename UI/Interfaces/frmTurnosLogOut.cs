using BE;
using BLL;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace UI.Interfaces
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
            lblMes.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(
    DateTime.Today.ToString("MMMM yyyy", new System.Globalization.CultureInfo("es-ES"))
);

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

            // 1️⃣ Servicios elegidos
            var serviciosSel = checkedListBoxServicios.CheckedItems
                .Cast<BEServicio>()
                .Select(s => s.ServicioID)
                .ToList();

            dataGridViewHorarios.Rows.Clear();

            // 2️⃣ Slots disponibles desde BLL
            var slotsDisponibles = AgendaService.CalcularSlotsDisponibles(_IdProfesionalSeleccionado, _fechaSeleccionada, serviciosSel);

            // 3️⃣ Turnos ocupados (reservas ya tomadas)
            var reservasOcupadas = AgendaService.ObtenerTurnosTomados(_IdProfesionalSeleccionado, _fechaSeleccionada);
            // 👆 este método debe devolver lista con Inicio y Fin de las reservas

            if (slotsDisponibles.Count == 0)
            {
                dataGridViewHorarios.Rows.Add("-", "No hay horarios disponibles");
                dataGridViewHorarios.Rows[0].DefaultCellStyle.BackColor = Color.Gainsboro;
                return;
            }

            // 4️⃣ Duración de la reserva actual
            var duracionMin = AgendaService.DuracionTotalSeleccionadaMin(serviciosSel);
            var duracion = TimeSpan.FromMinutes(duracionMin);

            // 5️⃣ Crear todas las filas, marcando ocupadas en rojo
            foreach (var slot in slotsDisponibles)
            {
                var finSlot = slot.Add(duracion);
                bool esOcupado = reservasOcupadas.Any(r => slot < r.Fin && r.Inicio < finSlot);

                int rowIdx = dataGridViewHorarios.Rows.Add(slot.ToString("HH:mm"), esOcupado ? "Ocupado" : "Disponible");

                var row = dataGridViewHorarios.Rows[rowIdx];
                if (esOcupado)
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.ReadOnly = true;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }

            // 6️⃣ Ordenar por hora, por si vienen mezclados
            dataGridViewHorarios.Sort(dataGridViewHorarios.Columns["Hora"], ListSortDirection.Ascending);
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

        private void btnReservar_Click(object sender, EventArgs e)
        {
            var oLstServicios = checkedListBoxServicios.CheckedItems
                .Cast<BEServicio>()
                .ToList();
            
            if (oLstServicios.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un servicio.");
                return;
            }
            if(cmbMediosDePago.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un medio de pago.");
                return;
            }
            if(_fechaSeleccionada == DateTime.MinValue)
            {
                MessageBox.Show("Debe seleccionar un día.");
                return;
            }
            if (dataGridViewHorarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un horario.");
                return;
            }

            var horaSeleccionada = TimeSpan.Parse(
                dataGridViewHorarios.SelectedRows[0].Cells["Hora"].Value.ToString()
            );

            var fechaInicio = _fechaSeleccionada.Date.Add(horaSeleccionada);

            var duracionTotal = TimeSpan.FromMinutes(oLstServicios.Sum(s => s.DuracionMin));

            var oNuevaReserva = new BEReserva()
            {
                ProfesionalID = _IdProfesionalSeleccionado,
                FechaInicio = fechaInicio,
                FechaFin = fechaInicio.Add(duracionTotal),
                Cliente = new BEUsuario(),
                Servicios = oLstServicios,
                MedioDePagoID = (int)cmbMediosDePago.SelectedValue,
                PrecioTotal = oLstServicios.Sum(x => x.Precio)
            };
            var frmConfirmacion = new frmConfirmacionReserva(oNuevaReserva);

            this.Hide();
            var resultado = frmConfirmacion.ShowDialog();

            if (resultado != DialogResult.OK) { this.Show(); return; }

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            var ofrmInicioSesion = new frmInicioSesion();

            this.Hide();
            var resultado = ofrmInicioSesion.ShowDialog();

            if (resultado != DialogResult.OK) { this.Show(); return; }
        }
    }
}
