using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEReporte
    {
        public enum TipoReporteEnum
        {
            [Description("Cantidad de ventas")]
            CantidadVentas,

            [Description("Servicios mas contratados")]
            ServiciosMasContratados,

            [Description("Horarios mas reservados")]
            HorariosMasSolicitados
        }
    }
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
    

