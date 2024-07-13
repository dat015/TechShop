using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechShop.Models
{
    public class Detail_order
    {
        [Key]
        [Required]
        [ForeignKey("product_id")]
        private ProductModel? product {  get; set; }
        [Key]
        [Required]
        [ForeignKey("order_id")]
        private Order? order { get; set; }
        [Required]
        private int quantity { get; set; }
    }
}
