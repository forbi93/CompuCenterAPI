using CompuCenterAPI.Data;
using CompuCenterAPI.Models.Domain;
using CompuCenterAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CompuCenterAPI.Repositories.Implementation
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ClienteRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Cliente?> ActualizarClienteAsync(Cliente cliente)
        {
            var existingCliente = await dbContext.Clientes.FirstOrDefaultAsync(x => x.IdCliente == cliente.IdCliente);

            if (existingCliente != null) 
            {
                dbContext.Entry(existingCliente).CurrentValues.SetValues(cliente);
                await dbContext.SaveChangesAsync();
                return cliente;
            }

            return null;
        }

        public async Task<Cliente> CrearClienteAsync(Cliente cliente)
        {
            await dbContext.Clientes.AddAsync(cliente);
            await dbContext.SaveChangesAsync();

            return cliente;
        }

        public async Task<Cliente?> EliminarClienteAsync(Guid id)
        {
            var existingCliente = await dbContext.Clientes.FirstOrDefaultAsync(x => x.IdCliente == id);

            if(existingCliente is null)
            {
                return null;
            }

            dbContext.Clientes.Remove(existingCliente);
            await dbContext.SaveChangesAsync();
            return existingCliente;
        }

        public async Task<Cliente?> ObtenerClientePorIdAsync(Guid id)
        {
            return await dbContext.Clientes.FirstOrDefaultAsync( x  => x.IdCliente == id);
        }

        public async Task<IEnumerable<Cliente>> ObtenerTodosClientesAsync()
        {
            return await dbContext.Clientes.ToListAsync();
        }
    }
}
