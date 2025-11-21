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
    public partial class frmNotasVersion : Form
    {
        public frmNotasVersion()
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
    <title>Notas de la versión - Cortez 1.0.0</title>
    <style>
        body {
            font-family: Segoe UI, Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 20px;
            color: #333;
        }

        .container {
            max-width: 820px;
            margin: 0 auto;
            background-color: #ffffff;
            padding: 24px 32px;
            border-radius: 8px;
            box-shadow: 0 0 8px rgba(0,0,0,0.1);
        }

        h1 {
            font-size: 24px;
            margin-top: 0;
            margin-bottom: 8px;
        }

        h2 {
            font-size: 18px;
            margin-top: 20px;
            margin-bottom: 6px;
            border-bottom: 1px solid #ddd;
            padding-bottom: 4px;
        }

        h3 {
            font-size: 15px;
            margin-top: 14px;
            margin-bottom: 4px;
        }

        p {
            font-size: 13px;
            line-height: 1.5;
        }

        ul {
            font-size: 13px;
            margin-top: 4px;
            margin-bottom: 8px;
            padding-left: 20px;
        }

        .tagline {
            font-size: 12px;
            color: #777;
            margin-bottom: 16px;
        }

        .footer {
            margin-top: 18px;
            font-size: 11px;
            color: #777;
            text-align: right;
        }

        .badge {
            display: inline-block;
            font-size: 11px;
            padding: 2px 8px;
            border-radius: 12px;
            border: 1px solid #ccc;
            margin-left: 6px;
        }
    </style>
</head>
<body>
    <div class=""container"">
        <h1>Cortez 1.0.0</h1>
        <div class=""tagline"">
            Smart Booking Software – Versión inicial de lanzamiento
        </div>

        <h2>Novedades principales</h2>
        <ul>
            <li>Lanzamiento oficial de <strong>Cortez</strong>, sistema integral para barberías y salones de estética.</li>
            <li>Interfaz moderna con panel lateral de navegación y módulo principal de trabajo.</li>
            <li>Incorporación de la identidad visual oficial <em>Cortez 2025</em>.</li>
        </ul>

        <h2>Agenda y turnos</h2>
        <ul>
            <li>Gestión completa de reservas de turnos.</li>
            <li>Manejo de estados: creación, confirmación y cancelación de turnos.</li>
            <li>Validación de solapamiento de horarios según jornada laboral configurada.</li>
        </ul>

        <h2>Stock e insumos</h2>
        <ul>
            <li>ABM de insumos y proveedores.</li>
            <li>Control de stock con registro de movimientos (altas/bajas por uso en servicios).</li>
            <li>Asociación de insumos a servicios (relación muchos a muchos).</li>
        </ul>

        <h2>Promociones y fidelización</h2>
        <ul>
            <li>Creación y administración de promociones con fechas de vigencia y porcentaje de descuento.</li>
            <li>Sistema de fidelización para clientes frecuentes.</li>
            <li>Cálculo automático de descuentos sobre el total de la reserva cuando hay promociones activas.</li>
        </ul>

        <h2>Servicios y profesionales</h2>
        <ul>
            <li>ABM de servicios con precio, duración estimada y requisitos de insumos.</li>
            <li>Asociación de servicios a profesionales para agenda y reportes.</li>
        </ul>

        <h2>Menú de usuario</h2>
        <ul>
            <li>Consulta de los turnos del cliente.</li>
            <li>Acceso a información de cuenta.</li>
            <li>Visualización del estado de fidelización.</li>
        </ul>

        <h2>Help y documentación</h2>
        <ul>
            <li>Manual de usuario integrado mediante componente WebBrowser.</li>
            <li>Sección <strong>About</strong> con información del proyecto y autoría.</li>
            <li>Sección <strong>Notas de la versión</strong> para visualizar este changelog.</li>
        </ul>

        <h2>Reportería</h2>
        <ul>
            <li>Gráficos dinámicos para análisis de servicios y ventas.</li>
            <li>Posibilidad de filtrar información por períodos.</li>
        </ul>

        <h2>Arquitectura de la aplicación</h2>
        <ul>
            <li>Arquitectura por capas:
                <strong>UI → Services → BLL → DAL → BE</strong>.
            </li>
            <li>Uso de .NET Framework para la capa de presentación (WinForms).</li>
            <li>Separación clara de responsabilidades y preparado para futuras extensiones.</li>
        </ul>

        <h2>Correcciones y mejoras iniciales</h2>
        <ul>
            <li>Ajustes en validaciones de jornada laboral y solapamiento de franjas horarias.</li>
            <li>Corrección de estados de procesos que quedaban marcados como “Pendiente” luego de ejecutarse.</li>
            <li>Mejoras de rendimiento y carga visual en el formulario principal de sesión.</li>
        </ul>

        <div class=""footer"">
            Cortez 1.0.0 – 2025 &nbsp;|&nbsp; Desarrollado por Marcos Dermi – UAI
        </div>
    </div>
</body>
</html>
";

            webBrowserAbout.ScriptErrorsSuppressed = true;
            webBrowserAbout.AllowWebBrowserDrop = false;
            webBrowserAbout.IsWebBrowserContextMenuEnabled = false;
            webBrowserAbout.WebBrowserShortcutsEnabled = false;
            webBrowserAbout.DocumentText = html;
        }
    }
}
