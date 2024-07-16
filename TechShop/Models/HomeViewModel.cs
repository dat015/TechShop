namespace TechShop.Models
{
    public class HomeViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public HomeViewModel(List<Category> Cate, List<Product> Pro)
        {
            Categories = Cate;
            Products = Pro;
        }
    }
}
