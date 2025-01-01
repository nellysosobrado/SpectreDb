using System;
using System.ComponentModel;
using System.Reflection;

namespace SpectreTablesToRefactor.Enums
{
    public enum Category
    {
        [Description("Kitchen")]
        Kitchen,

        [Description("Cleaning")]
        Cleaning,

        [Description("Health")]
        PersonalCare,

        [Description("Home")]
        Home
    }

    public enum MenuOptions
    {
        [Description("Add product")]
        AddProduct,

        [Description("Display all products")]
        ViewAllProducts,

        [Description("Display a specific product")]
        ViewProduct,

        [Description("Update product")]
        UpdateProduct,

        [Description("Remove product")]
        DeleteProduct,

        [Description("Exit program")]
        Exit
    }

    public static class MenuEnum
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field == null)
            {
                return value.ToString();
            }

            var attribute = field.GetCustomAttribute<DescriptionAttribute>();
            return attribute != null ? attribute.Description : value.ToString();
        }
    }
}
