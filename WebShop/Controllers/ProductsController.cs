using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
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

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products 
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        // [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
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


        public int getParamsForPagination(List<ProductDto> prodDtos,out int rest)
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
            if (ModelState.IsValid)
            {
                _context.Add(product);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,DiscountPrice,IsDiscount,QuantityInStore,ImageUrl,CategoryId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
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
