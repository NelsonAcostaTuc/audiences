using System.Collections.Generic;
using audiences.Services.Contracts;
using Audiences.ViewModels;
using Audiences.Services.Contracts;
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
        
    }
}