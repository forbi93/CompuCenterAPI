using CompuCenterAPI.Models.Domain;

namespace CompuCenterAPI.Repositories.Interface
{
    public interface IVentaRepository
    {
        Task<Venta> CrearVentaAsync(Venta cliente);
        Task<IEnumerable<Venta>> ObtenerTodasVentasAsync();
        Task<Venta?> ObtenerVentaPorIdAsync(Guid id);
        //Task<Venta?> ObtenerVentaConDetallePorIdAsync(Guid id);
        Task<Venta?> ActualizarVentaAsync(Venta venta);
        Task<List<Venta>> ObtenerTodasVentasConDetallesAsync();
        Task<Venta?> EliminarVentaAsync(Guid id);
        Task<List<Venta>> ObtenerVentasPorClienteIdAsync(Guid clienteId);
    }
}
