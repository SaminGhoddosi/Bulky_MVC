using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var objCategoryList = _dbContext.Categories.ToList();
            return View(objCategoryList);
        }
        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("", "Name and Display Order cannot match!");
            }
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("index");
            }
            return View();
        }
        #endregion

        public IActionResult Edit(int? id)
        {
            if(id==null || id== 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _dbContext.Categories.FirstOrDefault(x => x.Id == id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost] 
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _dbContext.Categories.FirstOrDefault(x => x.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _dbContext.Categories.FirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _dbContext.Categories.Remove(obj);
            _dbContext.SaveChanges();
            TempData["success"] = "Category updated successfully!";
            return RedirectToAction("Index");
        }
    } 
}