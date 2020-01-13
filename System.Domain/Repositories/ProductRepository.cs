using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Domain.Entities;
using System.Domain.Interfaces;
using System.Threading.Tasks;

namespace System.Domain.Repositories
{
    public class ProductRepository : Repository<ProductEntity>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext _context)
            : base(_context)
        { }

        public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            return await _context.Set<ProductEntity>()
           .Include(a => a.Category3)
           .ToListAsync();
        }

        public override async Task<ProductEntity> GetByIDAsync(Guid? id) => await _context.Set<ProductEntity>()
            .Include(a => a.Category3)
            .FirstOrDefaultAsync(a => a.ProdID == id);
    }
}
