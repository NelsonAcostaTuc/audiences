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
                    Id = contact.Id,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Address = contact.Address,
                    PhoneNumber = contact.PhoneNumber
                });
            }
            return contactViewModels;

        }

        public void Create(ContactViewModel contactViewModel)
        {
          _context.Contacts.Add(new Contact()
            {
                FirstName = contactViewModel.FirstName,
                LastName = contactViewModel.LastName,
                Address = contactViewModel.Address,
                PhoneNumber = contactViewModel.PhoneNumber
            });

            _context.SaveChanges();
        }

        public void Update(ContactViewModel contactViewModel)
        {
            Contact contact = _context.Contacts.Find(contactViewModel.Id);

            contact.LastName = contactViewModel.LastName;
            contact.FirstName = contactViewModel.FirstName;
            contact.Address = contactViewModel.Address;
            contact.PhoneNumber = contactViewModel.PhoneNumber;

            _context.Contacts.Update(contact);

            _context.SaveChanges();
        }
        public void Delete(ContactViewModel contactViewModel)
        {
             Contact contact = _context.Contacts.Find(contactViewModel.Id);
             _context.Contacts.Remove(contact);
             _context.SaveChanges();
        }
        public ContactViewModel findById(int id)
        {
            Contact contact = _context.Contacts.Find(id);

            ContactViewModel contactViewModel = new ContactViewModel()
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Address = contact.Address,
                PhoneNumber = contact.PhoneNumber
            };

            return contactViewModel;
        }
    }
}