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

        //GET - EDIT
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var currentApplicationType = _dbContext.ApplicationType.Find(id);

            if (currentApplicationType == null)
            {
                return NotFound();
            }

            return View(currentApplicationType);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType applicationType)
        {
            if (ModelState.IsValid)
            {
                _dbContext.ApplicationType.Update(applicationType);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationType);
        }


        //GET - DELETE
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var currentApplicationType = _dbContext.ApplicationType.Find(id);

            if (currentApplicationType == null)
            {
                return NotFound();
            }

            return View(currentApplicationType);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostDelete(int? id)
        {
            var currentApplicationType = _dbContext.ApplicationType.Find(id);

            if (currentApplicationType == null)
            {
                return NotFound();
            }

            _dbContext.ApplicationType.Remove(currentApplicationType);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}

