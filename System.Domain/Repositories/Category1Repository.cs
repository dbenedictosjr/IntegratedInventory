using System.Domain.Entities;
using System.Domain.Interfaces;

namespace System.Domain.Repositories
{
    public class Category1Repository : Repository<Category1Entity>, ICategory1Repository
    {
        public Category1Repository(ApplicationDbContext _context)
            : base(_context)
        {

        }
    }
}
