using APIStock.Context;
using APIStock.DTOs;
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
    }

}

