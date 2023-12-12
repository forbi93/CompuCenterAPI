using CompuCenterAPI.Models.Domain;
using CompuCenterAPI.Models.DTO.Producto;
using CompuCenterAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompuCenterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepository productoRepository;

        public ProductosController(IProductoRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearProducto(CreateProductoRequestDto request)
        {
            // Mapear DTO a Modelo Domain
            var producto = new Producto
            {
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                PrecioUnitario = request.PrecioUnitario,
                Stock = request.Stock,
                // Otros campos según tu modelo
            };

            await productoRepository.CrearProductoAsync(producto);

            // Modelo Domain a DTO

            var response = new ProductoDto
            {
                IdProducto = producto.IdProducto,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                PrecioUnitario = producto.PrecioUnitario,
                Stock = producto.Stock,
                // Otros campos según tu DTO
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodosProductos()
        {
            var productos = await productoRepository.ObtenerTodosProductosAsync();

            // Mapear Modelo Domain a DTO

            var response = new List<ProductoDto>();

            foreach (var producto in productos)
            {
                response.Add(new ProductoDto
                {
                    IdProducto = producto.IdProducto,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    PrecioUnitario = producto.PrecioUnitario,
                    Stock = producto.Stock,
                    // Otros campos según tu DTO
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> ObtenerProductoPorId([FromRoute] Guid id)
        {
            var existingProducto = await productoRepository.ObtenerProductoPorIdAsync(id);

            if (existingProducto is null)
            {
                return NotFound();
            }

            var response = new ProductoDto
            {
                IdProducto = existingProducto.IdProducto,
                Nombre = existingProducto.Nombre,
                Descripcion = existingProducto.Descripcion,
                PrecioUnitario = existingProducto.PrecioUnitario,
                Stock = existingProducto.Stock,
                // Otros campos según tu DTO
            };

            return Ok(response);
        }

        [HttpPut]
        [Route(("{id:Guid}"))]
        public async Task<IActionResult> ActualizarProducto([FromRoute] Guid id, UpdateProductoRequestDto request)
        {
            // Convertir DTO a Modelo Domain
            var producto = new Producto
            {
                IdProducto = id,
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                PrecioUnitario = request.PrecioUnitario,
                Stock = request.Stock,
                // Otros campos según tu modelo
            };

            producto = await productoRepository.ActualizarProductoAsync(producto);

            if (producto == null)
            {
                return NotFound();
            }

            // Convertir Modelo Domain a DTO
            var response = new ProductoDto
            {
                IdProducto = producto.IdProducto,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                PrecioUnitario = producto.PrecioUnitario,
                Stock = producto.Stock,
                // Otros campos según tu DTO
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EliminarProducto([FromRoute] Guid id)
        {
            var producto = await productoRepository.EliminarProductoAsync(id);

            if (producto is null)
            {
                return NotFound();
            }

            // Convertir Modelo Domain a DTO
            var response = new ProductoDto
            {
                IdProducto = producto.IdProducto,
                Nombre = producto.Nombre,
                Descripcion= producto.Descripcion,
                PrecioUnitario = producto.PrecioUnitario,
                Stock = producto.Stock,
                // Otros campos según tu DTO
            };
            return Ok(response);
        }
    }
}
