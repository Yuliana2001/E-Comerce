﻿using AlmacenDiego.Models;
using System.ComponentModel.DataAnnotations;


namespace pruebaAlmacen.Models
{
    public class VentaDto
    {
        [Required, MaxLength(100)]
        public string Cedula { get; set; }
        [Required, MaxLength(100)]
        public string FirstName { get; set; } = "";
        [Required, MaxLength(100)]
        public string LastName { get; set; } = "";
        [Required, MaxLength(100)]
        public string Address { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        [Required, MaxLength(100)]
        public string Email { get; set; } = "";

        public int Cantidad { get; set; }

        public decimal Total { get; set; }
        public string EstadoPago { get; set; } // Puede ser un código definido por la DIAN
        public string MetodoPago { get; set; } // Puede ser un código definido por la DIAN
    }
}
