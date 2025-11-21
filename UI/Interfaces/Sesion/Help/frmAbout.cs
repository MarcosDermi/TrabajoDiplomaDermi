using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Interfaces.Sesion.Help
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            string html = @"<!DOCTYPE html>
<html>
<head>
    <meta charset=""utf-8"" />
    <title>About - Cortez</title>
    <style>
        body {
            font-family: Segoe UI, Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 20px;
            color: #333;
        }

        .container {
            max-width: 720px;
            margin: 0 auto;
            background-color: #ffffff;
            padding: 24px 32px;
            border-radius: 8px;
            box-shadow: 0 0 8px rgba(0,0,0,0.1);
        }

        .logo {
            text-align: center;
            margin-bottom: 16px;
        }

        .logo img {
            max-width: 140px;
        }

        h1 {
            font-size: 24px;
            margin-bottom: 4px;
            text-align: center;
        }

        h2 {
            font-size: 16px;
            margin-top: 0;
            margin-bottom: 16px;
            text-align: center;
            color: #777;
        }

        p {
            line-height: 1.5;
            font-size: 13px;
        }

        ul {
            font-size: 13px;
        }

        .footer {
            margin-top: 16px;
            font-size: 11px;
            color: #777;
            text-align: right;
        }
    </style>
</head>
<body>
    <div class=""container"">

        <h1>Cortez</h1>
        <h2>Smart Booking Software – 2025</h2>

        <p>
            <strong>Cortez</strong> es un sistema integral de gestión para barberías y salones de estética,
            desarrollado como parte del Trabajo de Diploma de Ingeniería en Sistemas Informáticos.
            Su objetivo es centralizar las operaciones clave del negocio y mejorar la organización diaria.
        </p>

        <p>Entre sus principales funcionalidades se incluyen:</p>
        <ul>
            <li>Agenda inteligente de turnos.</li>
            <li>Gestión de stock e insumos.</li>
            <li>Administración de promociones y programas de fidelización.</li>
            <li>Gestión de servicios y profesionales.</li>
            <li>Reportes dinámicos y análisis de información.</li>
        </ul>

        <p>
            El sistema está construido sobre una arquitectura en capas (UI, Services, BLL, DAL, BE),
            utilizando tecnologías .NET, lo que facilita su mantenimiento, escalabilidad
            y la claridad en la lógica de negocio.
        </p>

        <div class=""footer"">
            Versión 2025 – Desarrollado por Marcos Dermi – UAI
        </div>
    </div>
</body>
</html>";

            webBrowserAbout.ScriptErrorsSuppressed = true;
            webBrowserAbout.AllowWebBrowserDrop = false;
            webBrowserAbout.IsWebBrowserContextMenuEnabled = false;
            webBrowserAbout.WebBrowserShortcutsEnabled = false;
            webBrowserAbout.DocumentText = html;
        }
    }
}
