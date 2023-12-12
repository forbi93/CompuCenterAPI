using CompuCenterAPI.Models.Domain;

namespace CompuCenterAPI.Repositories.Interface
{
    public interface IClienteRepository
    {
        Task<Cliente> CrearClienteAsync(Cliente cliente);
        Task<IEnumerable<Cliente>> ObtenerTodosClientesAsync();
        Task<Cliente?> ObtenerClientePorIdAsync(Guid id);
        Task<Cliente?> ActualizarClienteAsync(Cliente cliente);
        Task<Cliente?> EliminarClienteAsync(Guid id);
    }
}
