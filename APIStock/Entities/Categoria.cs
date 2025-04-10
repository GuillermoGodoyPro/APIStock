namespace APIStock.Entities
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public bool EsDestacada { get; set; }

        public int IdProducto { get; set; }
        public ICollection<Producto> ProductoReferencia { get; set; }

    }
}
