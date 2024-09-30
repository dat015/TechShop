using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechShop.Models
{
    public class CartDetail
    {
        public int CartId { get; set; }
        public int productId { get; set; }
        [Required, Range(0, int.MaxValue, ErrorMessage = "Yêu cầu nhập số lượng sản phẩm")]

        public int quantity { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]

        public decimal price { get; set; }
        [ForeignKey("CartId")]
        public ShoppingCart cart { get; set; }
        [ForeignKey("productId")]

        public Product product { get; set; }
    }
}
