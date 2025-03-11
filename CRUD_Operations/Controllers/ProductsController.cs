using CRUD_Operations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Operations.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.ProductStorage.ToListAsync(); // Fetch all products
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _context.ProductStorage.AddAsync(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.ProductStorage.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound(id);
            }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            
            _context.Update(product);
            if (ModelState.IsValid)
            {
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var emplotee = await _context.ProductStorage.FirstOrDefaultAsync(x => x.Id == id);

            if (emplotee == null)
            {
                return NotFound(id);
            }

            _context.ProductStorage.Remove(emplotee);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
