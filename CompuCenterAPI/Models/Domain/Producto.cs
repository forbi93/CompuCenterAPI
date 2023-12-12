using System.ComponentModel.DataAnnotations;

namespace CompuCenterAPI.Models.Domain
{
    public class Producto
    {
        [Key]
        public Guid IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Stock { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

        // Relación con DetalleVenta
        public List<DetalleVenta> DetallesVenta { get; set; }
    }
}
