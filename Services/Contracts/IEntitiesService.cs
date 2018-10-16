using System.Collections.Generic;
using Audiences.ViewModels;


namespace Audiences.Services.Contracts
{
    public interface IEntitiesService
    {
        IList<EntityViewModel> getList();
        EntityViewModel findById(int id);
        void Create(EntityViewModel entityViewModel);
        void Update(EntityViewModel entityViewModel);
        void Delete(EntityViewModel entityViewModel);
    }
    
        
}
