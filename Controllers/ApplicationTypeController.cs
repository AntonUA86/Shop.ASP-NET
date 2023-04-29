using Microsoft.AspNetCore.Mvc;
using Shop.ASP_NET.Data;
using Shop.ASP_NET.Models;

namespace Shop.ASP_NET.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationTypeController(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> applicationTypes = _dbContext.ApplicationType;
            return View(applicationTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType applicationType)
        {
            if (ModelState.IsValid)
            {
                _dbContext.ApplicationType.Add(applicationType);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationType);
        }
    }
}

