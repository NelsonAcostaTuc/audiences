using System.Collections.Generic;
using System.Linq;
using Audiences.Services.Contracts;
using Audiences.ViewModels;
using Audiences.Data;
using Audiences.Models;

namespace audiences.Services.Implementations
{
    public class ContactsService : IContactsService
    {
        
        private readonly ApplicationDbContext _context;

        public ContactsService(ApplicationDbContext context) 
        {
             _context = context;           
        }
       
        public IList<ContactViewModel> getList()
        {
            
            IList<Contact> contacts = _context.Contacts.ToList();
            IList<ContactViewModel> contactViewModels = new List<ContactViewModel>();

            foreach (Contact contact in contacts)
            {
                contactViewModels.Add(new ContactViewModel()
                {
                    FirstName = contact.FirstName,
                    LastName = contact.LastName
                });
            }
            return contactViewModels;

        }

        public void Create(ContactViewModel contactViewModel)
        {
          _context.Contacts.Add(new Contact()
            {
                FirstName = contactViewModel.FirstName,
                LastName = contactViewModel.LastName
            });

            _context.SaveChanges();
        }

    }
}