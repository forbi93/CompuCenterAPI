namespace CompuCenterAPI.Models.DTO.Cliente
{
    public class CreateClienteRequestDto
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
