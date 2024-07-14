using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechShop.Models
{
    [PrimaryKey(nameof(ProductId), nameof(OrderId))]
    public class OrderDetail
    {
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public Product? Product {  get; set; }
        public Order? Order { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
