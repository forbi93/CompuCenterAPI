namespace CompuCenterAPI.Models.DTO.Venta
{
    public class CreateVentaRequestDto
    {
        public Guid ClienteId { get; set; }
        public decimal? TotalVenta { get; set; }
        public List<DetalleVentaDto> DetalleVentas { get; set; }
    }
}
