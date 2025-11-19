using ABSTRACCION.Contracts;
using BLL;
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
        private IGestionServicioService _servicioService;
        private IGestionPromocionesService _promocionesService;
        private ISingletonSesionService _singletonsesionService;
        private IReporteriaService _reporteriaService;
        private IProfesionalService _profesionalService;


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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
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

        public IGestionServicioService GestionServicioService
        {
            get
            {
                if (_servicioService == null && !DesignMode)
                {
                    _servicioService = new GestionServiciosService();
                }
                return _servicioService;
            }
            set
            {
                _servicioService = value;
            }
        }

        public IGestionPromocionesService GestionPromocionesService
        {
            get
            {
                if (_promocionesService == null && !DesignMode)
                {
                    _promocionesService = new GestionPromocionesService();
                }
                return _promocionesService;
            }
            set
            {
                _promocionesService = value;
            }
        }

        public ISingletonSesionService SingletonSesionService
        {
            get
            {
                if (_singletonsesionService == null && !DesignMode)
                {
                    _singletonsesionService = BLLSingletonSesion.Instancia;
                }
                return _singletonsesionService;
            }
            set
            {
                _singletonsesionService = value;
            }
        }

        public IReporteriaService ReporteriaService
        {
            get
            {
                if (_reporteriaService == null && !DesignMode)
                {
                    _reporteriaService = new ReporteriaService();
                }
                return _reporteriaService;
            }
            set
            {
                _reporteriaService = value;
            }
        }

        public IProfesionalService ProfesionalService
        {
            get
            {
                if (_profesionalService == null && !DesignMode)
                {
                    _profesionalService = new ProfesionalService();
                }
                return _profesionalService;
            }
            set
            {
                _profesionalService = value;
            }
        }

        public void MostrarMensajeError(string sMensaje)
        {

            MessageBox.Show(sMensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
