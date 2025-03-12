using CRUD_Operations.Models;
using CRUD_Operations.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Operations.Controllers
{
    /*
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
    */
    public class ProductsController : Controller
    {
        private readonly IRepository<Product> _productRepository;

        public ProductsController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            return View(products);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            await _productRepository.AddAsync(product);
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest("Product ID mismatch");

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            await _productRepository.UpdateAsync(product);
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            await _productRepository.DeleteAsync(product);
            return RedirectToAction(nameof(Index));
        }

    }

}
