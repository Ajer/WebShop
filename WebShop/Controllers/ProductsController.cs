using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebShop.Data;
using WebShop.Dto;
using WebShop.Infrastructure;
using WebShop.Models;

namespace WebShop.Controllers
{
    
    
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ProductsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Products 
        public async Task<IActionResult> Index()
        {


            var applicationDbContext = _context.Products.Include(p => p.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        //private async Task AddUserToAdmin()
        //{
        //    var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

        //    if (userId == "1f6d25fc-c568-41ac-93ef-564779fa8b7b")   // admin@example.com
        //    {
        //        if (!User.IsInRole("Admin"))   
        //        {
        //            var user = await  _userManager.FindByIdAsync(userId);
        //            var role = new IdentityRole("Admin");
        //            await _roleManager.CreateAsync(role);

        //            //add the role to userAdmin
        //            await _userManager.AddToRoleAsync(user, "Admin");
        //        }
        //    }
        //}




        // GET: Products/Details/5
        //[AllowAnonymous]
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var p = await _context.Products
        //        .Include(p => p.Category)
        //        .FirstOrDefaultAsync(m => m.Id == id);

        //    if (p == null)
        //    {
        //        return NotFound();
        //    }

        //    var cat = await _context.Categories.Where(c => c.Id == p.CategoryId).FirstOrDefaultAsync();

        //    if (cat != null)
        //    {
        //        var a = new ProductDto
        //        {
        //            Id = p.Id,
        //            Name = p.Name,
        //            CatName = cat.Name,
        //            SwedishCatName = cat.SwedishName,
        //            Description = p.Description,
        //            Price = p.Price,
        //            DiscountPrice = p.DiscountPrice,
        //            IsDiscount = p.IsDiscount,
        //            ImageUrl = p.ImageUrl,
        //            QuantityInStore = p.QuantityInStore
        //        };

        //        return View(a);
        //    }
        //    return RedirectToAction("ShowProduct", "Categories", new { id = cat.Id });
        //}


        //Get: Returns a searchresult from search-form in web-shop
        [AllowAnonymous]
        public IActionResult Search(string? srch,int showPage=0)
        {

             SearchDto searchDto = new SearchDto();

            if (srch!=null)
            {

                if (srch.IsValid())   // isValid from UtilitiesExtensions
                {
                    var cat_res = _context.Categories.Where(c => c.Name.Contains(srch) || c.SwedishName.Contains(srch)).ToList();
                    var prod_res = _context.Products.Where(p => p.Name.Contains(srch)).ToList();

                    // Assign SrchDto-object : List<ProdDto> ,List<Category>, searchstring 

                    if (cat_res!=null)
                    {
                        searchDto.Categories = cat_res;
                    }
                    if (prod_res!=null)
                    {
                        List<ProductDto> productDtos = new List<ProductDto>(); 

                        foreach(var p in prod_res)  // transform products to productDtos
                        {
                            var cat =  _context.Categories.Where(c => c.Id == p.CategoryId).FirstOrDefault();

                            var pDto = new ProductDto
                            {
                                Id = p.Id,
                                Name = p.Name,
                                CatName = cat.Name,
                                SwedishCatName = cat.SwedishName,
                                ImageUrl = p.ImageUrl,
                                Description = p.Description,
                                DiscountPrice = p.DiscountPrice,
                                Price = p.Price,
                                IsDiscount = p.IsDiscount,
                                QuantityInStore = p.QuantityInStore,                                
                            };
                            productDtos.Add(pDto);
                        }
                        searchDto.ProdDtos = productDtos;

                        if (productDtos.Count>8)    // => paginering
                        {
                            int rest = 0;
                            searchDto.MaxPageIndex = getParamsForPagination(productDtos, out rest);
                            searchDto.Rest = rest;
                        }
                        else  // 0..8
                        {
                            searchDto.MaxPageIndex = 0;
                            searchDto.Rest = productDtos.Count;
                        }
                    }
                
                    searchDto.SearchString = srch;
                    searchDto.ShowPage = showPage;  
                }
            }
            return View(searchDto);   // Empty searchDto if non-valid
        }


        private int getParamsForPagination(List<ProductDto> prodDtos,out int rest)
        {
       
            int nbrTot = prodDtos.Count;

            int maxIndex = 0;      // 16
            int j = maxIndex * 8;

            while (j<nbrTot)
            {
                maxIndex++;
                j = maxIndex * 8;             
            }
            maxIndex = maxIndex - 1;

            rest = nbrTot - maxIndex * 8;

            return maxIndex;
        }


        [AllowAnonymous]
        public IActionResult ChangeSearchPaginationPage(SearchDto theObj)
        {

            return RedirectToAction("Search", new { srch = theObj.SearchString, showPage = theObj.ShowPage });
        }



        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,DiscountPrice,IsDiscount,QuantityInStore,ImageUrl,CategoryId")] Product product)
        {
            if (product!=null)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind("Id,Name,Description,Price,DiscountPrice,IsDiscount,QuantityInStore,ImageUrl,CategoryId")] Product product)  /*[Bind("Id,Name,Description,Price,DiscountPrice,IsDiscount,QuantityInStore,ImageUrl,CategoryId")]*/
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            // AsNoTracking is needed below because you cant track 2 different products at the same time
            // in _context.Products. The param 'product' is already being tracked. Otherwise Exception
            // is thrown in _context.Products.Update(product);

            var p = _context.Products.AsNoTracking().Where(p => p.Id == product.Id).FirstOrDefault();
           
            if (p!=null)
            {
                try
                {                 
                    _context.Products.Update(product);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", product.CategoryId);
            return View(product);
        }



        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
