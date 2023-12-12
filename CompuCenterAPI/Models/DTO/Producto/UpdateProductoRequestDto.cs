namespace CompuCenterAPI.Models.DTO.Producto
{
    public class UpdateProductoRequestDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Stock { get; set; }
    }
}
