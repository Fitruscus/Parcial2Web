using Microsoft.AspNetCore.Mvc;
using Web2Parcial.Models;
using Web2Parcial.Services;

namespace Web2Parcial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _productoService;

        public ProductoController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Listar() => Ok(_productoService.Listar());

        [HttpGet("{id}")]
        public ActionResult<Producto> ObtenerPorId(int id)
        {
            var producto = _productoService.ObtenerPorId(id);
            return producto == null ? NotFound() : Ok(producto);
        }

        [HttpPost]
        public ActionResult<Producto> Crear(Producto producto)
        {
            var creado = _productoService.Crear(producto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.Id }, creado);
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, Producto producto)
        {
            var ok = _productoService.Editar(id, producto);
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var ok = _productoService.Eliminar(id);
            return ok ? NoContent() : NotFound();
        }

        [HttpGet("ordenar/categoria")]
        public ActionResult<IEnumerable<Producto>> OrdenarPorCategoria() => Ok(_productoService.OrdenarPorCategoria());

        [HttpGet("buscar")]
        public ActionResult<IEnumerable<Producto>> BuscarPorNombre([FromQuery] string nombre) => Ok(_productoService.BuscarPorNombre(nombre));

        [HttpGet("proveedor/{idProveedor}")]
        public ActionResult<IEnumerable<Producto>> ListarPorProveedor(int idProveedor) => Ok(_productoService.ListarPorProveedor(idProveedor));
    }
}