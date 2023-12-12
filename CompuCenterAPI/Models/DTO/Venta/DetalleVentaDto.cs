namespace CompuCenterAPI.Models.DTO.Venta
{
    public class DetalleVentaDto
    {
        public Guid ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? PrecioUnitario { get; set; }
    }
}
