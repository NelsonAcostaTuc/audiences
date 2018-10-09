using System.Collections.Generic;
using Audiences.Services.Contracts;
using Audiences.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Audiences.Controllers
{
    public class EntityTypesController : Controller
    {
        private readonly IEntityTypesService _entityTypesService;

        public EntityTypesController(IEntityTypesService entityTypesService)
        {
            _entityTypesService = entityTypesService;
        }
        
        // GET
        public IActionResult Index()
        {
            IList<EntityTypeViewModel> entityTypeViewModels = _entityTypesService.getList();
            
            return View(entityTypeViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EntityTypeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            
            _entityTypesService.Create(viewModel);

            return Redirect("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            EntityTypeViewModel entityTypeViewModel = _entityTypesService.findById(id);

            return View(entityTypeViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EntityTypeViewModel entityTypeViewModel)
        {
            _entityTypesService.Update(entityTypeViewModel);

            return RedirectToAction("Index");
        }
    
        [HttpGet]
        public IActionResult Delete(int id)
        {
            EntityTypeViewModel entityTypeViewModels = _entityTypesService.findById(id);

            return View(entityTypeViewModels);
        }
        [HttpPost]
        public IActionResult Delete(EntityTypeViewModel entityTypeViewModel)
        {
            _entityTypesService.Delete(entityTypeViewModel);

            return RedirectToAction("Index");
        }
    }

}