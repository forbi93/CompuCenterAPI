using CompuCenterAPI.Models.Domain;

namespace CompuCenterAPI.Repositories.Interface
{
    public interface IDetalleVentaRepository
    {
        Task<DetalleVenta> CrearDetalleVentaAsync(DetalleVenta detalleVenta);
        Task<IEnumerable<DetalleVenta>> ObtenerTodosDetallesVentaAsync();
        Task<DetalleVenta?> ObtenerDetalleVentaPorIdAsync(Guid id);
    }
}
