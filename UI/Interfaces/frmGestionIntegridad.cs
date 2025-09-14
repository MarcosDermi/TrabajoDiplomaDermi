using ABSTRACCION.Contracts;
using BE;
using BLL;
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
    public partial class frmGestionIntegridad : Form
    {
        private BLLDV oBLLDV;
        private List<BEUsuario> usuarios;
        IDigitoVerificadorService DigitoVerificadorService = new DigitoVerificadorService();

        public frmGestionIntegridad()
        {
            InitializeComponent();
            oBLLDV = new BLLDV(DigitoVerificadorService);
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                usuarios = oBLLDV.ListarUsuariosConDV();
                dgvUsuarios.DataSource = usuarios;
                
                // oCULTO columnas clave
                dgvUsuarios.Columns["Id"].Visible = false;
                dgvUsuarios.Columns["Clave"].Visible = false;
                
                //visuales
                string dvSistema = oBLLDV.ObtenerDVSistema();
                lblDVSistema.Text = $"DV Sistema: {dvSistema}";
                
              
                bool integridadSistema = oBLLDV.ValidarIntegridadSistema();
                lblEstadoSistema.Text = integridadSistema ? "Estado: INTEGRO" : "Estado: CORRUPTO";
                lblEstadoSistema.ForeColor = integridadSistema ? Color.Green : Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnValidarIntegridad_Click(object sender, EventArgs e)
        {
            try
            {
                bool integridadSistema = oBLLDV.ValidarIntegridadSistema();
                
                if (integridadSistema)
                {
                    MessageBox.Show("La integridad del sistema es CORRECTA.\nTodos los datos están intactos.", 
                        "Integridad Validada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Hubo cambios en la BD.\nRevisar.", 
                        "Integridad Comprometida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
                CargarDatos(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar integridad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRecalcularDV_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "¿Está seguro que desea recalcular todos los DV?\n",
                    "Confirmar Recalculo", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;
                    
                    bool exito = oBLLDV.RecalcularTodosLosDV();
                    
                    if (exito)
                    {
                        MessageBox.Show(" Todos los DV han sido recalculados correctamente.", 
                            "Recalculo Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Error al recalcular algunos DV.", 
                            "Error en Recalculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show($"Error al recalcular DV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizarDVSistema_Click(object sender, EventArgs e)
        {
            try
            {
                bool exito = oBLLDV.ActualizarDVSistema();
                
                if (exito)
                {
                    MessageBox.Show("DV del sistema actualizado correctamente.", 
                        "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al actualizar DV del sistema.", 
                        "Error en Actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar DV del sistema: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnValidarUsuarioSeleccionado_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow?.DataBoundItem is BEUsuario usuario)
            {
                try
                {
                    bool esIntegro = oBLLDV.ValidarIntegridadUsuario(usuario);
                    
                    if (esIntegro)
                    {
                        MessageBox.Show($"El usuario '{usuario.Usuario}' está INTEGRO.\nDV almacenado: {usuario.DV}", 
                            "Usuario Integro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string dvCalculado = oBLLDV.CalcularDVUsuario(usuario);
                        MessageBox.Show($"El usuario '{usuario.Usuario}' está CORRUPTO.\nDV almacenado: {usuario.DV}\nDV calculado: {dvCalculado}", 
                            "Usuario Corrupto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al validar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un usuario para validar.", "Usuario Requerido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void frmGestionIntegridad_Load(object sender, EventArgs e)
        {

        }
    }
}
