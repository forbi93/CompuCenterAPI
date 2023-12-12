using System.ComponentModel.DataAnnotations;

namespace CompuCenterAPI.Models.Domain
{
    public class DetalleVenta
    {
        [Key]
        public Guid IdDetalle { get; set; }
        public Guid IdProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        // public Guid VentaId { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public int CorrelativoNumeroVenta { get; set; }

        public ICollection<Producto> Productos { get; set; }
        public ICollection<Venta> Ventas { get; set; }
    }
}
