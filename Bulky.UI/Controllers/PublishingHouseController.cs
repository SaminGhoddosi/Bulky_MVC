using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAcess.Data;
using Bulky.Domain.Entities;
using Bulky.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyWeb.Controllers
{
    public class PublishingHouseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PublishingHouseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var list = _unitOfWork.PublishHouseRepository.GetAll().ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View(new PublishingHouse());
        }

        [HttpPost]
        public IActionResult Create(PublishingHouse publishingHouse)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                _unitOfWork.PublishHouseRepository.Add(publishingHouse);
                _unitOfWork.Save();
                TempData["success"] = "Publishing House created successfully!";
                return RedirectToAction("Index");
            }
            return View(publishingHouse);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var ph = _unitOfWork.PublishHouseRepository.Get(x => x.Id == id);
            if (ph == null) return NotFound();
            return View(ph);
        }

        [HttpPost]
        public IActionResult Edit(PublishingHouse publishingHouse)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PublishHouseRepository.Update(publishingHouse);
                _unitOfWork.Save();
                TempData["success"] = "Publishing House updated successfully!";
                return RedirectToAction("Index");
            }
            return View(publishingHouse);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var ph = _unitOfWork.PublishHouseRepository.Get(x => x.Id == id);
            if (ph == null) return NotFound();
            return View(ph);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var ph = _unitOfWork.PublishHouseRepository.Get(x => x.Id == id);
            if (ph == null) return NotFound();
            _unitOfWork.PublishHouseRepository.Remove(ph);
            _unitOfWork.Save();
            TempData["success"] = "Publishing House deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}