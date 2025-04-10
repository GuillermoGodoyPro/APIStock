using APIStock.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIStock.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            
        }

        public DbSet<Categoria> Categorias { get; set; }    
        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(tb =>
            {
                tb.HasKey(col => col.IdCategoria);
                tb.Property(col => col.IdCategoria).UseIdentityColumn().ValueGeneratedOnAdd();
                tb.Property(col => col.Nombre).HasMaxLength(50);
                tb.Property(col => col.EsDestacada);

                tb.ToTable("Categoria");

                tb.HasData(
                    new Categoria { IdCategoria = 1, Nombre = "Electrodomésticos", EsDestacada = true },
                    new Categoria { IdCategoria = 2, Nombre = "Educación", EsDestacada = false },
                    new Categoria { IdCategoria = 3, Nombre = "Tecnología", EsDestacada = true },
                    new Categoria { IdCategoria = 4, Nombre = "Mascotas", EsDestacada = false }                                        
                );
            });

            modelBuilder.Entity<Producto>(tb =>
            {
                tb.HasKey(col => col.IdProducto);
                tb.Property(col => col.IdProducto).UseIdentityColumn().ValueGeneratedOnAdd();
                tb.Property(col => col.Nombre).HasMaxLength(50).IsRequired();
                tb.Property(col => col.Descripcion).HasMaxLength(120);

                tb.Property(col => col.Precio).HasColumnType("decimal(18, 2)").IsRequired(); ;
                tb.Property(col => col.Stock).IsRequired();

                tb.ToTable("Producto");

                // Una Categoría ----- muchos Productos
                tb.HasOne(col => col.CategoriaReferencia)
                    .WithMany(t => t.ProductoReferencia)
                    .HasForeignKey(col => col.IdCategoria)
                    .IsRequired(false); // El producto puede no tener una categoría al principio

            });



        }


    }
}
