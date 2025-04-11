using APIStock.Context;
using APIStock.DTOs;
using APIStock.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIStock.Services
{
    public class CategoriaService
    {
        private readonly AppDbContext _context;
        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoriaDTO>> Lista()
        {
            var listaCategoriasDTO = new List<CategoriaDTO>();
            var listaCategoriasDB = await _context.Categorias.ToListAsync();

            foreach (var item in listaCategoriasDB)
            {
                listaCategoriasDTO.Add(new CategoriaDTO
                {
                    IdCategoria = item.IdCategoria,
                    Nombre = item.Nombre,
                    EsDestacada = item.EsDestacada,                   

                });
            }

            return listaCategoriasDTO;
        }

        public async Task<CategoriaDTO> ListarUno(int id)
        {
            var categoriaDTO = new CategoriaDTO();
            var categoriaDB = await _context.Categorias.FirstAsync();

            categoriaDTO.IdCategoria = id;
            categoriaDTO.Nombre = categoriaDB.Nombre;
            categoriaDTO.EsDestacada = categoriaDB.EsDestacada;
            

            return categoriaDTO;
        }

        public async Task<CategoriaDTO> GuardarCategoria(CategoriaDTO categoriaDTO)
        {
            var categoriaDB = new Categoria
            {
                Nombre = categoriaDTO.Nombre,
                EsDestacada= categoriaDTO.EsDestacada                
            };

            _context.Categorias.Add(categoriaDB);
            await _context.SaveChangesAsync();

            return categoriaDTO;

        }

        public async Task<CategoriaDTO> EditarCategoria(CategoriaDTO categoriaDTO)
        {
            var categoriaDB = await _context.Categorias.FindAsync(categoriaDTO.IdCategoria);

            if (categoriaDB is null)
            {
                return null; 
            }
                       
            categoriaDB.Nombre = categoriaDTO.Nombre;
            categoriaDB.EsDestacada = categoriaDTO.EsDestacada;
            

            _context.Categorias.Update(categoriaDB);
            await _context.SaveChangesAsync();

            return categoriaDTO;
        }

        public async Task<bool> EliminarCategoria(int id)
        {

            var categoriaDB = await _context.Categorias.FindAsync(id);

            if (categoriaDB is null)
            {
                return false; 
            }

            _context.Categorias.Remove(categoriaDB);
            await _context.SaveChangesAsync();
            return true; 
        }


    }

}

