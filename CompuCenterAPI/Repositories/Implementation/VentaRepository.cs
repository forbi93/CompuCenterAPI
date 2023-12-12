using CompuCenterAPI.Data;
using CompuCenterAPI.Models.Domain;
using CompuCenterAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CompuCenterAPI.Repositories.Implementation
{
    public class VentaRepository: IVentaRepository
    {
        private readonly ApplicationDbContext dbContext;

        public VentaRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Venta?> ActualizarVentaAsync(Venta venta)
        {
            var existingVenta = await dbContext.Ventas.Include(x => x.Cliente)
                .FirstOrDefaultAsync(x => x.IdVenta == venta.IdVenta);

            if(existingVenta == null) 
            {
                return null;
            }

            dbContext.Entry(existingVenta).CurrentValues.SetValues(venta);

            //Actualizar Cliente
            existingVenta.Cliente = venta.Cliente;

            await dbContext.SaveChangesAsync();
            return venta;
        }

        public async Task<Venta> CrearVentaAsync(Venta cliente)
        {
            await dbContext.Ventas.AddAsync(cliente);
            await dbContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<Venta?> EliminarVentaAsync(Guid id)
        {
            var existingVenta = await dbContext.Ventas.FirstOrDefaultAsync(x => x.IdVenta == id);

            if (existingVenta != null)
            {
                dbContext.Ventas.Remove(existingVenta);
                await dbContext.SaveChangesAsync();
                return existingVenta;
            }

            return null;
        }

        public async Task<IEnumerable<Venta>> ObtenerTodasVentasAsync()
        {
            return await dbContext.Ventas.Include(x => x.Cliente).ToListAsync();
        }

        public async Task<List<Venta>> ObtenerTodasVentasConDetallesAsync()
        {

            return await dbContext.Ventas
                .Include(v => v.DetalleVentas)
                    .ThenInclude(d => d.Productos)
                .ToListAsync();
        }

        public async Task<Venta?> ObtenerVentaPorIdAsync(Guid id)
        {
            var venta = await dbContext.Ventas
            .Include(v => v.DetalleVentas)
            .FirstOrDefaultAsync(v => v.IdVenta == id);

            return venta;
        }

        public async Task<List<Venta>> ObtenerVentasPorClienteIdAsync(Guid clienteId)
        {
            return await dbContext.Ventas
                .Where(v => v.ClienteId == clienteId)
                .Include(v => v.DetalleVentas) 
                .ToListAsync();
        }


    }
}
