using Microsoft.AspNetCore.Mvc;
using Shop.ASP_NET.Data;
using Shop.ASP_NET.Models;

namespace Shop.ASP_NET.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _dbContext.Category;
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Category.Add(category);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}

