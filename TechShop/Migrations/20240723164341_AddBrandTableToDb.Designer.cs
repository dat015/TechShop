﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechShop.Data;

#nullable disable

namespace TechShop.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240723164341_AddBrandTableToDb")]
    partial class AddBrandTableToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TechShop.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandId"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            BrandId = 1,
                            BrandName = "Lenovo"
                        },
                        new
                        {
                            BrandId = 2,
                            BrandName = "Samsung"
                        },
                        new
                        {
                            BrandId = 3,
                            BrandName = "MSI"
                        },
                        new
                        {
                            BrandId = 4,
                            BrandName = "Apple"
                        },
                        new
                        {
                            BrandId = 5,
                            BrandName = "Intel"
                        },
                        new
                        {
                            BrandId = 6,
                            BrandName = "Dell"
                        });
                });

            modelBuilder.Entity("TechShop.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Laptop văn phòng",
                            Description = "Là sản phẩm bán chạy nhất của chúng tôi"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Laptop Gaming",
                            Description = "Máy có cấu hình mạnh đáp ứng nhu cầu chơi game"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Laptop đồ họa",
                            Description = "Máy có cấu hình mạnh đáp ứng nhu cầu thiết kế đồ họa"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Laptop cao cấp",
                            Description = "Máy có cấu thiết kế mỏng nhẹ"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Surface",
                            Description = "Surface phụ vụ cho công việc, học tập"
                        });
                });

            modelBuilder.Entity("TechShop.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            OrderDate = new DateTime(2024, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentMethodId = 1,
                            Status = "Đã xác nhận",
                            TotalAmount = 1m
                        });
                });

            modelBuilder.Entity("TechShop.Models.OrderDetail", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("DetailsOrders");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            OrderId = 1,
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("TechShop.Models.PaymentMethod", b =>
                {
                    b.Property<int>("PaymentMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentMethodId"));

                    b.Property<string>("MethodName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PaymentMethodId");

                    b.ToTable("PaymentMethods");

                    b.HasData(
                        new
                        {
                            PaymentMethodId = 1,
                            MethodName = "Thanh toán tại cửa hàng"
                        },
                        new
                        {
                            PaymentMethodId = 2,
                            MethodName = "Thanh toán khi nhận hàng"
                        },
                        new
                        {
                            PaymentMethodId = 3,
                            MethodName = "Thanh toán bằng chuyển khoản ngân hàng"
                        },
                        new
                        {
                            PaymentMethodId = 4,
                            MethodName = "Thanh toán trả góp"
                        });
                });

            modelBuilder.Entity("TechShop.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            BrandId = 1,
                            CategoryId = 1,
                            Description = "Legion Y7000P 2024 là một chiếc Laptop hứa hẹn là một trong những sự lựa chọn tuyệt vời bởi thiết kế độc đáo, cá tính cùng với hiệu năng và những thông số kĩ thuật ấn tượng. Vậy nên đừng ngần ngại lựa chọn mua Legion Y7000P 2024 tại hệ thống của hàng của LaptopAZ.vn để được trải nghiệm sự tuyệt vời của chiếc Laptop này đem lại.",
                            Img = "https://laptopaz.vn/media/product/3174_",
                            Price = 21490000m,
                            ProductName = "Lenovo Thinkbook 16 G6+ 2024",
                            StockQuantity = 100
                        });
                });

            modelBuilder.Entity("TechShop.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool?>("role")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TechShop.Models.Order", b =>
                {
                    b.HasOne("TechShop.Models.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("TechShop.Models.OrderDetail", b =>
                {
                    b.HasOne("TechShop.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechShop.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TechShop.Models.Product", b =>
                {
                    b.HasOne("TechShop.Models.Brand", "BrandOfProducts")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechShop.Models.Category", "CategoryOfProducts")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BrandOfProducts");

                    b.Navigation("CategoryOfProducts");
                });

            modelBuilder.Entity("TechShop.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
