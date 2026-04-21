using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAcess.Data;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;

namespace BulkyWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var objectList = _unitOfWork.ProductRepository.GetAll().ToList();
            return View(objectList);
        }

        public IActionResult Create()
        {
            ProductViewModel productVM = new()
            {
                CategoryList = _unitOfWork.CategoryRepository
                .GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
                Product = new Product()

            };
            return View(productVM);
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel productVM)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductRepository.Add(productVM.Product);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _unitOfWork.ProductRepository.Get(x => x.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductRepository.Update(product);
                _unitOfWork.Save();
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
            Product? categoryFromDb = _unitOfWork.ProductRepository.Get(x => x.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _unitOfWork.ProductRepository.Get(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.ProductRepository.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
