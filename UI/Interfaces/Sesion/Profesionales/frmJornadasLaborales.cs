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
    public partial class frmJornadasLaborales : BaseForm
    {
        private Hashtable Hdatos;
        private DataTable dtJornadas;
        private DataTable dtFranjas;

        public frmJornadasLaborales()
        {
            InitializeComponent();
        }

        private void frmFranjasHorarias_Load(object sender, EventArgs e)
        {
            CargarProfesionales();
        }

        private void CargarProfesionales()
        {
            try
            {
                cboProfesional.DisplayMember = "Nombre";
                cboProfesional.ValueMember = "ProfesionalID";
                cboProfesional.DataSource = GeneralService.ListarProfesionales(); ;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar profesionales: " + ex.Message);
            }
        }

        private void cboProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProfesional.SelectedValue is int profesionalID)
                CargarJornadas(profesionalID);
        }

        private void CargarJornadas(int ProfesionalID)
        {
            try
            {
                dgvJornadas.DataSource = ProfesionalService.ObtenerJornadaLaboralPorProfesionalID(ProfesionalID);

                if (dgvJornadas.Columns.Contains("DiaSemanaID"))
                {
                    dgvJornadas.Columns["DiaSemanaID"].Visible = false;
                }

                dgvFranjas.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar jornadas: " + ex.Message);
            }
        }

        private void dgvJornadas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvJornadas.CurrentRow == null) return;
            var jornadaID = (int)dgvJornadas.CurrentRow.Cells["JornadaID"].Value;
            CargarFranjas(jornadaID);
        }

        private void CargarFranjas(int JornadaID)
        {
            try
            {
                dgvFranjas.DataSource = ProfesionalService.ObtenerFranjaHorariaPorJornadaID(JornadaID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar franjas horarias: " + ex.Message);
            }
        }

        private void btnAgregarJornada_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboProfesional.SelectedValue == null) return;

                var ProfesionalID = (int)cboProfesional.SelectedValue;

                using (var frm = new frmJornadaLaboralEdit(ProfesionalID))
                {
                    frm.ShowDialog();
                    CargarJornadas(ProfesionalID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar jornada laboral: " + ex.Message);
            }
        }

        private void btnAgregarFranja_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvJornadas.CurrentRow == null) return;

                var JornadaID = (int)dgvJornadas.CurrentRow.Cells["JornadaID"].Value;
                var ProfesionalID = (int)cboProfesional.SelectedValue;

                using (var frm = new frmFranjaNueva(ProfesionalID, JornadaID))
                {
                    if (frm.ShowDialog() == DialogResult.OK) CargarFranjas(JornadaID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar franja: " + ex.Message);
            }
        }

        private void btnEliminarFranja_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFranjas.CurrentRow == null) return;
                var FranjaID = (int)dgvFranjas.CurrentRow.Cells["FranjaID"].Value;
                var HoraInicio = (TimeSpan)dgvFranjas.CurrentRow.Cells["HoraInicio"].Value;
                var HoraFin = (TimeSpan)dgvFranjas.CurrentRow.Cells["HoraFin"].Value;

                var JornadaID = (int)dgvJornadas.CurrentRow.Cells["JornadaID"].Value;

                if (MessageBox.Show("¿Desea eliminar la franja seleccionada? \n Nota: Al eliminar la franja horaria, se cancelarán TODAS las reservas futuras de esa franja horaria.",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var oDtReservasAfectadas = ProfesionalService.ObtenerReservasAfectadasPorCambioFranja(FranjaID);

                    foreach (DataRow row in oDtReservasAfectadas.Rows)
                    {
                        var reservaID = Convert.ToInt32(row["ReservaID"]);
                        var oReserva = AgendaService.ObtenerReserva(reservaID);

                        AgendaService.ReservaAcciones(reservaID, ReservaAcciones.Cancelada);
                        var oEmailHelper = new EmailHelper();
                        oEmailHelper.EnviarCancelacionTurno(oReserva, reservaID);
                    };
                    
                    ProfesionalService.EliminarFranjaHoraria(FranjaID);

                    MessageBox.Show("La franja horaria se elimino correctamente.", "Exito", MessageBoxButtons.OK);

                    CargarFranjas(JornadaID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar franja: " + ex.Message);
            }
        }

        private void dgvFranjas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFranjas.CurrentRow == null) return;

            var JornadaID = (int)dgvFranjas.CurrentRow.Cells["FranjaID"].Value;

            if (JornadaID != 0)
            {
                btnEliminarFranja.Enabled = true;
            }
        }
    }
}

