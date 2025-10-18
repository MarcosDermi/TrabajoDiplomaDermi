using ABSTRACCION.Contracts;
using SERVICES;
using SERVICES.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    public partial class BaseForm : Form
    {
        private IGestionStockService _gestionStockService;
        private IGeneralService _generalService;
        private IAgendaService _agendaService;
        private IValidatorsService _validatorsService;


        public BaseForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        public IGestionStockService GestionStockService
        {
            get
            {
                if (_gestionStockService == null && !DesignMode)
                {
                    _gestionStockService = new GestionStockService();
                }
                return _gestionStockService;
            }
            set
            {
                _gestionStockService = value;
            }
        }

        public IGeneralService GeneralService
        {
            get
            {
                if (_generalService == null && !DesignMode)
                {
                    _generalService = new GeneralService();
                }
                return _generalService;
            }
            set
            {
                _generalService = value;
            }
        }

        public IAgendaService AgendaService
        {
            get
            {
                if (_agendaService == null && !DesignMode)
                {
                    _agendaService = new AgendaService();
                }
                return _agendaService;
            }
            set
            {
                _agendaService = value;
            }
        }

        public IValidatorsService ValidatorsService
        {
            get
            {
                if (_validatorsService == null && !DesignMode)
                {
                    _validatorsService = new ValidatorsService();
                }
                return _validatorsService;
            }
            set
            {
                _validatorsService = value;
            }
        }

        public void MostrarMensajeError(Exception ex)
        {

            MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
