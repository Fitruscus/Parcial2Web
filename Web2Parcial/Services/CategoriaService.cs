using Web2Parcial.Models;

namespace Web2Parcial.Services
{
    public class CategoriaService
    {
        private readonly List<Categoria> _categorias = new();
        private int _nextId = 1;

        public IEnumerable<Categoria> Listar() => _categorias;

        public Categoria? ObtenerPorId(int id) => _categorias.FirstOrDefault(c => c.Id == id);

        public Categoria Crear(Categoria categoria)
        {
            categoria.Id = _nextId++;
            _categorias.Add(categoria);
            return categoria;
        }
    }
}