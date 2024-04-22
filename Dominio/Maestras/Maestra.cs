using System.ComponentModel;

namespace Dominio.Maestras
{
    public static class Maestra
    {
        public enum Prioridad
        {
            [Description("Alta")]
            alta,
            [Description("Media")]
            media,
            [Description("Baja")]
            baja,
        }

        public enum Estado
        {
            [Description("Nueva")]
            nueva,
            [Description("Activa")]
            activa,
            [Description("En Proceso")]
            enProceso,
            [Description("Finalizada")]
            finalizada,
            [Description("Cancelada")]
            cancelada,
        }

        public static string GetEnum(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }
    }
}
