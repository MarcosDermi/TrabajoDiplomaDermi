using ABSTRACCION.Contracts;
using SERVICES;
using SERVICES.Interfaces;
using System.Drawing;
using System.Windows.Forms;

namespace TP_INGSOFTWARE
{
    public partial class BaseForm : Form
    {
        private IGestionStockService _gestionStockService;
        private IGeneralService _generalService;

        public IGestionStockService GestionStockService
        {
            get
            {
                // Inicialización perezosa: solo se crea cuando se necesita
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
                // Inicialización perezosa: solo se crea cuando se necesita
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
        public BaseForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (0));
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            //Icon = Resources.favicon;
            KeyPreview = true;
            ResumeLayout(false);
        }

    }
}
