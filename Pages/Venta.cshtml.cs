using AlmacenDiego.Models;
using AlmacenDiego.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using pruebaAlmacen.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaAlmacen.Pages
{
    [Authorize(Roles = "admin,seller")]
    public class VentaModel : PageModel
    {
        private readonly ApplicationDbContext context;
        public Product Products { get; set; }
        public List<Product> Productos { get; set; } = new List<Product>();
        public VentaProduct VentaProducts { get; set; }

        [BindProperty]
        public VentaDto VentaDto { get; set; } = new VentaDto();
        public VentaProductDto VentaProductDto { get; set; }= new VentaProductDto();
        public VentaModel(ApplicationDbContext context)
        {
            this.context = context;


        }
        public void OnGet()
        {
            Productos = context.Products.Select(p => new Product
            {
                Name = p.Name,
                Id= p.Id
            }).ToList();

        }
        public string errorMessage = "";
        public string successMessage = "";
        public async Task<IActionResult> OnPostAsync() // Cambiado el tipo de retorno a Task<IActionResult>
        {
            if (!ModelState.IsValid)
            {
                errorMessage = "Por favor, llena todos los campos";
                return Page(); // Devolver la página con los errores de validación
            }




            var selectedProductIds = VentaProductDto.IdProduct;
            VentaProduct ventapro = new VentaProduct()
            {

                Venta = new Venta()
                {

                    Cedula = VentaDto.Cedula,
                    FirstName = VentaDto.FirstName,
                    LastName = VentaDto.LastName,
                    Address = VentaDto.Address,
                    PhoneNumber = VentaDto.PhoneNumber,
                    Email = VentaDto.Email,
                    Cantidad = VentaDto.Cantidad,
                    Total = VentaDto.Total,
                    EstadoPago = VentaDto.EstadoPago,
                    MetodoPago = VentaDto.MetodoPago
                },
                IdProduct = VentaProductDto.IdProduct


            };



            context.Ventas.Add(ventapro.Venta);
            context.VentaProduct.Add(ventapro);
            await context.SaveChangesAsync();

            // Limpiar todo
            VentaDto.Cedula = "";
            VentaDto.FirstName = "";
            VentaDto.LastName = "";
            VentaDto.Address = "";
            VentaDto.PhoneNumber = "";
            VentaDto.Email = "";
            VentaDto.Cantidad = 0;
            VentaDto.Total = 0;
            VentaDto.EstadoPago = "";
            VentaDto.MetodoPago = "";
            VentaProductDto.IdProduct = null;

            ModelState.Clear();
            successMessage = "Factura creada con éxito";
            return RedirectToPage("/Facturacion");
        }
    }
}
