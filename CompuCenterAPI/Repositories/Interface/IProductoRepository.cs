using CompuCenterAPI.Models.Domain;

namespace CompuCenterAPI.Repositories.Interface
{
    public interface IProductoRepository
    {
        Task<Producto> CrearProductoAsync(Producto producto);
        Task<IEnumerable<Producto>> ObtenerTodosProductosAsync();
        Task<Producto?> ObtenerProductoPorIdAsync(Guid id);
        Task<Producto?> EliminarProductoAsync(Guid id);
        Task<Producto?> ActualizarProductoAsync(Producto producto);
    }
}
