using System.ComponentModel.DataAnnotations.Schema;

namespace Markata.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<Order> Orders { get; set; }

    }
}
