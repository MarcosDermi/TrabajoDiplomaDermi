using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES
{
    public class Bitacora
    {
        public int ID { get; set; }

        public string Detalle { get; set; }

        public BEUsuario UsuarioResponsable { get; set; }

        public DateTime Fecha { get; set; }

        public TipoBitacoraEnum BitacoraEnum { get; set; }

        public Bitacora() { }
    }

    public enum TipoBitacoraEnum
    {
        [Description("Acceso de usuario")]
        AccesoUsuario,

        [Description("Cambio en usuario")]
        CambioUsuario
    }

    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attr = field.GetCustomAttribute<DescriptionAttribute>();
            return attr != null ? attr.Description : value.ToString();
        }
    }
}
