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
using UI.Interfaces.ReservasLogOut;

namespace UI.Interfaces.Sesion.Menu
{
    public partial class frmMisTurnos : BaseForm
    {
        private BEUsuario _oUsuario;
        private readonly BLLAgenda _bllAgenda = new BLLAgenda();
        private DateTime _fechaSeleccionada = DateTime.MinValue;
        private List<DateTime> _fechasConReservas = new List<DateTime>();
        private int _IdReservaSeleccionada = 0;

        public frmMisTurnos(int iIdUsuario)
        {
            _oUsuario = new BEUsuario { Id = iIdUsuario };
            InitializeComponent();
        }

        private void frmAgendaTurnos_Load(object sender, EventArgs e)
        {
            ucCalendario.DiaSeleccionado += ucCalendario_DiaSeleccionado;

            _oUsuario = GeneralService.ObtenerUsuarioPorUsuarioID(_oUsuario.Id);

            _fechasConReservas = AgendaService.ObtenerFechasConReservasCliente(_oUsuario.Mail, ucCalendario.FechaActual);

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
            if (_oUsuario.Id <= 0) return; // Validación extra

            dataGridViewHorarios.Rows.Clear();

            var reservasOcupadas = AgendaService.ListarReservasClientesPorFechayMail(_oUsuario.Mail, _fechaSeleccionada);

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
                );

                var row = dataGridViewHorarios.Rows[rowIdx];
                row.ReadOnly = true;
            }

            dataGridViewHorarios.Sort(dataGridViewHorarios.Columns["Hora"], ListSortDirection.Ascending);
        }

        private void dataGridViewHorarios_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                grpTurnoSeleccionado.Visible = true;
                var fechaActual = _fechaSeleccionada;
                var oHorarioSeleccionado = dataGridViewHorarios.SelectedCells[0].Value.ToString();

                if (oHorarioSeleccionado.Contains("-"))
                {
                    return;
                }

                var fechaSeleccionadaConHora = DateTime.Parse($"{fechaActual.ToShortDateString()} {oHorarioSeleccionado}");
                var oDtReserva = AgendaService.ObtenerReservaDiaPorFechayMail(_oUsuario.Mail, fechaSeleccionadaConHora);

                _IdReservaSeleccionada = Convert.ToInt32(oDtReserva.Rows[0]["ReservaID"]);
                lblMontoTotal.Text = oDtReserva.Rows[0]["PrecioTotal"].ToString();

                if (oDtReserva.Rows[0]["ReservaAccionID"] != DBNull.Value)
                {
                    foreach (DataRow oDr in oDtReserva.AsEnumerable())
                    {
                        var eReservaAccion = (ReservaAcciones)(int)oDtReserva.Rows[0]["ReservaAccionID"];

                        if ((ReservaAcciones)oDr["ReservaAccionID"] == ReservaAcciones.Cancelada || (ReservaAcciones)oDr["ReservaAccionID"] == ReservaAcciones.CanceladaPorUsuario)
                        {
                            btnCancelarTurno.Enabled = false;
                        }
                        else
                        {
                            btnCancelarTurno.Enabled = true;
                        }
                    }
                }
                else
                {
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
            ucCalendario.MarcarFechasConReservas(AgendaService.ObtenerFechasConReservasCliente(_oUsuario.Mail, ucCalendario.FechaActual));
        }

        private void btnMesAnterior_Click(object sender, EventArgs e)
        {
            ucCalendario.CambiarMes(-1);
            ucCalendario.MarcarFechasConReservas(AgendaService.ObtenerFechasConReservasCliente(_oUsuario.Mail, ucCalendario.FechaActual));
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
                AgendaService.ReservaAcciones(_IdReservaSeleccionada, ReservaAcciones.Atendida);
                MessageBox.Show("Turno confirmado.", "Exito", MessageBoxButtons.OK);
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

                var dgvHorariosSelected = dataGridViewHorarios.SelectedCells[0].Value.ToString();

                if (dgvHorariosSelected.Contains("-"))
                {
                    return;
                }

                var Resultado = MessageBox.Show(
                                    "¿Desea cancelar este turno?\n\n" +
                                    "✔ El horario volverá a estar disponible para que otro cliente lo reserve.\n" +
                                    "✔ Se enviará un email notificando la cancelación.\n\n" + "¿Confirmar cancelación?", "Cancelar turno", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (Resultado == DialogResult.OK)
                {
                    AgendaService.ReservaAcciones(_IdReservaSeleccionada, ReservaAcciones.CanceladaPorUsuario);

                    var oReserva = AgendaService.ObtenerReserva(_IdReservaSeleccionada);

                    var oEmailHelper = new EmailHelper();
                    oEmailHelper.EnviarCancelacionTurno(oReserva, _IdReservaSeleccionada);

                    MessageBox.Show("Turno cancelado.", "Exito", MessageBoxButtons.OK);

                    RefrescarHorariosInteligentes();
                }

            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex.Message);
            }

        }

        private void btnAgendarNuevoTurno_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                frmTurnosLogOut ofrmTurnosLogOut = new frmTurnosLogOut(true);
                ofrmTurnosLogOut.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex.Message);
            }
        }
    }
}
