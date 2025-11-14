using Microsoft.AspNetCore.Mvc;
using Web2Parcial.Models;
using Web2Parcial.Services;

namespace Web2Parcial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _categoriaService;

        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Listar() => Ok(_categoriaService.Listar());

        [HttpPost]
        public ActionResult<Categoria> Crear(Categoria categoria)
        {
            var creado = _categoriaService.Crear(categoria);
            return CreatedAtAction(nameof(Listar), new { id = creado.Id }, creado);
        }
    }
}