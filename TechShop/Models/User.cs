using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechShop.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        private int Id {  get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name of banch can't exceed 100 characters")]
        private string? Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name of banch can't exceed 50 characters")]
        private string? email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Name of banch can't exceed 100 characters")]
        private string? address { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Name of banch can't exceed 10 characters")]
        private string? phone_number { get; set; }
        [Required]
        private Boolean? role {  get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name of banch can't exceed 50 characters")]
        private string? password { get; set; }

    }
}
