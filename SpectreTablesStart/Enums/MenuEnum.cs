using System;
using System.ComponentModel;
using System.Reflection;

namespace SpectreTablesToRefactor.Enums
{
    internal enum Category
    {
        [Description("Kök")]
        Kitchen,

        [Description("Städ")]
        Cleaning,

        [Description("Personvård")]
        PersonalCare,

        [Description("Hem")]
        Home
    }

    internal enum MenuOptions
    {
        [Description("Lägg till en produkt")]
        AddProduct,

        [Description("Visa alla produkter")]
        ViewAllProducts,

        [Description("Visa en specifik produkt")]
        ViewProduct,

        [Description("Uppdatera en produkt")]
        UpdateProduct,

        [Description("Ta bort en produkt")]
        DeleteProduct,

        [Description("Avsluta programmet")]
        Exit
    }

    internal static class MenuEnum
    {
        // Extension-metod som returnerar beskrivningen för en Enum
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field == null)
            {
                // Detta borde egentligen aldrig hända om du arbetar med giltiga enums
                return value.ToString();
            }

            var attribute = field.GetCustomAttribute<DescriptionAttribute>();
            return attribute != null ? attribute.Description : value.ToString();
        }
    }
}
