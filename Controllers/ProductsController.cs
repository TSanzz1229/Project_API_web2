using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneShopASPnet.Data;
using PhoneShopASPnet.Models;

namespace PhoneShopASPnet.Controllers
{
    public class ProductsController : Controller
    {
        private readonly PhoneShopASPnetContext _context;

        public ProductsController(PhoneShopASPnetContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var phoneShopASPnetContext = _context.Product.Include(p => p.Brand).Include(p => p.Category);
            return View(await phoneShopASPnetContext.ToListAsync());
        }
		public async Task<IActionResult> ProductByCategory(int cateID)
		{
			var phoneShopASPnetContext = _context.Product.Include(p => p.Brand).Include(p => p.Category).Where(p=>p.CategoryID == cateID);
			return View(await phoneShopASPnetContext.ToListAsync());
		}

        [HttpPost]
        public async Task<IActionResult> ProductSearch (string searchString,int catID)
        {
            if (_context.Product == null)
            {
                return Problem("Product s 'PhoneShopASPnet.Product' is null. ");
            }
            var product = from p in _context.Product
                          select p;
            if(!String.IsNullOrEmpty(searchString))
            {
                product = _context.Product.Include(p=>p.Category).Where(p => p.ProductName.Contains(searchString));
            }
            return View(await product.ToListAsync());
        }

		public async Task<IActionResult> ProductDetails(int? id)
		{
			if (id == null || _context.Product == null)
			{
				return NotFound();
			}

			var product = await _context.Product
				.Include(p => p.Brand)
				.Include(p => p.Category)
				.FirstOrDefaultAsync(m => m.ProductID == id);
			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		// GET: Products/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["BrandID"] = new SelectList(_context.Brand, "BrandID", "BrandName");
            ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,ProductPrice,Description,ProductQuantity,ProductImage,CategoryID,BrandID")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandID"] = new SelectList(_context.Brand, "BrandID", "BrandName", product.BrandID);
            ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandID"] = new SelectList(_context.Brand, "BrandID", "BrandName", product.BrandID);
            ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,ProductPrice,Description,ProductQuantity,ProductImage,CategoryID,BrandID")] Product product)
        {
            if (id != product.ProductID)
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
                    if (!ProductExists(product.ProductID))
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
            ViewData["BrandID"] = new SelectList(_context.Brand, "BrandID", "BrandName", product.BrandID);
            ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);
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
            if (_context.Product == null)
            {
                return Problem("Entity set 'PhoneShopASPnetContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Product?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }
    }
}
