using Microsoft.AspNetCore.Mvc;
using MyAppWeb.Data;
using MyAppWeb.Models;

namespace MyAppWeb.Controllers
{
    public class CategoryController : Controller
    {
        private AplicationDBContext _context;

        public CategoryController(AplicationDBContext context)
        {
            _context = context;
        }

        // for show all value in table 
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _context.Categories;
            return View(categories);
        }



        //for add new value 

        [HttpGet]
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


                _context.Categories.Add(category);
                _context.SaveChanges();
                TempData["success"] = "category created done";
            return RedirectToAction("Index");
            }
            return View(category);
        }
        // for edit value code
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id== null || id == 0)
            {
                return NotFound();
            }
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)

        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                TempData["success"] = "category update done";
                return RedirectToAction("Index");
            }
           return View(category);
        }

        //for delete value
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost , ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)

        {
            var category = _context.Categories.Find(id);
                if(category == null)
            {
                return NotFound();
            }
                _context.Categories.Remove(category);
            _context.SaveChanges();
            TempData["success"] = "category Deleted done";
            return RedirectToAction("index");
        }
    }
}
