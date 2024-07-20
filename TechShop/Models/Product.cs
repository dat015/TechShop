using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechShop.Repository.Validation;

namespace TechShop.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required, MaxLength(1000, ErrorMessage = "Yêu cầu nhập tên sản phẩm")]
        public string ProductName { get; set; }
        [Required,Range(0,1000000000, ErrorMessage ="Yêu cầu nhập giá sản phẩm")]
        public decimal Price { get; set; }
        [Required,MaxLength(10000, ErrorMessage = "Yêu cầu nhập nhãn hàng")]
        public string Branch { get; set; }
        [Required, Range(0,1000, ErrorMessage ="Yêu cầu nhập số lượng trong kho")]
        public int StockQuantity { get; set; }
        [Required, MaxLength(10000, ErrorMessage ="Yêu cầu nhập mô tả")]
        public string Description { get; set; }
        public string Img { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category CategoryOfProducts { get; set; }
        [NotMapped]
        [FileExtension]
        public IFormFile? ImageUpLoad { get; set; }
    }
}
