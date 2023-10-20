using BulkyBook.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly BulkyBookContext _db;

        public CategoryController(BulkyBookContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryLis = _db.category;
            return View(objCategoryLis);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var SelecetedCategory = _db.category.SingleOrDefault(x => x.Id == id);

            if (SelecetedCategory == null)
            {
                return NotFound();
            }
            return View(SelecetedCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomWError", "The display order can't match the name.");
            }
            if (ModelState.IsValid)
            {
                _db.category.Add(obj);
                _db.SaveChanges();
                TempData["Seccuss"] = "Category has been created seccessfully.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomWError", "The display order can't match the name.");
            }
            if (ModelState.IsValid)
            {
                _db.category.Update(obj);
                _db.SaveChanges();
                TempData["Seccuss"] = "Category has been edited.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int id)
        {
            var category = _db.category.SingleOrDefault(c => c.Id == id);
            if (category != null)
            {
                _db.category.Remove(category);
                _db.SaveChanges();
                TempData["Seccuss"] = "Category has been deleted.";
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
