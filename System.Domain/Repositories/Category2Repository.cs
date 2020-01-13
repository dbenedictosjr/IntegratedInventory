using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Domain.Entities;
using System.Domain.Interfaces;
using System.Threading.Tasks;

namespace System.Domain.Repositories
{
    public class Category2Repository : Repository<Category2Entity>, ICategory2Repository
    {
        public Category2Repository(ApplicationDbContext _context)
            : base(_context)
        { }

        public override async Task<IEnumerable<Category2Entity>> GetAllAsync()
        {
            return await _context.Set<Category2Entity>()
           .Include(a => a.Category1)
           .ToListAsync();
        }

        public override async Task<Category2Entity> GetByIDAsync(Guid? id) => await _context.Set<Category2Entity>()
            .Include(a => a.Category1)
            .FirstOrDefaultAsync(a => a.Cat2ID == id);
    }
}