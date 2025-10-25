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
            try
            {
                ucCalendario.DiaSeleccionado += ucCalendario_DiaSeleccionado;

                dataGridViewHorarios.Columns.Add("Hora", "Hora");
                dataGridViewHorarios.Columns.Add("Estado", "Estado");

                cmbProfesional.DisplayMember = "Nombre";
                cmbProfesional.ValueMember = "ProfesionalID";
                cmbProfesional.DataSource = GeneralService.ListarProfesionales();

                ucCalendario.MesCambiado += (mesTexto) =>
                {
                    lblMes.Text = mesTexto;
                };

                lblMes.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DateTime.Today.ToString("MMMM yyyy", new System.Globalization.CultureInfo("es-ES")));
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ActualizarTotalServicios();
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }

        private void cmbProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
                    if (!servicio.Nombre.Contains("-"))
                    { servicio.Nombre = string.Format(servicio.Nombre + " - $" + servicio.Precio); }
                    checkedListBoxServicios.Items.Add(servicio, false);
                }

                // Mostrar Nombre pero conservar el objeto
                checkedListBoxServicios.DisplayMember = "Nombre";

                ActualizarTotalServicios();
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ucCalendario.CambiarMes(+1);
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ucCalendario.CambiarMes(-1);
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }

        private void ucCalendario_DiaSeleccionado(object sender, DateTime dtFechaSeleccionada)
        {
            try
            {
                dataGridViewHorarios.Rows.Clear();
                _fechaSeleccionada = dtFechaSeleccionada;

                RefrescarHorariosInteligentes();

            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }

        private void ucCalendario_Load(object sender, EventArgs e)
        {

        }

        private void ucCalendario_Click(object sender, EventArgs e)
        {

        }

        private void RefrescarHorariosInteligentes()
        {
            try
            {

                //Validaciones
                if (_fechaSeleccionada == DateTime.MinValue) return;
                if (cmbProfesional.SelectedItem == null) return;

                // Servicios elegidos
                var oLstServiciosSeleccionados = checkedListBoxServicios.CheckedItems
                    .Cast<BEServicio>()
                    .Select(s => s.ServicioID)
                    .ToList();

                dataGridViewHorarios.Rows.Clear();

                // 2️ Slots disponibles desde AgendaService/BLL en base a profesional, fecha y servicios
                var oLstSlotsDisponibles = AgendaService.CalcularSlotsDisponibles(_IdProfesionalSeleccionado, _fechaSeleccionada, oLstServiciosSeleccionados);

                // 3️ Turnos ocupados (reservas ya tomadas)
                var oLstReservasOcupadas = AgendaService.ObtenerTurnosTomados(_IdProfesionalSeleccionado, _fechaSeleccionada);

                if (oLstSlotsDisponibles.Count == 0)
                {
                    dataGridViewHorarios.Rows.Add("-", "No hay horarios disponibles");
                    dataGridViewHorarios.Rows[0].DefaultCellStyle.BackColor = Color.Gainsboro;
                    return;
                }

                // 4️ Duracion de la reserva actual
                var iDuracionMin = AgendaService.DuracionTotalSeleccionadaMin(oLstServiciosSeleccionados);
                var tsDuracionMin = TimeSpan.FromMinutes(iDuracionMin);

                // 5️ Crear todas las filas, marcando ocupadas en rojo
                foreach (var oDtSlot in oLstSlotsDisponibles)
                {
                    var oDtFinSlot = oDtSlot.Add(tsDuracionMin);
                    bool esOcupado = oLstReservasOcupadas.Any(r => oDtSlot < r.Fin && r.Inicio < oDtFinSlot);

                    int iRowIndex = dataGridViewHorarios.Rows.Add(oDtSlot.ToString("HH:mm"), esOcupado ? "Ocupado" : "Disponible");

                    var oRow = dataGridViewHorarios.Rows[iRowIndex];
                    if (esOcupado)
                    {
                        oRow.DefaultCellStyle.BackColor = Color.LightCoral;
                        oRow.DefaultCellStyle.ForeColor = Color.White;
                        oRow.ReadOnly = true;
                    }
                    else
                    {
                        oRow.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }

                // 6️ Ordenar por hora
                dataGridViewHorarios.Sort(dataGridViewHorarios.Columns["Hora"], ListSortDirection.Ascending);

            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }

        private void checkedListBoxServicios_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                BeginInvoke(new Action(ActualizarTotalServicios));
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }

        private void ActualizarTotalServicios()
        {
            try
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
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            try
            {
                var oLstServicios = checkedListBoxServicios.CheckedItems
                                .Cast<BEServicio>()
                                .ToList();

                if (oLstServicios.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar al menos un servicio.");
                    return;
                }
                if ((!rbEfectivo.Checked && !rbTarjCredito.Checked && !rbTarjDebito.Checked))
                {
                    MessageBox.Show("Debe seleccionar un medio de pago.");
                    return;
                }
                if (_fechaSeleccionada == DateTime.MinValue)
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
                    MedioDePagoID = MedioDePagoSeleccionado(),
                    PrecioTotal = oLstServicios.Sum(x => x.Precio)
                };
                var frmConfirmacion = new frmConfirmacionReserva(oNuevaReserva);

                this.Hide();
                var resultado = frmConfirmacion.ShowDialog();

                if (resultado != DialogResult.OK) { this.Show(); return; }
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }

        private int MedioDePagoSeleccionado()
        {
            if (rbEfectivo.Checked) { return (int)MedioDePagoEnum.Efectivo; }
            else if (rbTarjCredito.Checked) { return (int)MedioDePagoEnum.Credito; }
            else { return (int)MedioDePagoEnum.Debito; }
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                var ofrmInicioSesion = new frmInicioSesion();

                this.Hide();
                var resultado = ofrmInicioSesion.ShowDialog();

                if (resultado != DialogResult.OK) { this.Show(); return; }
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }
    }
}
