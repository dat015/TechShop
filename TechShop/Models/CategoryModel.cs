using System.ComponentModel.DataAnnotations;

namespace TechShop.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="The value of Category Name can't exceed 50 characters.")]
        public string CategoryName { get; set; }
        [MaxLength(255,ErrorMessage ="The value of Description can't exceed 255 characters.")]
        public string Description {  get; set; }
    }
}
