using APIStock.Context;
using APIStock.DTOs;
using Microsoft.EntityFrameworkCore;

namespace APIStock.Services
{
    public class ProductoService
    {
        private readonly AppDbContext _context;
        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductoDTO>> Lista()
        {
            var listaProductosDTO = new List<ProductoDTO>();
            var listaProductosDB = await _context.Productos.Include(c => c.CategoriaReferencia).ToListAsync();

            foreach (var item in listaProductosDB)
            {
                listaProductosDTO.Add(new ProductoDTO
                {
                    IdProducto = item.IdProducto,
                    Nombre = item.Nombre,
                    Descripcion = item.Descripcion,
                    Precio = item.Precio,
                    Stock = item.Stock,
                    IdCategoria= item.IdCategoria,
                    NombreCategoria = item.CategoriaReferencia?.Nombre,

                });
            }

            return listaProductosDTO;
        }
    }
}
