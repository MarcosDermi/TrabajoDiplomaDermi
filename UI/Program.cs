using System;
using System.Windows.Forms;
using UI.Interfaces;

namespace UI
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmInicioSesion());
            Application.Run(new frmTurnosLogOut());
            //Application.Run(new frmGestionIntegridad());
        }
    }
}
