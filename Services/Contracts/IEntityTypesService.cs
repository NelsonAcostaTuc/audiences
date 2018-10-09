using System.Collections.Generic;
using Audiences.ViewModels;

namespace Audiences.Services.Contracts
{
    public interface IEntityTypesService
    {
        IList<EntityTypeViewModel> getList();
        EntityTypeViewModel findById(int id); 
        void Create(EntityTypeViewModel entityTypeViewModel);
        void Update(EntityTypeViewModel entityTypeViewModel);
        void Delete(EntityTypeViewModel entityTypeViewModel);
    }
}