namespace APIStock.DTOs
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string? NombreCategoria { get; set; }
        public int IdCategoria { get; set; }
    }
}
