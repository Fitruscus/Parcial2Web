using Microsoft.AspNetCore.Mvc;
using Web2Parcial.Models;
using Web2Parcial.Services;

namespace Web2Parcial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedorController : ControllerBase
    {
        private readonly ProveedorService _proveedorService;

        public ProveedorController(ProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Proveedor>> Listar() => Ok(_proveedorService.Listar());

        [HttpPost]
        public ActionResult<Proveedor> Crear(Proveedor proveedor)
        {
            var creado = _proveedorService.Crear(proveedor);
            return CreatedAtAction(nameof(Listar), new { id = creado.Id }, creado);
        }
    }
}