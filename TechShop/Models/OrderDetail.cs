using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechShop.Models
{
    [PrimaryKey(nameof(ProductId), nameof(OrderId))]
    public class OrderDetail
    {
        public int ProductId { get; set; }
        [Required]
        [ForeignKey("ProductId")]
        public Product product { get; set; }
        public int OrderId { get; set; }
        [Required]
        [ForeignKey("OrderId")]
        public Order order { get; set; }
       
        [Required]
        public int Quantity { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
    }
}
