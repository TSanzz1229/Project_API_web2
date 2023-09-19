using System.ComponentModel.DataAnnotations;

namespace PhoneShopASPnet.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? UserEmail { get; set; }

        [Required]
        public string? PassWord { get; set; }

        [Required]
        public string? UserRole { get; set; }

    }
}
