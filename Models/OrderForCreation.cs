using Markata.Data;

namespace Markata.Models
{
    public class OrderForCreation
    {
        public string Name { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }

        public List<Product> Products { get; set; }
    }
}
