using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechShop.ViewModel;

namespace TechShop.Models
{
    public class ShoppingCart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product   { get; set; }
        public int count { get; set; }
        public int UserId { get; set; }

        [ForeignKey("Id")]
        public User User { get; set; }
        
    }
}
