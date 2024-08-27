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

        // Cart overview
        public IActionResult Index()
        {
            CartDto cartDto = new CartDto();

            Cart c = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            int? n = HttpContext.Session.GetJson<int>("prodsInCart");
            cartDto.Cart = c;
            cartDto.TotQuantityInCart = n;

            return View(cartDto);
        }

        //public IActionResult Checkout()
        //{
        //    return View();
        //}


        // Adds the product with id = Product.Id to the cart
        public async Task<IActionResult> AddToCart(int? id)
        {
            var p = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();


            if (p != null)
            {
                Cart c = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                c.AddOneItem(p, 1);
                HttpContext.Session.SetJson("cart", c);

                int? n = HttpContext.Session.GetJson<int>("prodsInCart");
                if (n != null)
                {
                    n = n + 1;
                }
                else
                {
                    n = 1;
                }
                HttpContext.Session.SetJson("prodsInCart", n);

                string t = (string)HttpContext.Request.Headers.Referer;
                if (t != null)
                {
                    if (!t.EndsWith("/Cart"))
                    {
                        return RedirectToAction("ShowProduct", "Categories", new { id = p.CategoryId });
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> RemoveOneFromCart(int? id)
        {
            var p = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();


            if (p != null)
            {
                Cart c = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

                c.RemoveOneItem(p);
                HttpContext.Session.SetJson("cart", c);

                int? n = HttpContext.Session.GetJson<int>("prodsInCart");
                if (n != null)
                {
                    n = n - 1;
                }

                HttpContext.Session.SetJson("prodsInCart", n);


                return RedirectToAction("Index");


            }
            return RedirectToAction("Index");
        }
    }
}
