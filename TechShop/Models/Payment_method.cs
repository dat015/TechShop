using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechShop.Models
{
    public class Payment_method
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int PaymentMethodId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Method name can't exceed 100 characters")]
        private string? MethodName { get; set; }

        [Required]
        [ForeignKey("orderID")]
        private Order? order { get; set; }
    }
}
