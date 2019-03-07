using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Domain
{
    public class KitComponent
    {
        [Key]
        public long Id { get; set; }
        public int Qty { get; set; }

        public Component Kit { get; set; }
        public Component Component { get; set; }
        [NotMapped]
        public string Name { get; set; }
    }
}
