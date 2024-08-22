using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using WebShop.Data;
using WebShop.Dto;
using WebShop.Infrastructure;
using WebShop.Models;

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

     
            if (p != null)
            {
                Cart c = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                c.AddOneItem(p, 1);
                HttpContext.Session.SetJson("cart", c);

                int? n = HttpContext.Session.GetJson<int>("prodsInCart");
                if (n!=null)
                {
                    n = n + 1;
                }
                else
                {
                    n = 1;
                }
                HttpContext.Session.SetJson("prodsInCart",n);

                string t = (string)HttpContext.Request.Headers.Referer;
                if (t != null)
                {
                    return RedirectToAction("ShowProduct", "Categories", new { id = p.CategoryId });
                }
                
            }
            return RedirectToAction("Index");
        }
    }
}
