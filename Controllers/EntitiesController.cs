using System.Collections.Generic;
using Audiences.Services.Contracts;
using Audiences.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Audiences.Controllers
{
    public class EntitiesController : Controller
    {
        private readonly IEntitiesService _entitiesService;

        public EntitiesController(IEntitiesService entitiesService)
        {
            _entitiesService = entitiesService;
        }
        
        // GET
        public IActionResult Index()
        {
            IList<EntityViewModel> entityViewModels = _entitiesService.getList();
            
            return View(entityViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EntityViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            
            _entitiesService.Create(viewModel);

            return Redirect("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            EntityViewModel entityViewModel = _entitiesService.findById(id);

            return View(entityViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EntityViewModel entityViewModel)
        {
            _entitiesService.Update(entityViewModel);

            return RedirectToAction("Index");
        }
    
        [HttpGet]
        public IActionResult Delete(int id)
        {
            EntityViewModel entityViewModels = _entitiesService.findById(id);

            return View(entityViewModels);
        }
        [HttpPost]
        public IActionResult Delete(EntityViewModel entityViewModel)
        {
            _entitiesService.Delete(entityViewModel);

            return RedirectToAction("Index");
        }
    }

}