using BE;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
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

namespace TP_INGSOFTWARE
{
    public partial class frmTurnosLogOut : BaseForm
    {
        public frmTurnosLogOut()
        {
            InitializeComponent();
        }


        private void Calendario_DiaSeleccionado(object sender, DateTime fecha)
        {
            dataGridViewHorarios.Rows.Clear();

            // Ejemplo de horarios fijos
            var horarios = new List<string> { "09:00", "10:00", "11:00", "12:00", "13:00" };

            foreach (var hora in horarios)
            {
                dataGridViewHorarios.Rows.Add(hora, "Disponible");
            }
        }

        private void frmTurnosLogOut_Load(object sender, EventArgs e)
        {
            calendario.DiaSeleccionado += Calendario_DiaSeleccionado;

            dataGridViewHorarios.Columns.Add("Hora", "Hora");
            dataGridViewHorarios.Columns.Add("Estado", "Estado");


            cmbMediosDePago.DisplayMember = "Nombre";
            cmbMediosDePago.ValueMember = "MedioPagoID";
            cmbMediosDePago.DataSource = GeneralService.ObtenerMediosDePago();

            cmbProfesional.DisplayMember = "Nombre";
            cmbProfesional.ValueMember = "ProfesionalID";
            cmbProfesional.DataSource = GeneralService.ListarProfesionales();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el profesional seleccionado
            var profesionalSeleccionado = cmbProfesional.SelectedItem as BEProfesional;

            if (profesionalSeleccionado != null)
            {
                // Limpiar la lista de servicios
                checkedListBoxServicios.Items.Clear();

                // Agregar los servicios del profesional
                foreach (var servicio in profesionalSeleccionado.Servicios)
                {
                    checkedListBoxServicios.Items.Add(servicio.Nombre);
                }
            }
        }
    }
}
