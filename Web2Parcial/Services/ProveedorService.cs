using Web2Parcial.Models;

namespace Web2Parcial.Services
{
    public class ProveedorService
    {
        private readonly List<Proveedor> _proveedores = new();
        private int _nextId = 1;

        public IEnumerable<Proveedor> Listar() => _proveedores;

        public Proveedor? ObtenerPorId(int id) => _proveedores.FirstOrDefault(p => p.Id == id);

        public Proveedor Crear(Proveedor proveedor)
        {
            proveedor.Id = _nextId++;
            _proveedores.Add(proveedor);
            return proveedor;
        }
    }
}