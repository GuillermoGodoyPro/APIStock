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

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<ProductoDTO>> Get(int id)
        {

            var producto = await _productoService.ListarUno(id);
            if (producto is null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost]
        [Route("guardar")]
        public async Task<ActionResult<ProductoDTO>> Post(ProductoDTO productoDTO)
        {
            var producto = await _productoService.GuardarProducto(productoDTO);
            if (producto is null)
            {
                return NotFound();
            }
            return Ok("Producto guardado");

        }

        [HttpPut]
        [Route("editar")]
        public async Task<ActionResult<ProductoDTO>> Put(ProductoDTO productoDTO)
        {
            var producto = await _productoService.EditarProducto(productoDTO);
            if (producto is null)
            {
                return NotFound();
            }
            return Ok(productoDTO);

        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public async Task<ActionResult<ProductoDTO>> Delete(int id)
        {
            var producto = await _productoService.EliminarProducto(id);
            if (producto == false)
            {
                return NotFound();
            }
            return Ok("Producto eliminado");
        }


    }
}
