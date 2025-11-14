using Web2Parcial.Models;

namespace Web2Parcial.Services
{
    public class ProductoService
    {
        private readonly List<Producto> _productos = new();
        private int _nextId = 1;

        public IEnumerable<Producto> Listar() => _productos;

        public Producto? ObtenerPorId(int id) => _productos.FirstOrDefault(p => p.Id == id);

        public Producto Crear(Producto producto)
        {
            producto.Id = _nextId++;
            _productos.Add(producto);
            return producto;
        }

        public bool Editar(int id, Producto producto)
        {
            var existente = ObtenerPorId(id);
            if (existente == null) return false;
            existente.Nombre = producto.Nombre;
            existente.DescripcionCorta = producto.DescripcionCorta;
            existente.Precio = producto.Precio;
            existente.Stock = producto.Stock;
            existente.IdCategoria = producto.IdCategoria;
            return true;
        }

        public bool Eliminar(int id)
        {
            var producto = ObtenerPorId(id);
            if (producto == null) return false;
            _productos.Remove(producto);
            return true;
        }

        public IEnumerable<Producto> OrdenarPorCategoria() => _productos.OrderBy(p => p.IdCategoria);

        public IEnumerable<Producto> BuscarPorNombre(string nombre) => _productos.Where(p => p.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));

        public IEnumerable<Producto> ListarPorProveedor(int idProveedor) => _productos.Where(p => p.IdProveedor == idProveedor);

    }
}