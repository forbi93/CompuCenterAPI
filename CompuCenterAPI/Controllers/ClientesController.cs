using CompuCenterAPI.Models.Domain;
using CompuCenterAPI.Models.DTO;
using CompuCenterAPI.Models.DTO.Cliente;
using CompuCenterAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompuCenterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCliente(CreateClienteRequestDto request)
        {
            // Mapear DTO a Modelo Domain
            var cliente = new Cliente
            {
                Nombre = request.Nombre,
                Direccion = request.Direccion,
                Telefono = request.Telefono,
                Correo = request.Correo,
                FechaCreacion = request.FechaCreacion
            };

            await clienteRepository.CrearClienteAsync(cliente);

            // Modelo Domain a DTO

            var response = new ClienteDto
            {
                IdCliente = cliente.IdCliente,
                Nombre = cliente.Nombre,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono,
                Correo = cliente.Correo,
                FechaCreacion = cliente.FechaCreacion,

            };

            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodosClientes()
        {
            var clientes = await clienteRepository.ObtenerTodosClientesAsync();

            // Mapear Modelo Domain a DTO

            var response = new List<ClienteDto>();

            foreach(var cliente in clientes)
            {
                response.Add(new ClienteDto
                {
                    IdCliente = cliente.IdCliente,
                    Nombre = cliente.Nombre,
                    Direccion = cliente.Direccion,
                    Telefono = cliente.Telefono,
                    Correo = cliente.Correo,
                    FechaCreacion = cliente.FechaCreacion,
                    FechaActualizacion = cliente.FechaActualizacion,
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> ObtenerClientePorId([FromRoute] Guid id)
        {
            var existingClliente = await clienteRepository.ObtenerClientePorIdAsync(id);

            if(existingClliente is null)
            {
                return NotFound();
            }

            var response = new ClienteDto
            {
                IdCliente = existingClliente.IdCliente,
                Nombre = existingClliente.Nombre,
                Direccion = existingClliente.Direccion,
                Telefono = existingClliente.Telefono,
                Correo = existingClliente.Correo,
                FechaCreacion = existingClliente.FechaCreacion,
                FechaActualizacion = existingClliente.FechaActualizacion,
            };
            return Ok(response);
        }

        [HttpPut]
        [Route(("{id:Guid}"))]
        public async Task<IActionResult> ActualizarCliente([FromRoute]Guid id, UpdateClienteRequestDto request)
        {
            // Convertir DTO a Modelo Domain
            var cliente = new Cliente
            {
                IdCliente = id,
                Nombre = request.Nombre,
                Direccion = request.Direccion,
                Telefono = request.Telefono,
                Correo = request.Correo,
                FechaActualizacion = request.FechaActualizacion,
            };

            cliente = await clienteRepository.ActualizarClienteAsync(cliente);

            if(cliente == null)
            {
                return NotFound();
            }

            // Convertir Modelo Domain a DTO
            var response = new ClienteDto
            {
                IdCliente = cliente.IdCliente,
                Nombre = cliente.Nombre,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono,
                Correo = cliente.Correo,
                FechaActualizacion = cliente.FechaActualizacion,
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EliminarCliente([FromRoute] Guid id)
        {
            var cliente = await clienteRepository.EliminarClienteAsync(id);

            if(cliente is null)
            {
                return NotFound();
            }

            // Convertir Modelo Domain a DTO
            var response = new ClienteDto
            {
                IdCliente = cliente.IdCliente,
                Nombre = cliente.Nombre,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono,
                Correo = cliente.Correo,
                FechaCreacion = cliente.FechaCreacion,
                FechaActualizacion = cliente.FechaActualizacion,
            };
            return Ok(response);
        }
    }
}
