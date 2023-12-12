namespace CompuCenterAPI.Models.DTO.Venta
{
    public class VentaDto
    {
        public Guid IdVenta { get; set; }
        public Guid ClienteId { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal TotalVenta { get; set; }
        public List<DetalleVentaDto> DetalleVentas { get; set; } = new List<DetalleVentaDto>();
    }
}
