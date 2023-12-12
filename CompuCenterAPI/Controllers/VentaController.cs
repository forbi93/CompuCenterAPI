using CompuCenterAPI.Models.Domain;
using CompuCenterAPI.Models.DTO.Venta;
using CompuCenterAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompuCenterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {

        private readonly IVentaRepository ventaRepository;
        private readonly IClienteRepository clienteRepository;
        private readonly IProductoRepository productoRepository;
        private readonly IDetalleVentaRepository detalleVentaRepository;

        public VentaController(
            IVentaRepository ventaRepository,
            IClienteRepository clienteRepository,
            IProductoRepository productoRepository,
            IDetalleVentaRepository detalleVentaRepository)
        {
            this.ventaRepository = ventaRepository;
            this.clienteRepository = clienteRepository;
            this.productoRepository = productoRepository;
            this.detalleVentaRepository = detalleVentaRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVenta([FromBody] CreateVentaRequestDto request)
        {
            // Convert DTO to Domain
            var venta = new Venta
            {
                ClienteId = request.ClienteId,
                FechaVenta = DateTime.UtcNow,
                TotalVenta = 0,
                DetalleVentas = new List<DetalleVenta>()
            };

            foreach (var detalleDto in request.DetalleVentas)
            {
                var producto = await productoRepository.ObtenerProductoPorIdAsync(detalleDto.ProductoId);
                if (producto != null && producto.PrecioUnitario > 0)
                {
                    var detalleVenta = new DetalleVenta
                    {
                        IdProducto = detalleDto.ProductoId,
                        Cantidad = detalleDto.Cantidad,
                        PrecioUnitario = producto.PrecioUnitario
                    };

                    // Calcula el subtotal
                    detalleVenta.Subtotal = detalleVenta.Cantidad * detalleVenta.PrecioUnitario;

                    venta.DetalleVentas.Add(detalleVenta);

                    // Actualiza el totalVenta
                    venta.TotalVenta += detalleVenta.Subtotal;
                }
            }

            venta = await ventaRepository.CrearVentaAsync(venta);

            // Convert Domain Model back to DTO
            var response = new VentaDto
            {
                IdVenta = venta.IdVenta,
                ClienteId = venta.ClienteId,
                FechaVenta = venta.FechaVenta,
                TotalVenta = venta.TotalVenta,
                DetalleVentas = venta.DetalleVentas.Select(detalle => new DetalleVentaDto
                {
                    ProductoId = detalle.IdProducto,
                    Cantidad = detalle.Cantidad,
                    Subtotal = detalle.Subtotal,
                    PrecioUnitario = detalle.PrecioUnitario
                }).ToList(),
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodasVentas()
        {
            try
            {
                var ventas = await ventaRepository.ObtenerTodasVentasConDetallesAsync();

                // Convierte los modelos de dominio a DTOs
                var response = ventas.Select(venta => new VentaDto
                {
                    IdVenta = venta.IdVenta,
                    ClienteId = venta.ClienteId,
                    FechaVenta = venta.FechaVenta,
                    TotalVenta = venta.TotalVenta,
                    DetalleVentas = venta.DetalleVentas.Select(detalle => new DetalleVentaDto
                    {
                        ProductoId = detalle.IdProducto,
                        Cantidad = detalle.Cantidad,
                        Subtotal = detalle.Subtotal,
                        PrecioUnitario = detalle.PrecioUnitario
                        // Agrega más propiedades según sea necesario
                    }).ToList()
                }).ToList();

                return Ok(response); // Retorna 200 OK con la lista de ventas en formato DTO
            }
            catch (Exception ex)
            {
                // Manejo de errores, logueo, etc.
                return StatusCode(500, "Error interno del servidor"); // Retorna 500 Internal Server Error en caso de error
            }
        }

        [HttpGet]
        [Route("{idVenta:Guid}")]
        public async Task<IActionResult> ObtenerVentaPorId([FromRoute] Guid idVenta)
        {
            try
            {
                var venta = await ventaRepository.ObtenerVentaPorIdAsync(idVenta);

                if (venta == null)
                {
                    return NotFound(); // Retorna 404 Not Found si la venta no se encuentra
                }
                
                // Convierte el modelo de dominio a DTO
                var ventaDto = new VentaDto
                {
                    IdVenta = venta.IdVenta,
                    ClienteId = venta.ClienteId,
                    FechaVenta = venta.FechaVenta,
                    TotalVenta = venta.TotalVenta,
                    DetalleVentas = venta.DetalleVentas.Select(detalle => new DetalleVentaDto
                    {
                        ProductoId = detalle.IdProducto,
                        Cantidad = detalle.Cantidad,
                        Subtotal = detalle.Subtotal,
                        PrecioUnitario = detalle.PrecioUnitario
              
                    }).ToList()
                };

                return Ok(ventaDto); // Retorna 200 OK con la venta en formato DTO
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor"); // Retorna 500 Internal Server Error en caso de error
            }
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EliminarVenta([FromRoute] Guid id)
        {
            var ventaEliminada = await ventaRepository.EliminarVentaAsync(id);

            if (ventaEliminada == null)
            {
                return NotFound();
            }

            // Convert Domain model to DTO

            var response = new VentaDto
            {
                IdVenta = ventaEliminada.IdVenta,
                ClienteId = ventaEliminada.ClienteId,
                FechaVenta = ventaEliminada.FechaVenta,
                TotalVenta = ventaEliminada.TotalVenta,
            };

            return Ok(response);

        }

    }
}
