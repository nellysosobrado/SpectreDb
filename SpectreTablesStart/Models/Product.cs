using SpectreTablesToRefactor.Enums;

namespace SpectreTablesToRefactor.Models
{
    internal class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        // Lägg till Category-egenskapen som refererar till Category-enumen
        public Category Category { get; set; }
    }
}
