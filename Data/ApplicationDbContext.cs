using Audiences.Models;
using Audiences.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Audiences.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<EntityType> EntityTypes { get; set; }
        public virtual DbSet<Entity> Entities { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Audience> Audiences { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // El .Entity se refiere a entity framework, no a nuestro Entity
            builder.Entity<Audience>(entity =>
            {
                entity.ToTable("audiences");
            });
            
            builder.Entity<Contact>(entity =>
            {
                entity.ToTable("contacts");
            });
            
            builder.Entity<Entity>(entity =>
            {
                entity.ToTable("entities");
            });
            
            builder.Entity<EntityType>(entity =>
            {
                entity.ToTable("entity_types");

              /*  entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired();*/
            });
        }
        
    }
}
