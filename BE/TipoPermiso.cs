using System.ComponentModel;

namespace BE
{
    public enum TipoPermiso
    {
        // CRUDs
        [Description("Crear")]
        Crear,
        [Description("Leer")]
        Leer,
        [Description("Editar")]
        Editar,
        [Description("Eliminar")]
        Eliminar,
        [Description("Gestionar usuarios")]
        GestionarUsuarios,
        [Description("Accerder a panel")]
        AccederPanel,
        [Description("Configurar el sistema")]
        ConfigurarSistema,
        [Description("Ver reportes")]
        VerReportes,
        [Description("Exportar datos")]
        ExportarDatos,
        [Description("Aprobar procesos")]
        AprobarProcesos
    }
}
