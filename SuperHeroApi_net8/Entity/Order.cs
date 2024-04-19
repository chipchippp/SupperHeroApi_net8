using System.ComponentModel.DataAnnotations;

namespace SuperHeroApi_net8.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        public int TotalOrders { get; set; }
    }
}
