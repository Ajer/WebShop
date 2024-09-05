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
            HttpContext.Session.SetJson("freightCost", 0);    // init-value=0 : PostNord Standard 2-3 dagar 0:-

            checkoutDto.Cart = c;
            checkoutDto.TotQuantityInCart = n;


            if (checkoutDto.TotOrderCost != null && checkoutDto.TotOrderCost == 0)
            {
                checkoutDto.TotOrderCost = c.CartTotValue();  // init-value before freight is added
            }
            else if (checkoutDto.TotOrderCost != null && checkoutDto.TotOrderCost != 0)
            {
                checkoutDto.TotOrderCost = c.CartTotValue() + (double)tc;
            }

            HttpContext.Session.SetJson("totOrderCost", checkoutDto.TotOrderCost);

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

                //double? tc = HttpContext.Session.GetJson<double>("totOrderCost");

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
            if (chDto != null)
            {
                Cart c = HttpContext.Session.GetJson<Cart>("cart");
                int? n = HttpContext.Session.GetJson<int>("prodsInCart");
                double? tc = HttpContext.Session.GetJson<double>("totOrderCost");
                double? fc = HttpContext.Session.GetJson<double>("freightCost");

                if (c != null && n != null && tc != null && fc != null)
                {
                    Customer cust = new Customer    //  Create ordering Customer
                    {
                        Email = chDto.Email,
                        FirstName = chDto.FirstName,
                        LastName = chDto.LastName,
                        Address = chDto.Address,
                        Zip = chDto.Zip,
                        City = chDto.City,
                        Country = chDto.Country
                    };
                    _context.Customers.Add(cust);
                    _context.SaveChanges();


                    int custId = cust.Id;      // Get Id of created customer

                    string freight_option = "";
                    switch (fc)
                    {
                        case 0:
                            freight_option = "PostNord Standard 2-3 dagar 0:-";
                            break;
                        case 19:
                            freight_option = "DBSchenker Standard 2-3 dagar 19:-";
                            break;
                        case 39:
                            freight_option = "Postnord Express 1 dag 39:-";
                            break;
                        case 49:
                            freight_option = "DBSchenker Express 1 dag 49:-";
                            break;
                    }

                    Order order = new Order     // Add to Order-table
                    {
                        OrderDate = DateTime.Now,
                        TotOrderCost = (double)tc,
                        FreightCost = (double)fc,
                        FreightOptionName = freight_option,
                        PaymentOption = chDto.PaymentMethod,
                        CustomerId = custId
                    };
                    _context.Orders.Add(order);
                    _context.SaveChanges();

                    int orderId = order.Id;

                    foreach (var l in c.Lines)    // Add to OrderCartLine-table
                    {
                        var oc = new OrderCartLine
                        {
                            OrderId = orderId,
                            Quantity = l.Quantity,
                            ProdId = l.Product.Id
                        };
                        _context.OrderCartLines.Add(oc);


                        var p = _context.Products.Where(p => p.Id == l.Product.Id).FirstOrDefault();   // Change QuantityInstore
                        if (p != null)
                        {
                            p.QuantityInStore = p.QuantityInStore - l.Quantity;
                            _context.Products.Update(p);
                        }
                    }
                    _context.SaveChanges();   // adds ordercartlines and updates product quantities

                    HttpContext.Session.SetJson("prodsInCart", 0);   // Visa tom cart
       

                    return View("OrderThankYou", order);
                }
            }
            return RedirectToAction("Checkout");
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
                    if (t.EndsWith("/Cart"))     // adding from cart 
                    {
                        return RedirectToAction("Index");                         
                    }
                    else if(t.Contains("/Search?"))  // adding from search-page
                    {
                        string q1 = "";
                        int q2 = 0;
                        

                        int ind = t.IndexOf("srch=");
                        if (ind != -1)
                        {
                            string? str = t.Substring(ind + 5);

                            if (str.Contains("&showPage="))
                            {
                                int ind2 = str.IndexOf("&showPage=");
                                if (ind2 != -1)
                                {
                                    q1 = str.Substring(0, ind2);
                                    string? s = str.Substring(ind2 + 10);
                                    bool r = int.TryParse(s, out q2);
                                }
                            }
                            else
                            {
                                q1 = str;
                            }
                        }                     

                        return RedirectToAction("Search", "Products", new { srch = q1, showPage=q2 });
                    }
                    else if (t.EndsWith("/ShowDiscountProduct"))     // adding from discount-page
                    {
                        return RedirectToAction("ShowDiscountProduct", "Categories");
                    }
                    else    // adding from category-page
                    {
                        return RedirectToAction("ShowProduct", "Categories", new { id = p.CategoryId });
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

        // Post: Removes one complete product_line with id = Product.Id from the cart
        public async Task<IActionResult> RemoveOneLine(int? id)
        {
       
            Cart c = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            var line = c.Lines.Where(c => c.Product.Id == id).FirstOrDefault();
            int nLine = line.Quantity;

            if (line != null)
            {
                c.RemoveLine(line);

                HttpContext.Session.SetJson("cart", c);

                int? n = HttpContext.Session.GetJson<int>("prodsInCart");
                if (n != null)
                {
                    n = n - nLine;
                }

                HttpContext.Session.SetJson("prodsInCart", n);


                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }


        //Help-function.After ordering, cart will be cleared
        //public void ClearCart()
        //{
        //    HttpContext.Session.SetJson("prodsInCart", 0);
        //}
    }
}
