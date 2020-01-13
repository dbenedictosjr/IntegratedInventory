using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Domain.Entities;
using System.Domain.Interfaces;
using System.Threading.Tasks;

namespace System.Domain.Repositories
{
    public class Category3Repository : Repository<Category3Entity>, ICategory3Repository
    {
        public Category3Repository(ApplicationDbContext _context)
            : base(_context)
        { }

        public override async Task<IEnumerable<Category3Entity>> GetAllAsync()
        {
            return await _context.Set<Category3Entity>()
           .Include(a => a.Category2)
           .ToListAsync();
        }

        public override async Task<Category3Entity> GetByIDAsync(Guid? id) => await _context.Set<Category3Entity>()
            .Include(a => a.Category2)
            .FirstOrDefaultAsync(a => a.Cat3ID == id);
    }
}