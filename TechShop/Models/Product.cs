using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechShop.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage ="Name of product can't exceed 100 characters")]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        [MaxLength(10000, ErrorMessage = "Name of banch can't exceed 100 characters")]
        public string Branch { get; set; }
        public int StockQuantity { get; set; }
        [MaxLength(10000, ErrorMessage ="Name of description can't exceed 255 characters")]
        public string Description { get; set; }
        public string Img { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category ProductOfCategory { get; set; }
    }
}
