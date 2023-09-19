using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneShopASPnet.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string? ProductName { get; set; }

        public decimal? ProductPrice { get; set; }

        [Required]
        [StringLength(500)]
        public string? Description { get; set; }

        [Required]  
        public int ProductQuantity { get; set; }

        [StringLength(50)]
        public string ProductImage { get; set; }

        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }
        public Category? Category { get; set; }

        [ForeignKey("BrandID")]
        public int BrandID { get; set; }
        public Brand? Brand { get; set; }
    }
}
