using Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Interfaces.Application
{
    public interface ICategoryManager
    {
        Task<IEnumerable<Category>> Get();

        Task<Category> Get(string id);

        Task Create(Category product);

        Task Update(Category product);

        Task Delete(string id);
    }
}
