using CompuCenterAPI.Models.DTO.Venta;

namespace CompuCenterAPI.Models.DTO.Cliente
{
    public class ClienteDto
    {
        public Guid IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public List<VentaDto> Ventas { get; set; } = new List<VentaDto>();
    }
}
