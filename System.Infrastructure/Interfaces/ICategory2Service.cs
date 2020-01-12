using System.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.Infrastructure.Interfaces
{
    public interface ICategory2Service
    {
        Task CreateAsync(Category2Model model);

        Task<Category2Model> GetByIDAsync(Guid? id);
        Task<IEnumerable<Category2Model>> GetAllAsync();

        Task UpdateAsync(Category2Model model);

        Task DeleteAsync(Category2Model model);

    }
}