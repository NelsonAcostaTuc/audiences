using System.Collections.Generic;
using System.Linq;
using Audiences.Services.Contracts;
using Audiences.ViewModels;
using Audiences.Data;
using Audiences.Models;

namespace audiences.Services.Implementations
{
    public class EntitiesService : IEntitiesService
    {
        
        private readonly ApplicationDbContext _context;

        public EntitiesService(ApplicationDbContext context) 
        {
             _context = context;           
        }
       
        public IList<EntityViewModel> getList()
        {
            
            IList<Entity> entities = _context.Entities.ToList();
            IList<EntityViewModel> entityViewModels = new List<EntityViewModel>();

            foreach (Entity entity in entities)
            {
                entityViewModels.Add(new EntityViewModel()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                   
                    Address = entity.Address,
                    PhoneNumber = entity.PhoneNumber,
                    Description = entity.Description
                });
            }
            return entityViewModels;

        }

        public void Create(EntityViewModel entityViewModel)
        {
          _context.Entities.Add(new Entity()
            {
                Name = entityViewModel.Name,
               
                Address = entityViewModel.Address,
                PhoneNumber = entityViewModel.PhoneNumber,
                Description = entityViewModel.Description
            });

            _context.SaveChanges();
        }

        public void Update(EntityViewModel entityViewModel)
        {
            Entity entity = _context.Entities.Find(entityViewModel.Id);
            
            entity.Name = entityViewModel.Name;
            
            entity.Address = entityViewModel.Address;
            entity.PhoneNumber = entityViewModel.PhoneNumber;
            entity.Description = entityViewModel.Description;

            _context.Entities.Update(entity);

            _context.SaveChanges();
        }
        public void Delete(EntityViewModel entityViewModel)
        {
             Entity entity = _context.Entities.Find(entityViewModel.Id);
             _context.Entities.Remove(entity);
             _context.SaveChanges();
        }
        public EntityViewModel findById(int id)
        {
            Entity entity = _context.Entities.Find(id);

            EntityViewModel entityViewModel = new EntityViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                
                Address = entity.Address,
                PhoneNumber = entity.PhoneNumber,
                Description = entity.Description
            };

            return entityViewModel;
        }
    }
}