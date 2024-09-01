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

        // Get: Checkout overview
        public IActionResult Checkout()
        {
            CheckoutDto checkoutDto = new CheckoutDto();

            Cart c = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            int? n = HttpContext.Session.GetJson<int>("prodsInCart");
            double? tc = HttpContext.Session.GetJson<double>("totOrderCost");

            checkoutDto.Cart = c;
            checkoutDto.TotQuantityInCart = n;

            if (checkoutDto.TotOrderCost !=null && checkoutDto.TotOrderCost==0)
            {
                checkoutDto.TotOrderCost = c.CartTotValue();  // init-value before freight is added
            }
            else if (checkoutDto.TotOrderCost != null && checkoutDto.TotOrderCost!=0)
            {
                checkoutDto.TotOrderCost = c.CartTotValue() + (double)tc;
            }

            return View(checkoutDto);
        }

        [HttpPost]    // Change freightcost and totOrderCost by ajax, sendback totOrderCost
        public IActionResult ChangeFreight(string? selected_val)
        {
            double res = 0;
            if (selected_val != null)
            {
                res = Convert.ToDouble(selected_val);


                CheckoutDto checkoutDto = new CheckoutDto();

                Cart c = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                int? n = HttpContext.Session.GetJson<int>("prodsInCart");
                double? tc = HttpContext.Session.GetJson<double>("totOrderCost");


                checkoutDto.Cart = c;
                checkoutDto.TotQuantityInCart = n;
                checkoutDto.TotOrderCost = c.CartTotValue() + res;
                HttpContext.Session.SetJson("totOrderCost", checkoutDto.TotOrderCost);
                HttpContext.Session.SetJson("freightCost", res);

                return Json(HttpContext.Session.GetJson<double>("totOrderCost"));
            }
            return Json(null);
        }

        [HttpPost]
        public IActionResult OrderForm(CheckoutDto chDto)
        {
            if (chDto!=null)
            {
                      
                var j = 23;
               



            }
            return View(null);
        }


        // Post: Adds the product with id = Product.Id to the cart
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
                    if (!t.EndsWith("/Cart"))   // adding from cart
                    {
                        return RedirectToAction("ShowProduct", "Categories", new { id = p.CategoryId });
                    }
                    else
                    {
                        return RedirectToAction("Index");   // adding from category-page
                    }
                }
            }
            return RedirectToAction("Index");
        }


        // Post: Removes one product with id = Product.Id from the cart
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
