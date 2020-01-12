using System.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.Infrastructure.Interfaces
{
    public interface ICategory1Service
    {
        Task CreateAsync(Category1Model model);

        Task<Category1Model> GetByIDAsync(Guid? id);
        Task<IEnumerable<Category1Model>> GetAllAsync();

        Task UpdateAsync(Category1Model model);

        Task DeleteAsync(Category1Model model);

    }
}