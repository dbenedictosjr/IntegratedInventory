using System.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace System.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public Guid CurrentUserId { get; set; }

        public DbSet<Category1Entity> Category1s { get; set; }
        public DbSet<Category2Entity> Category2s { get; set; }
        public DbSet<Category3Entity> Category3s { get; set; }
        public DbSet<ProductEntity> Products { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }
        public async Task<int> SaveChangesAsync()
        {
            UpdateAuditEntities();
            return await base.SaveChangesAsync();
        }

        private void UpdateAuditEntities()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = (IAuditableRepository)entry.Entity;
                DateTime now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = now;
                    entity.CreatedBy = CurrentUserId;
                }
                else
                {
                    base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                    base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                }

                entity.UpdatedDate = now;
                entity.UpdatedBy = CurrentUserId;
            }
        }
    }
}
