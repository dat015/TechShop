using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechShop.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage ="Name of product can't exceed 100 characters")]
        public string ProductName { get; set; }
        public double price { get; set; }
        [MaxLength(100, ErrorMessage = "Name of banch can't exceed 100 characters")]
        public string branch { get; set; }
        public int stock_quantity { get; set; }
        [MaxLength(255, ErrorMessage ="Name of description can't exceed 255 characters")]
        public string desciption { get; set; }
        public string img { get; set; }
        [ForeignKey("CategoryId")]
        public CategoryModel ProductOfCategory { get; set; }
    }
}
