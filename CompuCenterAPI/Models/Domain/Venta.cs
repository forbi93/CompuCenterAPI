using System.ComponentModel.DataAnnotations;

namespace CompuCenterAPI.Models.Domain
{
    public class Venta
    {
        [Key]
        public Guid IdVenta { get; set; }
        public Guid ClienteId { get; set; } // Add this property
        public DateTime FechaVenta { get; set; }
        public decimal TotalVenta { get; set; }

        public Cliente Cliente { get; set; }
        public ICollection<DetalleVenta> DetalleVentas { get; set; }
    }
}
