using System.Collections.Generic;
using Audiences.ViewModels;


namespace Audiences.Services.Contracts
{
    public interface IContactsService
    {
        IList<ContactViewModel> getList();
        ContactViewModel findById(int id);
        void Create(ContactViewModel contactViewModel);
        void Update(ContactViewModel contactViewModel);
        void Delete(ContactViewModel contactViewModel);
    }
    
        
}
