using APIStock.Entities;

namespace APIStock.DTOs
{
    public class CategoriaDTO
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public bool EsDestacada { get; set; }

    }
}
