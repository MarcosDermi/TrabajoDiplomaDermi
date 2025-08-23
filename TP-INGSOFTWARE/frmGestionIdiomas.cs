using BLL;
using SERVICES;
using BE.ClasesMultiLenguaje;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace TP_INGSOFTWARE
{
    public partial class frmGestionIdiomas : Form,IdiomaObserver
    {
        public frmGestionIdiomas()
        {
            InitializeComponent();
            oValidators = new Validators();
            oBLLTraductor = new BLLTraductor();
        }
        Validators oValidators;
        Idioma oIdioma;
        BLLTraductor oBLLTraductor;
        Palabra oPalabra;
        Traduccion oTraduccion;
        public void CambiarIdioma(Idioma Idioma)
        {
            
        }

        private void frmGestionIdiomas_Load(object sender, EventArgs e)
        {
            Observer.agregarObservador(this);
            ListarIdiomas();
            CargarPalabras();
            EstilizarDataGridView();
        }

        private void EstilizarDataGridView()
        {
            dgvTraducciones.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(63, 47, 81);
            dgvTraducciones.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            
            dgvTraducciones.RowsDefaultCellStyle.BackColor = Color.White;
            dgvTraducciones.RowsDefaultCellStyle.ForeColor = Color.Black;
          
            dgvTraducciones.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumPurple;
            dgvTraducciones.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTraducciones.EnableHeadersVisualStyles = false;
           
            dgvTraducciones.DefaultCellStyle.SelectionBackColor = Color.DarkSlateBlue;
            dgvTraducciones.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvTraducciones.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvTraducciones.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }
        void CargarPalabras()
        {
            cbPalabras.DataSource = null;
            cbPalabras.DataSource = oBLLTraductor.obtenerPalabras();
        }

        void CargarTraducciones()
        {
            if (cmbIdioma.SelectedItem!=null)
            {

                var oIdioma = (Idioma)cmbIdioma.SelectedItem;

                var DataTraducciones= oBLLTraductor.obtenertraducciones(oIdioma);

                var listaParaGrid = DataTraducciones
                .Select(kvp => new { Español = kvp.Key, Traduccion = kvp.Value.texto})
                .ToList();

                dgvTraducciones.DataSource = null;
                dgvTraducciones.DataSource = listaParaGrid;
            }
            
        }

        private void ListarIdiomas()
        {
            try
            {
                BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
                var ListaIdiomas = Traductor.ObtenerIdiomas();

                // Filtrar para excluir el idioma español
                var ListaIdiomasFiltrada = ListaIdiomas.Where(i => i.Nombre.ToLower() != "español").ToList();

                cmbIdioma.DataSource = null;
                cmbIdioma.DisplayMember = "Nombre"; 
                cmbIdioma.ValueMember = "ID";      
                cmbIdioma.DataSource = ListaIdiomasFiltrada;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!oValidators.validarPalabra(txtNombreIdioma.Text))
                {
                    throw new ArgumentException("No existe idioma de una 0 o 1 letra, por favor verificar.");
                }
                oIdioma = new Idioma();
                oIdioma.Nombre = txtNombreIdioma.Text;
                oIdioma.Default = false;

                if (oBLLTraductor.CrearIdioma(oIdioma))
                {
                    MessageBox.Show("Idioma creado con exito");
                    
                    // Recargar idiomas y actualizar sesión
                    ListarIdiomas();
                    ActualizarTraduccionesEnSesion();
                    
                    // Limpiar el textbox después de crear el idioma
                    LimpiarTxt();
                }

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimpiarTxt()
        {
            txtNombreIdioma.Text = "";
            txtTraduccion.Text = "";
        }

        private void ActualizarTraduccionesEnSesion()
        {
            try
            {
                BLL.BLLTraductor Traductor = new BLL.BLLTraductor();
                var ListaIdiomas = Traductor.ObtenerIdiomas();

                // Cargar traducciones de todos los idiomas en la sesión
                foreach (Idioma idioma in ListaIdiomas)
                {
                    var traducciones = Traductor.obtenertraducciones(idioma);
                    if (traducciones != null && traducciones.Count > 0)
                    {
                        SingletonSesion.instancia.AgregarTraduccionesIdioma(idioma.Nombre, traducciones);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar traducciones: " + ex.Message);
            }
        }

        private void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTraducciones();
        }

        private void btnCrearTraduccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbPalabras.SelectedItem!=null)
                {
                    oPalabra = (Palabra)cbPalabras.SelectedItem;
                    oIdioma = (Idioma)cmbIdioma.SelectedItem;


                    
                    oTraduccion = new Traduccion();

                    oTraduccion.Palabra = oPalabra;

                    if (!oValidators.validarPalabra(txtTraduccion.Text))
                    {
                        throw new ArgumentException("Ingresar traducción valida, por favor verificar.");
                    }

                    oTraduccion.texto = txtTraduccion.Text;

                    if (oBLLTraductor.CrearTraduccion(oIdioma.ID,oTraduccion))
                    {
                        MessageBox.Show("Traduccion creada correctamente");
                        CargarTraducciones();
                        
                        // Actualizar traducciones en la sesión después de crear una nueva
                        ActualizarTraduccionesEnSesion();
                        
                        // Limpiar el textbox de traducción
                        txtTraduccion.Text = "";
                    }
                    else
                    {
                        throw new ArgumentException("Error cheee");
                    }


                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ya existe una traducción para esta palabra!!");

            }
        }

        private void cbPalabras_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
