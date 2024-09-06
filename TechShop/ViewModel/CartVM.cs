using TechShop.Models;

namespace TechShop.ViewModel
{
    public class CartVM
    {
        public IEnumerable<ShoppingCart> ListCart { get; set; }
        public decimal Total { get; set; } 
    }
}
