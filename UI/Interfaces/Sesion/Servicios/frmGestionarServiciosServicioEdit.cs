using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Interfaces.Sesion.Servicios
{
    public partial class frmGestionarServiciosServicioEdit : BaseForm
    {
        private List<InsumoSeleccionado> _insumosServicio = new List<InsumoSeleccionado>();

        public frmGestionarServiciosServicioEdit()
        {
            InitializeComponent();
        }

        private void btnAgregarInsumo_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofrmGestionarServiciosBusquedaInsumo = new frmGestionarServiciosBusquedaInsumo())
                {
                    this.Hide();
                    if (ofrmGestionarServiciosBusquedaInsumo.ShowDialog() == DialogResult.OK)
                    {
                        var seleccionados = ofrmGestionarServiciosBusquedaInsumo.InsumosSeleccionados;

                        foreach (var insumo in seleccionados)
                        {

                            var existente = _insumosServicio.FirstOrDefault(x => x.InsumoID == insumo.InsumoID);
                            if (existente != null)
                            {

                                existente.CantidadUsar += insumo.CantidadUsar;
                            }
                            else
                            {
                                _insumosServicio.Add(insumo);
                            }
                        }

                        RefrescarGridInsumos();
                    }
                    this.Show();
                }
            }
            catch (Exception ex) { MostrarMensajeError(ex); }
        }


        private void frmGestionarServiciosServicioEdit_Load(object sender, EventArgs e)
        {

            var oLstProfesionales = GeneralService.ListarProfesionales();

            foreach (var Profesional in oLstProfesionales)
            {
                chkLstProfesional.Items.Add(Profesional, false);
            }
            chkLstProfesional.DisplayMember = "Nombre";
        }
        private void RefrescarGridInsumos()
        {
            dgvInsumosServicio.DataSource = null;
            dgvInsumosServicio.DataSource = _insumosServicio;

            dgvInsumosServicio.Columns["InsumoID"].HeaderText = "InsumoID";
            dgvInsumosServicio.Columns["Codigo"].HeaderText = "Código";
            dgvInsumosServicio.Columns["Nombre"].HeaderText = "Nombre";
            dgvInsumosServicio.Columns["CantidadStock"].HeaderText = "Stock";
            dgvInsumosServicio.Columns["CantidadUsar"].HeaderText = "Cantidad a usar";
        }

        private void btnEliminarInsumoAgregado_Click(object sender, EventArgs e)
        {
            if (dgvInsumosServicio.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show("¿Está seguro que desea eliminar el insumo seleccionado?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return;

            // Obtener el ID del insumo seleccionado
            var insumoId = Convert.ToInt32(dgvInsumosServicio.CurrentRow.Cells["InsumoID"].Value);

            // Buscar y eliminar de la lista interna
            var insumoAEliminar = _insumosServicio.FirstOrDefault(i => i.InsumoID == insumoId);
            if (insumoAEliminar != null)
            {
                _insumosServicio.Remove(insumoAEliminar);
            }

            RefrescarGridInsumos();
        }

        private void btnCrearInsumo_Click(object sender, EventArgs e)
        {
            try
            {
                var resultado = MessageBox.Show("¿Está seguro que desea crear el servicio?",
                "Confirmar nuevo servicio",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                if (resultado != DialogResult.Yes)
                {
                    var oServicio = new BEServicio
                    {
                        Nombre = txtNombre.Text,
                        DuracionMin = Convert.ToInt32(txtDuracion.Text),
                        BufferMin = Convert.ToInt32(txtBuffer.Text),
                        Precio = Convert.ToDecimal(txtPrecio.Text),
                    };

                    var oLstProfesionalesAsignados = new List<BEProfesional>();

                    foreach (var item in chkLstProfesional.CheckedItems)
                    {
                        oLstProfesionalesAsignados.Add((BEProfesional)item);
                    }

                    GestionServicioService.GuardarInsumosServicio(oServicio, _insumosServicio, oLstProfesionalesAsignados);
                    MessageBox.Show("El servicio se ha creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }
    }
}
