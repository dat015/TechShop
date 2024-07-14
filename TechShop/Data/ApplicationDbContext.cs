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

            modelBuilder.Entity<Product>().HasData(
                    new Product { ProductId=1, ProductName="Lenovo Thinkbook 16 G6+ 2024", Price=21490000, Branch="Lenovo", Description="Legion Y7000P 2024 là một chiếc Laptop hứa hẹn là một trong những sự lựa chọn tuyệt vời bởi thiết kế độc đáo, cá tính cùng với hiệu năng và những thông số kĩ thuật ấn tượng. Vậy nên đừng ngần ngại lựa chọn mua Legion Y7000P 2024 tại hệ thống của hàng của LaptopAZ.vn để được trải nghiệm sự tuyệt vời của chiếc Laptop này đem lại.", StockQuantity=100, Img="https://laptopaz.vn/media/product/3174_", CategoryId=1 },
                    new Product { ProductId=2, ProductName="Lenovo Legion Y7000P ", Price=29890000, Branch="Lenovo", Description="Laptop Lenovo ThinkBook 16 G6+ với hiệu năng mạnh mẽ cùng thiết kế thanh lịch, là sự lựa chọn phù hợp cho hầu hết tất cả mọi người", StockQuantity=100, Img="https://laptopaz.vn/media/product/3174_", CategoryId=2 },
                    new Product { ProductId=3, ProductName="Lenovo Legion 5 R7000 APH9", Price=29890000, Branch="Lenovo", Description= "mẫu laptop cao cấp của nhà Acer đã và đem lại những trải nghiệm tuyệt vời, cùng với những ưu điểm vượt trội", StockQuantity=100, Img="https://laptopaz.vn/media/product/2947_helios_neo_2023.jpg", CategoryId=2 },
                    new Product { ProductId=4, ProductName="Dell Inspiron 14 5430", Price=15990000, Branch="Dell", Description=" Laptop Dell Inspiron 14 5430 là một chiếc laptop thiết kế sang trọng, gọn nhẹ, màn hình chất lượng đi kèm hiệu năng mạnh mẽ", StockQuantity=100, Img="https://laptopaz.vn/media/product/2757_laptopaz_5430_chinh.png", CategoryId=4 },
                    new Product { ProductId=5, ProductName=" Lenovo Thinkbook 16 G7 2024", Price=21890000, Branch="Lenovo", Description="Legion Y7000P 2024 là một chiếc Laptop hứa hẹn là một trong những sự lựa chọn tuyệt vời bởi thiết kế độc đáo, cá tính cùng với hiệu năng và những thông số kĩ thuật ấn tượng. Vậy nên đừng ngần ngại lựa chọn mua Legion Y7000P 2024 tại hệ thống của hàng của LaptopAZ.vn để được trải nghiệm sự tuyệt vời của chiếc Laptop này đem lại.", StockQuantity=100, Img="https://laptopaz.vn/media/product/3239_lenovo_thinkbook_16_g7_2024.jpg", CategoryId=4 },
                    new Product { ProductId=6, ProductName="Surface Book 3", Price=29890000, Branch="Surface", Description="hiệu năng mạnh mẽ cùng thiết kế thanh lịch, là sự lựa chọn phù hợp", StockQuantity=100, Img="https://laptopaz.vn/media/product/2556_surface_book_3_core_i7_32gb_1tb_15_inch_newseal_1601018373.jpg", CategoryId=5 }
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
