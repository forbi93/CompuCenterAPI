using CompuCenterAPI.Data;
using CompuCenterAPI.Models.Domain;
using CompuCenterAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CompuCenterAPI.Repositories.Implementation
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ProductoRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Producto> CrearProductoAsync(Producto producto)
        {
            await dbContext.Productos.AddAsync(producto);
            await dbContext.SaveChangesAsync();

            return producto;
        }

        public async Task<IEnumerable<Producto>> ObtenerTodosProductosAsync()
        {
            return await dbContext.Productos.ToListAsync();
        }

        public async Task<Producto?> ObtenerProductoPorIdAsync(Guid id)
        {
            return await dbContext.Productos.FirstOrDefaultAsync(x => x.IdProducto == id);
        }

        public async Task<Producto?> ActualizarProductoAsync(Producto producto)
        {
            var existingProducto = await dbContext.Productos.FirstOrDefaultAsync(x => x.IdProducto == producto.IdProducto);

            if (existingProducto != null)
            {
                dbContext.Entry(existingProducto).CurrentValues.SetValues(producto);
                await dbContext.SaveChangesAsync();
                return producto;
            }

            return null;
        }

        public async Task<Producto?> EliminarProductoAsync(Guid id)
        {
            var existingProducto = await dbContext.Productos.FirstOrDefaultAsync(x => x.IdProducto == id);

            if (existingProducto is null)
            {
                return null;
            }

            dbContext.Productos.Remove(existingProducto);
            await dbContext.SaveChangesAsync();
            return existingProducto;
        }
    }
}
