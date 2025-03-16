using AlmacenDiego.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pruebaAlmacen.Models
{
   
    public class VentaProduct
    {
        [Key]
        public Guid Id { get; set; } // Propiedad de identidad y clave primaria
        public Venta Venta { get; set; }

        public Guid? IdProduct { get; set; }
    }
}
