using System.ComponentModel.DataAnnotations.Schema;

namespace pruebaAlmacen.Models
{
    public class VentaProductDto
    {
        public Venta Venta { get; set; }
        public Product Product { get; set; }
        public Guid? IdProduct { get; set; }
    }
}
