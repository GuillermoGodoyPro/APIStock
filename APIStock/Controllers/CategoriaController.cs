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

    }
}
