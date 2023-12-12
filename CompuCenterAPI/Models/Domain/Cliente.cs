using System.ComponentModel.DataAnnotations;

namespace CompuCenterAPI.Models.Domain
{
    public class Cliente
    {
        [Key]
        public Guid IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public ICollection<Venta> Ventas { get; set; }

        // Relación con Venta
        // public List<Venta> Ventas { get; set; }
    }
}
