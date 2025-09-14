using BE;
using BLL;
using SERVICES;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TP_INGSOFTWARE
{
    public partial class frmGestionPermisos : Form
    {
        List<BEComponente> _lstPermisos = new List<BEComponente>();
       

        BLLPermisos oBLLPermisos;
        BEFamilia oSeleccion;
        BLLSingletonSesion _oSingletonSesion;
        public frmGestionPermisos(BLLSingletonSesion oSingletonSesion)
        {
            _oSingletonSesion = oSingletonSesion;
            InitializeComponent();
            oBLLPermisos = new BLLPermisos();
        }

        private void LlenarPatentesFamilias()
        {

            this.cboPatentes.DataSource = oBLLPermisos.GetAllPatentes();
            this.cboFamilias.DataSource = oBLLPermisos.GetAllFamilias();
        }
        private void frmGestionPermisos_Load(object sender, EventArgs e)
        {
            LlenarPatentesFamilias();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            BEFamilia oPadre = new BEFamilia()
            {
                Nombre = this.txtNombreFamilia.Text

            };

            oBLLPermisos.GuardarComponente(oPadre, true);
            LlenarPatentesFamilias();
            MessageBox.Show("Familia guardada correctamente");
        }

        void MostrarFamilia(bool init)
        {
            if (oSeleccion == null) return;


            IList<BEComponente> flia = null;
            if (init)
            {
                //traigo los hijos de la base
                flia = oBLLPermisos.GetAll("=" + oSeleccion.Id);


                foreach (var i in flia)
                    oSeleccion.AgregarHijo(i);
            }
            else
            {
                flia = oSeleccion.Hijos;
            }

            this.treeConfigurarFamilia.Nodes.Clear();

            TreeNode root = new TreeNode(oSeleccion.Nombre);
            root.Tag = oSeleccion;
            this.treeConfigurarFamilia.Nodes.Add(root);

            foreach (var item in flia)
            {
                MostrarEnTreeView(root, item);
            }

            treeConfigurarFamilia.ExpandAll();
        }

        void MostrarEnTreeView(TreeNode tn, BEComponente c)
        {
            TreeNode n = new TreeNode(c.Nombre);
            tn.Tag = c;
            tn.Nodes.Add(n);
            if (c.Hijos != null)
                foreach (var item in c.Hijos)
                {
                    MostrarEnTreeView(n, item);
                }

        }

        private void CmdAgregarPatente_Click(object sender, EventArgs e)
        {
            if (oSeleccion != null)
            {
                var patente = (BEPatente)cboPatentes.SelectedItem;
                if (patente != null)
                {
                    var esta = oBLLPermisos.Existe(oSeleccion, patente.Id);
                    if (esta)
                        MessageBox.Show("ya exsite la patente indicada");
                    else
                    {

                        {
                            oSeleccion.AgregarHijo(patente);
                            MostrarFamilia(false);
                        }
                    }
                }
            }
        }

        private void CmdSeleccionar_Click(object sender, EventArgs e)
        {
            var tmp = (BEFamilia)this.cboFamilias.SelectedItem;
            oSeleccion = new BEFamilia();
            oSeleccion.Id = tmp.Id;
            oSeleccion.Nombre = tmp.Nombre;

            MostrarFamilia(true);
        }

        private void CmdAgregarFamilia_Click(object sender, EventArgs e)
        {
            if (oSeleccion != null)
            {
                var familia = (BEFamilia)cboFamilias.SelectedItem;
                if (familia != null)
                {

                    var esta = oBLLPermisos.Existe(oSeleccion, familia.Id);
                    if (esta)
                        MessageBox.Show("ya exsite la familia indicada");
                    else
                    {

                        oBLLPermisos.FillFamilyComponents(familia);
                        oSeleccion.AgregarHijo(familia);
                        MostrarFamilia(false);
                    }


                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            try
            {
                oBLLPermisos.GuardarFamilia(oSeleccion);
                MessageBox.Show("Familia guardada correctamente");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Atencion",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }
    }
}
