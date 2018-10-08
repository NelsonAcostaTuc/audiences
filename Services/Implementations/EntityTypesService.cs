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
                    Id = entityType.Id,
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
        public void Delete(EntityTypeViewModel entityTypeViewModel)
        {
             EntityType entityType = _context.EntityTypes.Find(entityTypeViewModel.Id);
             _context.EntityTypes.Remove(entityType);
             _context.SaveChanges();
        }
        public EntityTypeViewModel findById(int id)
        {
            EntityType entityType = _context.EntityTypes.Find(id);

            EntityTypeViewModel entityTypeViewModel = new EntityTypeViewModel()
            {
                Id = entityType.Id,
                Name = entityType.Name
                
            };
            return entityTypeViewModel;
        }    
    }
 }