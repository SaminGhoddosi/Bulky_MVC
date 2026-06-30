using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAcess.Data;
using Bulky.Domain.Entities;
using Bulky.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyWeb.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var authors = _unitOfWork.AuthorRepository.GetAll(includeProperties: "PublishingHouse").ToList();
            return View(authors);
        }

        public IActionResult Create()
        {
            var vm = new AuthorViewModel
            {
                Author = new Author(),
                PublishingHouseList = _unitOfWork.PublishHouseRepository.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(AuthorViewModel vm)
        {
            ModelState.Remove("Author.Id");
            if (ModelState.IsValid)
            {
                _unitOfWork.AuthorRepository.Add(vm.Author);
                _unitOfWork.Save();
                TempData["success"] = "Author created successfully!";
                return RedirectToAction("Index");
            }

            vm.PublishingHouseList = _unitOfWork.PublishHouseRepository.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View(vm);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var author = _unitOfWork.AuthorRepository.Get(x => x.Id == id);
            if (author == null) return NotFound();

            var vm = new AuthorViewModel
            {
                Author = author,
                PublishingHouseList = _unitOfWork.PublishHouseRepository.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(AuthorViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AuthorRepository.Update(vm.Author);
                _unitOfWork.Save();
                TempData["success"] = "Author updated successfully!";
                return RedirectToAction("Index");
            }

            vm.PublishingHouseList = _unitOfWork.PublishHouseRepository.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View(vm);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var author = _unitOfWork.AuthorRepository.Get(x => x.Id == id, includeProperties: "PublishingHouse");
            if (author == null) return NotFound();
            return View(author);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var author = _unitOfWork.AuthorRepository.Get(x => x.Id == id);
            if (author == null) return NotFound();
            _unitOfWork.AuthorRepository.Remove(author);
            _unitOfWork.Save();
            TempData["success"] = "Author deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}