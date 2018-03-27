using System.Collections.Generic;
using Audiences.ViewModels;


namespace audiences.Services.Contracts
{
    public interface IContactsService
    {
        IList<ContactViewModel> getList();
        void Create(ContactViewModel contactViewModel);
    }
    
        
}
