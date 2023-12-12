namespace CompuCenterAPI.Models.DTO.Cliente
{
    public class UpdateClienteRequestDto
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
