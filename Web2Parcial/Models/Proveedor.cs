namespace Web2Parcial.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; } = string.Empty;
        public string Contacto { get; set; } = string.Empty;
        public ICollection<Producto>? Productos { get; set; }
    }
}