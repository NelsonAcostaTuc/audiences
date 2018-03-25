using System.Collections.Generic;
using Audiences.ViewModels;

namespace Audiences.Services.Contracts
{
    public interface IEntityTypesService
    {
        IList<EntityTypeViewModel> getList();
        void Create(EntityTypeViewModel entityTypeViewModel);
    }
}