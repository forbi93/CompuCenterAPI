using CompuCenterAPI.Data;
using CompuCenterAPI.Models.Domain;
using CompuCenterAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CompuCenterAPI.Repositories.Implementation
{
    public class DetalleVentaRepository : IDetalleVentaRepository
    {
        private readonly ApplicationDbContext dbContext;

        public DetalleVentaRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<DetalleVenta> CrearDetalleVentaAsync(DetalleVenta detalleVenta)
        {
            await dbContext.DetallesVentas.AddAsync(detalleVenta);
            await dbContext.SaveChangesAsync();

            return detalleVenta;
        }

        public async Task<IEnumerable<DetalleVenta>> ObtenerTodosDetallesVentaAsync()
        {
            return await dbContext.DetallesVentas.ToListAsync();
        }
        
        public async Task<DetalleVenta?> ObtenerDetalleVentaPorIdAsync(Guid id)
        {
            return await dbContext.DetallesVentas.FirstOrDefaultAsync(x => x.IdDetalle == id);
        }
    }
}
