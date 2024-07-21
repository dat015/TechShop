using Microsoft.EntityFrameworkCore;
using TechShop.Models;

namespace TechShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> DetailsOrders { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryId = 1, CategoryName = "Laptop văn phòng", Description="Là sản phẩm bán chạy nhất của chúng tôi" },
                    new Category { CategoryId = 2, CategoryName = "Laptop Gaming", Description="Máy có cấu hình mạnh đáp ứng nhu cầu chơi game" },
                    new Category { CategoryId = 3, CategoryName = "Laptop đồ họa", Description="Máy có cấu hình mạnh đáp ứng nhu cầu thiết kế đồ họa" },
                    new Category { CategoryId = 4, CategoryName = "Laptop cao cấp", Description="Máy có cấu thiết kế mỏng nhẹ" },
                    new Category { CategoryId = 5, CategoryName = "Surface", Description="Surface phụ vụ cho công việc, học tập" }
                );

            modelBuilder.Entity<Brand>().HasData(
                    new Brand { BrandId=1, BrandName="Lenovo" },
                    new Brand { BrandId=2, BrandName="Samsung" },
                    new Brand { BrandId=3, BrandName="MSI" },
                    new Brand { BrandId=4, BrandName="Apple" },
                    new Brand { BrandId=5, BrandName="Intel" },
                    new Brand { BrandId=6, BrandName="Dell" }
                );

            modelBuilder.Entity<Product>().HasData(
                    new Product { ProductId=1, ProductName="Lenovo Thinkbook 16 G6+ 2024", Price=21490000, BrandId=1, Description="Legion Y7000P 2024 là một chiếc Laptop hứa hẹn là một trong những sự lựa chọn tuyệt vời bởi thiết kế độc đáo, cá tính cùng với hiệu năng và những thông số kĩ thuật ấn tượng. Vậy nên đừng ngần ngại lựa chọn mua Legion Y7000P 2024 tại hệ thống của hàng của LaptopAZ.vn để được trải nghiệm sự tuyệt vời của chiếc Laptop này đem lại.", StockQuantity=100, Img="https://laptopaz.vn/media/product/3174_", CategoryId=1 }
                );

            modelBuilder.Entity<PaymentMethod>().HasData(
                    new PaymentMethod { PaymentMethodId=1, MethodName="Thanh toán tại cửa hàng"},
                    new PaymentMethod { PaymentMethodId=2, MethodName="Thanh toán khi nhận hàng" },
                    new PaymentMethod { PaymentMethodId=3, MethodName="Thanh toán bằng chuyển khoản ngân hàng" },
                    new PaymentMethod { PaymentMethodId=4, MethodName="Thanh toán trả góp" }
                );

            modelBuilder.Entity<Order>().HasData(
                    new Order { OrderId=1, OrderDate=new DateTime(2024, 07, 14), Status="Đã xác nhận", TotalAmount=1, PaymentMethodId=1 }
                );

            modelBuilder.Entity<OrderDetail>().HasData(
                    new OrderDetail { OrderId=1, ProductId=1, Quantity=2 }
                );
            
        }
    }
}
