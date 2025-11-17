using BE;
using SERVICES.Helpers;
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
    public partial class frmJornadaLaboralEdit : BaseForm
    {
        private int _ProfesionalID;
        public frmJornadaLaboralEdit(int ProfesionalID)
        {
            InitializeComponent();
            this._ProfesionalID = ProfesionalID;
        }


        private void CargarDiasSemana()
        {
            chkJornadasProfesional.Items.Clear();

            chkJornadasProfesional.Items.Add("Lunes");      // índice 0 → Día 1
            chkJornadasProfesional.Items.Add("Martes");     // índice 1 → Día 2
            chkJornadasProfesional.Items.Add("Miércoles");  // índice 2 → Día 3
            chkJornadasProfesional.Items.Add("Jueves");     // índice 3 → Día 4
            chkJornadasProfesional.Items.Add("Viernes");    // índice 4 → Día 5
            chkJornadasProfesional.Items.Add("Sábado");     // índice 5 → Día 6
            chkJornadasProfesional.Items.Add("Domingo");    // índice 6 → Día 7
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void frmJornadaLaboralEdit_Load(object sender, EventArgs e)
        {
            CargarDiasSemana();

            var oDtJornadaProfesional = ProfesionalService.ObtenerJornadaLaboralPorProfesionalID(_ProfesionalID);

            // 3️⃣ Recorrer y marcar los días activos
            foreach (DataRow row in oDtJornadaProfesional.Rows)
            {
                int diaSemana = Convert.ToInt32(row["DiaSemanaID"]); // 1=Lunes ... 7=Domingo
                int indice = diaSemana - 1; // porque los índices del CheckedListBox empiezan en 0
                if (indice >= 0 && indice < chkJornadasProfesional.Items.Count)
                {
                    chkJornadasProfesional.SetItemChecked(indice, true);
                }
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                var resultado = MessageBox.Show("Al eliminar una jornada laboral existentes, se cancelarán TODAS las reservas futuras de esa jornada. ¿Desea continuar?", "Confirmar modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if (resultado != DialogResult.Yes)
                {
                    return;
                }

                var oLstIdsJornadas = new List<int>();

                foreach (var JornadaLaboral in chkJornadasProfesional.CheckedItems)
                {
                    oLstIdsJornadas.Add(chkJornadasProfesional.Items.IndexOf(JornadaLaboral) + 1);
                }

                var oDtReservasAfectadas = ProfesionalService.ObtenerReservasAfectadasPorCambioJornada(_ProfesionalID, oLstIdsJornadas);

                if (oDtReservasAfectadas.Rows.Count > 0)
                {
                    foreach (DataRow row in oDtReservasAfectadas.Rows)
                    {
                        var reservaID = Convert.ToInt32(row["ReservaID"]);

                        var oReserva = AgendaService.ObtenerReserva(reservaID);

                        var oEmailHelper = new EmailHelper();
                        oEmailHelper.EnviarCancelacionTurno(oReserva, reservaID);
                    }
                }

                ProfesionalService.GuardarJornadaLaboral(_ProfesionalID, oLstIdsJornadas);

                MessageBox.Show("La jornada laboral se ha guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex.Message);
            }
        }
    }
}

