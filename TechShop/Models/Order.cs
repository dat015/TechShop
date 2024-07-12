using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechShop.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        private int OrderId { get; set; }

        [Required]
        [StringLength(100 , ErrorMessage = "Status can't exceed 100 characters")]
        private string? Status { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]

        private decimal TotalAmount { get; set; } 

        [Required]
        private DateTime OrderDate { get; set; }

        [ForeignKey(Cate_id)]]
        private CategoryModel Cate { get; set; }
    }
}
