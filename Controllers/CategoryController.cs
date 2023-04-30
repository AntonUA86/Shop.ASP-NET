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

        //GET - EDIT
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var currentCategory = _dbContext.Category.Find(id);

            if(currentCategory == null)
            {
                return NotFound();
            }

            return View(currentCategory);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Category.Update(category);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }


        //GET - DELETE
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var currentCategory = _dbContext.Category.Find(id);

            if (currentCategory == null)
            {
                return NotFound();
            }

            return View(currentCategory);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostDelete(int? id)
        {
            var currentCategory = _dbContext.Category.Find(id);

            if (currentCategory == null)
            {
                return NotFound();
            }

            _dbContext.Category.Remove(currentCategory);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

