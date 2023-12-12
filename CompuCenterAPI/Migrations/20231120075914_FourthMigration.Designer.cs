﻿// <auto-generated />
using System;
using CompuCenterAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CompuCenterAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231120075914_FourthMigration")]
    partial class FourthMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlogPostCategory", b =>
                {
                    b.Property<Guid>("BlogPostsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BlogPostsId", "CategoriesId");

                    b.HasIndex("CategoriesId");

                    b.ToTable("BlogPostCategory");
                });

            modelBuilder.Entity("CompuCenterAPI.Models.Domain.BlogImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BlogImages");
                });

            modelBuilder.Entity("CompuCenterAPI.Models.Domain.BlogPost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeaturedImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlHandle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("CompuCenterAPI.Models.Domain.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlHandle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CompuCenterAPI.Models.Domain.Cliente", b =>
                {
                    b.Property<Guid>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("CompuCenterAPI.Models.Domain.DetalleVenta", b =>
                {
                    b.Property<Guid>("IdDetalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("CorrelativoNumeroVenta")
                        .HasColumnType("int");

                    b.Property<Guid>("IdProducto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdDetalle");

                    b.ToTable("DetallesVentas");
                });

            modelBuilder.Entity("CompuCenterAPI.Models.Domain.Producto", b =>
                {
                    b.Property<Guid>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("IdProducto");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("CompuCenterAPI.Models.Domain.Venta", b =>
                {
                    b.Property<Guid>("IdVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FechaVenta")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalVenta")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdVenta");

                    b.HasIndex("ClienteId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("DetalleVentaProducto", b =>
                {
                    b.Property<Guid>("DetallesVentaIdDetalle")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductosIdProducto")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DetallesVentaIdDetalle", "ProductosIdProducto");

                    b.HasIndex("ProductosIdProducto");

                    b.ToTable("DetalleVentaProducto");
                });

            modelBuilder.Entity("DetalleVentaVenta", b =>
                {
                    b.Property<Guid>("DetalleVentasIdDetalle")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VentasIdVenta")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DetalleVentasIdDetalle", "VentasIdVenta");

                    b.HasIndex("VentasIdVenta");

                    b.ToTable("DetalleVentaVenta");
                });

            modelBuilder.Entity("BlogPostCategory", b =>
                {
                    b.HasOne("CompuCenterAPI.Models.Domain.BlogPost", null)
                        .WithMany()
                        .HasForeignKey("BlogPostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CompuCenterAPI.Models.Domain.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CompuCenterAPI.Models.Domain.Venta", b =>
                {
                    b.HasOne("CompuCenterAPI.Models.Domain.Cliente", "Cliente")
                        .WithMany("Ventas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("DetalleVentaProducto", b =>
                {
                    b.HasOne("CompuCenterAPI.Models.Domain.DetalleVenta", null)
                        .WithMany()
                        .HasForeignKey("DetallesVentaIdDetalle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CompuCenterAPI.Models.Domain.Producto", null)
                        .WithMany()
                        .HasForeignKey("ProductosIdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DetalleVentaVenta", b =>
                {
                    b.HasOne("CompuCenterAPI.Models.Domain.DetalleVenta", null)
                        .WithMany()
                        .HasForeignKey("DetalleVentasIdDetalle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CompuCenterAPI.Models.Domain.Venta", null)
                        .WithMany()
                        .HasForeignKey("VentasIdVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CompuCenterAPI.Models.Domain.Cliente", b =>
                {
                    b.Navigation("Ventas");
                });
#pragma warning restore 612, 618
        }
    }
}
