using System.ComponentModel.DataAnnotations;

namespace PhoneShopASPnet.Models
{
    public class Brand
    {
        [Key]
        public int BrandID { get; set; }

        [Required]
        [StringLength(30)]
        public string? BrandName { get; set; }

        [Required]
        [StringLength(50)]
        public string? Description { get; set; }

        [Required]
        public int BrandOrder { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
