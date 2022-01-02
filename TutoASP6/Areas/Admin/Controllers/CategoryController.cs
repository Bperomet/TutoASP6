using Microsoft.AspNetCore.Mvc;
using TutoASP6.DataAccess.Data;
using TutoASP6.DataAccess.Repository.IRepository;
using TutoASP6.Models;

namespace TutoASP6.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly ICategoryRepository _db;
        //private readonly AppDBContext _db;

        public CategoryController(IUnitOfWork unitOfWork)/*(ICategoryRepository db)*/
        {
            //_db = db;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            //IEnumerable<Category> categoriesList = _db.categories.ToList();
            //IEnumerable<Category> categoriesList = _db.GetAll();
            IEnumerable<Category> categoriesList = _unitOfWork.Category.GetAll();
            return View(categoriesList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display Order cannot exactly match the name.");
            }
            if (ModelState.IsValid)
            {
                //_db.categories.Add(obj);
                _unitOfWork.Category.Add(obj);
                //_db.SaveChanges();
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int ? id)
        {
            if(id == null|| id == 0)
            {
                return NotFound();
            }
            //var category = _db.categories.Find(id);
            //var category = _db.categories.FirstOrDefault(u=>u.name=="id");
            var category = _unitOfWork.Category.GetFirstOrDefault(u=>u.Id==id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display Order cannot exactly match the name.");
            }
            if (ModelState.IsValid)
            {
                //_db.categories.Update(obj);
                _unitOfWork.Category.Update(obj);
                //_db.SaveChanges();
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var category = _db.categories.Find(id);
            var category = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var category = _db.categories.Find(id);
            var category = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if(category == null)
            {
                return NotFound();
            }
            //_db.categories.Remove(category);
            _unitOfWork.Category.Remove(category);
            //_db.SaveChanges();
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
            
        }
    }
}
