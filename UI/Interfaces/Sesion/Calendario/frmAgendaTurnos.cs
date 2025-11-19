using BE;
using BLL;
using SERVICES.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UI.Interfaces.Sesion.Calendario
{
    public partial class frmAgendaTurnos : BaseForm
    {
        private int _IdProfesionalSeleccionado;
        private readonly BLLAgenda _bllAgenda = new BLLAgenda();
        private DateTime _fechaSeleccionada = DateTime.MinValue;
        private List<DateTime> _fechasConReservas = new List<DateTime>();
        private int _IdReservaSeleccionada = 0;

        public frmAgendaTurnos(int iIdProfesionalSeleccionado)
        {
            _IdProfesionalSeleccionado = iIdProfesionalSeleccionado;
            InitializeComponent();
        }

        private void frmAgendaTurnos_Load(object sender, EventArgs e)
        {
            ucCalendario.DiaSeleccionado += ucCalendario_DiaSeleccionado;

            _fechasConReservas = AgendaService.ObtenerFechasConReservas(_IdProfesionalSeleccionado, ucCalendario.FechaActual);

            ucCalendario.MarcarFechasConReservas(_fechasConReservas);
            dataGridViewHorarios.Columns.Add("Hora", "Hora");

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
            MostrarDetalleReserva();
        }

        private void MostrarDetalleReserva()
        {
            try
            {
                grpTurnoSeleccionado.Visible = true;
                var fechaActual = _fechaSeleccionada;
                var oHorarioSeleccionado = dataGridViewHorarios.SelectedCells[0].Value.ToString();

                var fechaSeleccionadaConHora = DateTime.Parse($"{fechaActual.ToShortDateString()} {oHorarioSeleccionado}");
                var oDtReserva = AgendaService.ObtenerReservaDiaPorFechayProfesional(_IdProfesionalSeleccionado, fechaSeleccionadaConHora);

                _IdReservaSeleccionada = Convert.ToInt32(oDtReserva.Rows[0]["ReservaID"]);
                lblMontoTotal.Text = oDtReserva.Rows[0]["PrecioTotal"].ToString();

                if (oDtReserva.Rows[0]["ReservaAccionID"] != DBNull.Value)
                {
                    foreach (DataRow oDr in oDtReserva.AsEnumerable())
                    {
                        var eReservaAccion = (ReservaAcciones)(int)oDtReserva.Rows[0]["ReservaAccionID"];

                        if ((ReservaAcciones)oDr["ReservaAccionID"] == ReservaAcciones.Atendida || (ReservaAcciones)oDr["ReservaAccionID"] == ReservaAcciones.Cancelada)
                        {
                            btnAtendido.Enabled = false;
                            btnCancelarTurno.Enabled = false;
                        }
                        else
                        {
                            btnAtendido.Enabled = true;
                            btnCancelarTurno.Enabled = true;
                        }
                    }
                }
                else
                {
                    btnAtendido.Enabled = true;
                    btnCancelarTurno.Enabled = true;
                }

                foreach (DataColumn col in oDtReserva.Columns.Cast<DataColumn>().ToList())
                {
                    if (col.ColumnName != "NombreServicio")
                        oDtReserva.Columns.Remove(col);
                }
                oDtReserva.Columns["NombreServicio"].ColumnName = "Servicios";

                dgvDetalleTurno.DataSource = oDtReserva;
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex.Message);
            }
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

        private void btnAtendido_Click(object sender, EventArgs e)
        {
            var Resultado = MessageBox.Show("Desea marcar como atendido el turno?.", "Confirmar turno atendido", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (Resultado == DialogResult.OK)
            {
                using (var ofrmMedioPago = new frmMedioDePagoReservaAtendida())
                {
                    var dialogResult = ofrmMedioPago.ShowDialog();
                    if (dialogResult != DialogResult.OK)
                    {
                        MessageBox.Show("Debe completar el pago para marcar el turno como atendido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        AgendaService.RegistrarMedioDePagoReserva(_IdReservaSeleccionada, ofrmMedioPago.MedioDePagoSeleccionado);

                        var oLstServiciosID = AgendaService.ObtenerIDsServiciosPorReservaID(_IdReservaSeleccionada);
                        GestionStockService.ActualizarStockInsumoPorServicioID(oLstServiciosID);

                        AgendaService.ReservaAcciones(_IdReservaSeleccionada, ReservaAcciones.Atendida);

                        MessageBox.Show("Turno marcado como atendido.", "Exito", MessageBoxButtons.OK);

                        MostrarDetalleReserva();
                    }
                }
            }

            return;
        }

        private void dgvDetalleTurno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancelarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                var Resultado = MessageBox.Show("Desea marcar como cancelado el turno?.", "Confirmar cancelar turno", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (Resultado == DialogResult.OK)
                {
                    AgendaService.ReservaAcciones(_IdReservaSeleccionada, ReservaAcciones.Cancelada);

                    var oReserva = AgendaService.ObtenerReserva(_IdReservaSeleccionada);

                    var oEmailHelper = new EmailHelper();
                    oEmailHelper.EnviarCancelacionTurno(oReserva, _IdReservaSeleccionada);

                    MessageBox.Show("Turno cancelado.", "Exito", MessageBoxButtons.OK);

                    MostrarDetalleReserva();
                }

            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex.Message);
            }

        }
    }
}
