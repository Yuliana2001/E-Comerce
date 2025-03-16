using AlmacenDiego.Models;
using AlmacenDiego.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using pruebaAlmacen.Models;

namespace pruebaAlmacen.Pages
{
    public class FacturacionModel : PageModel
    {
        private readonly ApplicationDbContext context;
        public List<VentaProduct> VentaProduct { get; set; } = new List<VentaProduct>();

        public VentaProduct VentaProducts { get; set; } = new VentaProduct();

        public string errorMessage = "";
        public string successMessage = "";
        public FacturacionModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            VentaProduct = context.VentaProduct.OrderByDescending(vp => vp.IdProduct).ToList();
        }
    }
}
