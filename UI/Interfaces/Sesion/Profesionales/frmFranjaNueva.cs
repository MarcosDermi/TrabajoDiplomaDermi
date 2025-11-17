using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Interfaces.Sesion.Profesionales
{
    public partial class frmFranjaNueva : BaseForm
    {
        public TimeSpan HoraInicio => dtpHoraInicio.Value.TimeOfDay;
        public TimeSpan HoraFin => dtpHoraFin.Value.TimeOfDay;

        private int JornadaID;
        private int ProfesionalID;

        public frmFranjaNueva(int ProfesionalID, int JornadaID)
        {
            InitializeComponent();
            this.JornadaID = JornadaID;
            this.ProfesionalID = ProfesionalID;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (HoraFin <= HoraInicio)
            {
                MessageBox.Show("La hora de fin debe ser mayor que la hora de inicio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var oFranjasExistentes = ProfesionalService.ObtenerFranjaHorariaPorJornadaID(JornadaID);

            foreach (DataRow row in oFranjasExistentes.Rows)
            {
                var horaInicioExistente = ((TimeSpan)row["HoraInicio"]);
                var horaFinExistente = ((TimeSpan)row["HoraFin"]);
                if (HoraInicio < horaFinExistente && HoraFin > horaInicioExistente)
                {
                    MessageBox.Show("La franja horaria se superpone con una franja existente.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            ProfesionalService.GuardarFranjaHoraria(JornadaID, HoraInicio, HoraFin);

            MessageBox.Show("La franja horaria se guardo correctamente.","Exito", MessageBoxButtons.OK);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

