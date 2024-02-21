using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Data.Models
{
    public class TShirts
    {
        [Key]
        public int Id { get; set; }
        [Required]
        
        public string Mark { get; set; } = null!;
    }
}
