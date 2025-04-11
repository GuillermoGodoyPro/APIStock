using System.Threading;
using APIStock.Context;
using APIStock.DTOs;
using APIStock.Entities;
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

        public async Task<ProductoDTO> ListarUno(int id)
        {
            var productoDTO = new ProductoDTO();
            var productoDB = await _context.Productos.Include(c => c.CategoriaReferencia)
                .Where(p => p.IdProducto == id).FirstAsync();

            productoDTO.IdProducto = id;
            productoDTO.Nombre = productoDB.Nombre;
            productoDTO.Descripcion = productoDB.Descripcion;
            productoDTO.Precio = productoDB.Precio;
            productoDTO.Stock = productoDB.Stock;
            productoDTO.NombreCategoria = productoDB.CategoriaReferencia.Nombre;
            productoDTO.IdCategoria = productoDB.IdCategoria;


            return productoDTO;
        }

        public async Task<ProductoDTO> GuardarProducto(ProductoDTO productoDTO)
        {
            var productoDB = new Producto
            {
                Nombre = productoDTO.Nombre,
                Descripcion = productoDTO.Descripcion,
                Precio = productoDTO.Precio,
                Stock = productoDTO.Stock,
                IdCategoria= productoDTO.IdCategoria,
            };

            _context.Productos.Add(productoDB);
            await _context.SaveChangesAsync();

            return productoDTO;

        }

        public async Task<ProductoDTO> EditarProducto(ProductoDTO productoDTO)
        {
            var productoDB = await _context.Productos.FindAsync(productoDTO.IdProducto);

            if (productoDB is null)
            {
                return null; // Indica que el empleado no fue encontrado
            }

            productoDB.IdProducto = productoDTO.IdProducto;
            productoDB.Nombre = productoDTO.Nombre;
            productoDB.Descripcion = productoDTO.Descripcion;
            productoDB.Precio = productoDTO.Precio;
            productoDB.Stock= productoDTO.Stock;
            productoDB.IdCategoria= productoDTO.IdCategoria;
            

            _context.Productos.Update(productoDB);
            await _context.SaveChangesAsync();

            return productoDTO;
        }

        public async Task<bool> EliminarProducto(int id)
        {

            var productoDB = await _context.Productos.FindAsync(id);

            if (productoDB is null)
            {
                return false; // Indica que no se encontró el empleado
            }

            _context.Productos.Remove(productoDB);
            await _context.SaveChangesAsync();
            return true; // Indica que la eliminación fue exitosa
        }

    }

}

