using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using WebShop.Data;
using WebShop.Dto;

namespace WebShop.Controllers
{
    public class CartController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddToCart(int? id)
        {      
            var p = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();

            return RedirectToAction("Index");
        }
    }
}
