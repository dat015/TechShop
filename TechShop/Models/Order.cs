using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechShop.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int OrderId { get; set; }

        [Required]
        [StringLength(100 , ErrorMessage = "Status can't exceed 100 characters")]
        public string? Status { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; } 

        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        [ForeignKey("PaymentMethodId")]
        public int PaymentMethodId {  get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
