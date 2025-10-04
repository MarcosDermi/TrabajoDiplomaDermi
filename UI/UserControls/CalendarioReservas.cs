using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BE;

namespace UI
{
    namespace ProyectoDiploma
    {
        public partial class CalendarioReservas : UserControl
        {
            private DateTime fechaActual;
            private Dictionary<DateTime, List<BEReserva>> reservas;
            private Label lblDiaSeleccionado;
            public event Action<string> MesCambiado;

            public CalendarioReservas()
            {
                this.Dock = DockStyle.Fill;
                fechaActual = DateTime.Today;
                reservas = new Dictionary<DateTime, List<BEReserva>>();
                DibujarCalendario();
            }

            private void DibujarCalendario()
            {
                this.Controls.Clear();
                var layout = new TableLayoutPanel
                {
                    RowCount = 6,
                    ColumnCount = 7,
                    Dock = DockStyle.Fill,
                    CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
                };

                DateTime primerDiaMes = new DateTime(fechaActual.Year, fechaActual.Month, 1);
                int offset = (int)primerDiaMes.DayOfWeek;
                int diasEnMes = DateTime.DaysInMonth(fechaActual.Year, fechaActual.Month);

                int dia = 1;
                DateTime hoy = DateTime.Today; // 📌 Fecha actual de la PC

                for (int fila = 0; fila < 6; fila++)
                {
                    layout.RowStyles.Add(new RowStyle(SizeType.Percent, 16f));
                    for (int col = 0; col < 7; col++)
                    {
                        if (fila == 0) layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14f));

                        Panel panelDia = new Panel
                        {
                            Dock = DockStyle.Fill,
                            BackColor = Color.White,
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        // Espacios vacíos antes o después de los días válidos
                        if ((fila == 0 && col < offset) || dia > diasEnMes)
                        {
                            layout.Controls.Add(panelDia, col, fila);
                            continue;
                        }

                        DateTime fecha = new DateTime(fechaActual.Year, fechaActual.Month, dia);

                        Label lblDia = new Label
                        {
                            Text = dia.ToString(),
                            Dock = DockStyle.Fill,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = new Font("Segoe UI", 10, FontStyle.Bold),
                            Tag = fecha
                        };


                        if (fecha < hoy)
                        {
                            lblDia.Enabled = false;
                            lblDia.ForeColor = Color.Gray; // opcional, para distinguir
                            lblDia.Cursor = Cursors.Default;
                        }
                        else
                        {
                            lblDia.Cursor = Cursors.Hand;
                            lblDia.Click += (s, e) =>
                            {
                                if (lblDiaSeleccionado != null)
                                {
                                    lblDiaSeleccionado.BackColor = Color.White;
                                    lblDiaSeleccionado.ForeColor = Color.Black;
                                }

                                // 🔹 Nuevo seleccionado
                                lblDia.BackColor = Color.FromArgb(20, 95, 170);
                                lblDia.ForeColor = Color.White; // opcional para contraste
                                lblDiaSeleccionado = lblDia;
                                DiaSeleccionado?.Invoke(this, fecha);
                            };
                        }

                        panelDia.Controls.Add(lblDia);
                        layout.Controls.Add(panelDia, col, fila);
                        dia++;
                    }
                }

                this.Controls.Add(layout);
            }

            // 📌 Evento que dispara el día seleccionado
            public event EventHandler<DateTime> DiaSeleccionado;


            private void BotonDia_Click(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
                DateTime dia = Convert.ToDateTime(btn.Text);
                DiaSeleccionado?.Invoke(this, dia);
            }

            public void CambiarMes(int offset)
            {
                fechaActual = fechaActual.AddMonths(offset);
                MesCambiado?.Invoke(fechaActual.ToString("MMMM yyyy", new System.Globalization.CultureInfo("es-ES")));

                DibujarCalendario();
            }
        }
    }

}
