using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ABSTRACCION.Contracts;
using BE;
using BLL;
using SERVICES;

namespace TP_INGSOFTWARE
{
    public partial class frmErrorDV : Form
    {
        private BLLDV oBLLDV;
        private List<BEUsuario> usuariosCorruptos;
        IDigitoVerificadorService DigitoVerificadorService = new DigitoVerificadorService();

        public frmErrorDV()
        {
            InitializeComponent();
            oBLLDV = new BLLDV(DigitoVerificadorService);
            CargarUsuariosCorruptos();
        }

        private void CargarUsuariosCorruptos()
        {
            try
            {
                usuariosCorruptos = oBLLDV.ListarUsuariosCorruptos();

                dgvUsuariosCorruptos.DataSource = usuariosCorruptos;
                
                // Configurar columnas
                dgvUsuariosCorruptos.Columns["Id"].Visible = false;
                dgvUsuariosCorruptos.Columns["Clave"].Visible = false;

                // Obtener estadísticas
                var estadisticas = oBLLDV.ObtenerEstadisticasDV();
                
                // Mostrar estadísticas
                lblTotalUsuarios.Text = $"Total de usuarios: {estadisticas["TotalUsuarios"]}";
                lblUsuariosCorruptos.Text = $"Usuarios corruptos: {estadisticas["UsuariosCorruptos"]}";
                lblPorcentajeCorrupcion.Text = $"Porcentaje de corrupción: {estadisticas["PorcentajeCorrupcion"]:F1}%";

                // Validar integridad del sistema
                bool integridadSistema = (bool)estadisticas["SistemaIntegro"];
                lblEstadoSistema.Text = integridadSistema ? "Estado Sistema: INTEGRO" : "Estado Sistema: CORRUPTO";
                lblEstadoSistema.ForeColor = integridadSistema ? Color.Green : Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios corruptos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRepararUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuariosCorruptos.CurrentRow?.DataBoundItem is BEUsuario usuario)
            {
                try
                {
                    //EN CASO DE QUE CONFIRME QUE FUE UN ERROR O X COSA
                    bool exito = oBLLDV.RepararUsuario(usuario);
                    
                    if (exito)
                    {
                        // Actualizar DV del sistema después de reparar usuario
                        bool dvSistemaActualizado = oBLLDV.ActualizarDVSistema();
                        
                        if (dvSistemaActualizado)
                        {
                            MessageBox.Show($"✅ Usuario '{usuario.Usuario}' reparado correctamente.\nNuevo DV: {usuario.DV}\n✅ DV del sistema actualizado.", 
                                "Reparación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"⚠️ Usuario '{usuario.Usuario}' reparado, pero error al actualizar DV del sistema.\nNuevo DV: {usuario.DV}", 
                                "Reparación Parcial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        
                        CargarUsuariosCorruptos();
                    }
                    else
                    {
                        MessageBox.Show($"❌ Error al reparar usuario '{usuario.Usuario}'.", 
                            "Error en Reparación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al reparar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un usuario para reparar.", "Usuario Requerido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRepararTodos_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    $"¿Está seguro que desea reparar todos los {usuariosCorruptos.Count} usuarios corruptos?\nEsta operación puede tomar tiempo.",
                    "Confirmar Reparación Masiva", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;
                    
                    bool exito = oBLLDV.RepararUsuariosCorruptos();
                    
                    Cursor = Cursors.Default;
                    
                    if (exito)
                    {
                        // Actualizar DV del sistema después de reparar todos
                        bool dvSistemaActualizado = oBLLDV.ActualizarDVSistema();
                        
                        if (dvSistemaActualizado)
                        {
                            MessageBox.Show("✅ Todos los usuarios corruptos han sido reparados correctamente.\n✅ DV del sistema actualizado.", 
                                "Reparación Masiva Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("⚠️ Usuarios reparados, pero error al actualizar DV del sistema.", 
                                "Reparación Parcial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("❌ Error al reparar algunos usuarios.", 
                            "Error en Reparación Masiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    CargarUsuariosCorruptos();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show($"Error en reparación masiva: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarUsuariosCorruptos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // Cerrar sesión antes de cerrar el formulario
            CerrarSesion();
            this.Close();
        }

        private void CerrarSesion()
        {
            try
            {
                // Cerrar la sesión actual
                if (BLLSingletonSesion.Instancia.IsLoggedIn())
                {
                    BLLSingletonSesion.Instancia.Logout();
                }
                
                MessageBox.Show("Sesión cerrada. Debe iniciar sesión nuevamente para validar la integridad del sistema.", 
                    "Sesión Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cerrar sesión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmErrorDV_Load(object sender, EventArgs e)
        {

        }

        private void frmErrorDV_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cerrar sesión cuando se cierra el formulario (por cualquier medio)
            CerrarSesion();
        }

        private void btnEliminarUser_Click(object sender, EventArgs e)
        {
            if (dgvUsuariosCorruptos.CurrentRow?.DataBoundItem is BEUsuario usuario)
            {
                try
                {
                    DialogResult result = MessageBox.Show(
                        $"¿Está seguro que desea ELIMINAR permanentemente al usuario '{usuario.Usuario}'?\nEsta acción no se puede deshacer.",
                        "Confirmar Eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Usar BLLUsuario para eliminar
                        BLLUsuario oBLLUsuario = new BLLUsuario(DigitoVerificadorService);
                        bool exito = oBLLUsuario.Baja(usuario);

                        if (exito)
                        {
                            // Actualizar DV del sistema después de eliminar
                            bool dvSistemaActualizado = oBLLDV.ActualizarDVSistema();

                            if (dvSistemaActualizado)
                            {
                                MessageBox.Show($"✅ Usuario '{usuario.Usuario}' eliminado correctamente.\n✅ DV del sistema actualizado.",
                                    "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show($"⚠️ Usuario '{usuario.Usuario}' eliminado, pero error al actualizar DV del sistema.",
                                    "Eliminación Parcial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            CargarUsuariosCorruptos();
                        }
                        else
                        {
                            MessageBox.Show($"❌ Error al eliminar usuario '{usuario.Usuario}'.",
                                "Error en Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un usuario para eliminar.", "Usuario Requerido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
