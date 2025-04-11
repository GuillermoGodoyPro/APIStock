using APIStock.DTOs;
using APIStock.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _categoriaService;

        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<List<CategoriaDTO>>> Get()
        {
            return Ok(await _categoriaService.Lista());
        }


        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<CategoriaDTO>> Get(int id)
        {

            var categoria = await _categoriaService.ListarUno(id);
            if (categoria is null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpPost]
        [Route("guardar")]
        public async Task<ActionResult<CategoriaDTO>> Post(CategoriaDTO categoriaDTO)
        {
            var categoria = await _categoriaService.GuardarCategoria(categoriaDTO);
            if (categoria is null)
            {
                return NotFound();
            }
            return Ok("Categoría guardada");

        }

        [HttpPut]
        [Route("editar")]
        public async Task<ActionResult<CategoriaDTO>> Put(CategoriaDTO categoriaDTO)
        {
            var categoria = await _categoriaService.EditarCategoria(categoriaDTO);
            if (categoria is null)
            {
                return NotFound();
            }
            return Ok(categoriaDTO);

        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public async Task<ActionResult<CategoriaDTO>> Delete(int id)
        {
            var categoria = await _categoriaService.EliminarCategoria(id);
            if (categoria == false)
            {
                return NotFound();
            }
            return Ok("Categoría eliminado");
        }
    }
}
