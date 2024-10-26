using Markata.Data;

namespace Markata.Models
{
    public class OrderForModification
    {

        public string Name { get; set; }
        public int Id {  get; set; }
        public int ProductId { get; set; }
        public int ProductPrice { get; set; }
        public double Cost { get; set; } 
        public int Quantity { get; set; } 
        public int? SelectedProductId { get; set; }
        public int? SelectedProductPrice { get; set; }

        public List<Product> Products { get; set; }
    }
}
