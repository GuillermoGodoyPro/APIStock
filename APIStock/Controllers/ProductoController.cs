using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using APIStock.DTOs;
using APIStock.Services;
using APIStock.Context;

namespace APIStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _productoService;

        public ProductoController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<List<ProductoDTO>>> Get()
        {
            return Ok(await _productoService.Lista());
        }

    }
}
