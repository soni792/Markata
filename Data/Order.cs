
using System.ComponentModel.DataAnnotations.Schema;

namespace Markata.Data
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }


        [ForeignKey("ProductId")]
        public int? ProductId { get; set; }
        public int? ProductPrice { get; set; }
        public virtual Product Product { get; set; }


    }
}
