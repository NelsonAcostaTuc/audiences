using System.Collections.Generic;
using System.Linq;
using Audiences.Data;
using Audiences.Models;
using Audiences.Services.Contracts;
using Audiences.ViewModels;

namespace Audiences.Services.Implementations
{
    public class EntityTypesService : IEntityTypesService
    {
        private readonly ApplicationDbContext _context;

        public EntityTypesService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IList<EntityTypeViewModel> getList()
        {
            IList<EntityType> entityTypes = _context.EntityTypes.ToList();
            IList<EntityTypeViewModel> entityTypeViewModels = new List<EntityTypeViewModel>();

            foreach (EntityType entityType in entityTypes)
            {
                entityTypeViewModels.Add(new EntityTypeViewModel()
                {
                    Name = entityType.Name
                });
            }

            return entityTypeViewModels;
        }

        public void Create(EntityTypeViewModel entityTypeViewModel)
        {
            _context.EntityTypes.Add(new EntityType()
            {
                Name = entityTypeViewModel.Name
            });

            _context.SaveChanges();
        }
    }
}