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

namespace UI.Interfaces.Sesion.Promociones
{
    public partial class frmGestionarPromociones : BaseForm
    {
        int PromocionID = 0;

        public frmGestionarPromociones()
        {
            InitializeComponent();
        }

        private void btnCrearPromocion_Click(object sender, EventArgs e)
        {
            try
            {
                var respuesta = MessageBox.Show("Desea crear la promocion?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {

                    var oBEPromocion = new BEPromocion()
                    {
                        IdPromocion = PromocionID,
                        Nombre = txtNombre.Text,
                        FechaDesde = dtpFechaDesde.Value,
                        FechaHasta = dtpFechaHasta.Value,
                        Descuento = Convert.ToDecimal(txtDescuento.Text),
                        Activo = chkActivo.Checked
                    };

                    GestionPromocionesService.GuardarPromocion(oBEPromocion);
                    MessageBox.Show("Promocion creada con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvPromociones.DataSource = GestionPromocionesService.BuscarPromocionesPorFiltrosVarios(
                    txtNombreBusqueda.Text,
                    dtpFechaDesdeBusqueda.Value,
                    dtpFechaHastaBusqueda.Value,
                    chkIncluirInactivos.Checked
                    );

                lblCantRegistros.Text = dgvPromociones.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }

        private void dgvPromociones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPromociones.SelectedRows.Count == 1)
            {
                var Insumo = (DataRowView)dgvPromociones.CurrentRow.DataBoundItem;

                PromocionID = Convert.ToInt32(Insumo.Row["PromocionID"]);
                txtNombre.Text = Insumo.Row["Nombre"].ToString();
                txtDescuento.Text = Insumo.Row["Descuento"].ToString();
                chkActivo.Checked = Convert.ToBoolean(Insumo.Row["Activo"]);
                dtpFechaDesde.Value = Convert.ToDateTime(Insumo.Row["FechaDesde"]);
                dtpFechaHasta.Value = Convert.ToDateTime(Insumo.Row["FechaHasta"]);

                btnEliminarPromocion.Enabled = true;
            }
        }

        private void btnEliminarPromocion_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Está seguro que desea eliminar la promocion seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado != DialogResult.Yes)
            {
                return;
            }
            else
            {
                try
                {
                    GestionPromocionesService.EliminarPromocion(PromocionID);
                    MessageBox.Show("Promocion eliminada con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MostrarMensajeError(ex);
                }
            }
        }
    }
}
