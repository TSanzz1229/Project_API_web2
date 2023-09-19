using System.ComponentModel.DataAnnotations;

namespace PhoneShopASPnet.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string? CategoryName { get; set; }

        [Required]
        [StringLength(50)]
        public string? Description  { get; set; }

        [Required]
        public int CategoryOrder { get; set; }

        public ICollection<Product>? Products { get; set; } 

    }
}
