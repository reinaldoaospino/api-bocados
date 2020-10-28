using Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Interfaces.Infraestructure
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> Get();

        Task<Category> Get(string id);

        Task Create(Category category);

        Task Update(Category category);

        Task Delete(string id);
    }
}
