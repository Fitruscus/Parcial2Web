namespace Web2Parcial.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string DescripcionCorta { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int IdCategoria { get; set; }
        public int IdProveedor { get; set; }
        public Categoria? Categoria { get; set; }
        public Proveedor? Proveedor { get; set; }
    }
}