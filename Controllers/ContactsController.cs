using System.Collections.Generic;
using Audiences.Services.Contracts;
using Audiences.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace audiences.Controllers
{
    public class ContactsController : Controller
    {

        private readonly IContactsService _contactsService;

        public ContactsController(IContactsService contactsService)
        {

            _contactsService = contactsService;
        }

        //GET
        public IActionResult Index()
        {

            IList<ContactViewModel> contactViewModels = _contactsService.getList();

            return View(contactViewModels);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
           _contactsService.Create(viewModel);

           return Redirect("Index"); 

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ContactViewModel contactViewModel = _contactsService.findById(id);

            return View(contactViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ContactViewModel contactViewModel)
        {
            _contactsService.Update(contactViewModel);

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ContactViewModel contactViewModel = _contactsService.findById(id);

            return View(contactViewModel);
        }

        [HttpPost]
        public IActionResult Delete(ContactViewModel contactViewModel)
        {
            _contactsService.Delete(contactViewModel);

            return RedirectToAction("Index");
        }
        
    }
}