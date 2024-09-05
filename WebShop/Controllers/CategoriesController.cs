using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebShop.Data;
using WebShop.Dto;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Categories
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Categories.ToListAsync());
        //}


        // GET: Categories/ShowProduct/5
        // Shows all products with category-id=id
        [HttpGet("Categories/ShowProduct/{id}")]
        public async Task<IActionResult> ShowProduct(int? id)
        {
            if (id == null || id > 5 ||id < 1)
            {
                return NotFound();
            }

            var cat = await _context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
            var prods = await _context.Products.Where(p => p.CategoryId == id).ToListAsync(); // only products with categoryId==Id

            if (cat != null && prods != null)
            {
                List<ProductDto> prodDtos = new List<ProductDto>();
                foreach (var p in prods)
                {
                    var a = new ProductDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        CatName = cat.Name,
                        SwedishCatName = cat.SwedishName,
                        Description = p.Description,
                        Price = p.Price,
                        DiscountPrice = p.DiscountPrice,
                        IsDiscount = p.IsDiscount,
                        ImageUrl = p.ImageUrl,
                        QuantityInStore = p.QuantityInStore
                    };
                    prodDtos.Add(a);
                }
                ViewBag.Cat = cat.SwedishName;

                return View(prodDtos);
            }
            else
            {
                return RedirectToAction("Error404", "Error");
            }
            
        }

        // GET: Categories/ShowDiscountProduct
        // Shows all products with discounts
        [HttpGet("Categories/ShowDiscountProduct")]
        public async Task<IActionResult> ShowDiscountProduct()
        {
                     
            var prods = await _context.Products.Where(p => p.IsDiscount==true).ToListAsync();

            if (prods != null)
            {
                List<ProductDto> prodDtos = new List<ProductDto>();
                foreach (var p in prods)
                {
                    var cat = await _context.Categories.Where(c => c.Id == p.CategoryId).FirstOrDefaultAsync();

                    if (cat != null)
                    {
                        var a = new ProductDto
                        {
                            Id = p.Id,
                            Name = p.Name,
                            CatName = cat.Name,
                            SwedishCatName = cat.SwedishName,
                            Description = p.Description,
                            Price = p.Price,
                            DiscountPrice = p.DiscountPrice,
                            IsDiscount = p.IsDiscount,
                            ImageUrl = p.ImageUrl,
                            QuantityInStore = p.QuantityInStore
                        };
                        prodDtos.Add(a);
                    }
                }
            
                return View(prodDtos);
            }
            else
            {
                return RedirectToAction("Error404", "Error");
            }
        }


        // GET: Categories/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,SwedishName")] Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(category);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(category);
        //}

        // GET: Categories/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var category = await _context.Categories.FindAsync(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(category);
        //}

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SwedishName")] Category category)
        //{
        //    if (id != category.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(category);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CategoryExists(category.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(category);
        //}

        // GET: Categories/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var category = await _context.Categories
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(category);
        //}

        // POST: Categories/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var category = await _context.Categories.FindAsync(id);
        //    if (category != null)
        //    {
        //        _context.Categories.Remove(category);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
