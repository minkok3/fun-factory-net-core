using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Domain
{
    public class Component
    {
        [Key]
        public long Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQty { get; set; }

        public ICollection<KitComponent> KitComponents { get; set; }
    }
}
