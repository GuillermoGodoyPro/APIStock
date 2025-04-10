﻿// <auto-generated />
using APIStock.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIStock.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APIStock.Entities.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"));

                    b.Property<bool>("EsDestacada")
                        .HasColumnType("bit");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            IdCategoria = 1,
                            EsDestacada = true,
                            IdProducto = 0,
                            Nombre = "Electrodomésticos"
                        },
                        new
                        {
                            IdCategoria = 2,
                            EsDestacada = false,
                            IdProducto = 0,
                            Nombre = "Educación"
                        },
                        new
                        {
                            IdCategoria = 3,
                            EsDestacada = true,
                            IdProducto = 0,
                            Nombre = "Tecnología"
                        },
                        new
                        {
                            IdCategoria = 4,
                            EsDestacada = false,
                            IdProducto = 0,
                            Nombre = "Mascotas"
                        });
                });

            modelBuilder.Entity("APIStock.Entities.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducto"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("IdProducto");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Producto", (string)null);
                });

            modelBuilder.Entity("APIStock.Entities.Producto", b =>
                {
                    b.HasOne("APIStock.Entities.Categoria", "CategoriaReferencia")
                        .WithMany("ProductoReferencia")
                        .HasForeignKey("IdCategoria");

                    b.Navigation("CategoriaReferencia");
                });

            modelBuilder.Entity("APIStock.Entities.Categoria", b =>
                {
                    b.Navigation("ProductoReferencia");
                });
#pragma warning restore 612, 618
        }
    }
}
