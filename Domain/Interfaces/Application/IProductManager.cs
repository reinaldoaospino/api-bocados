using Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Interfaces.Application
{
    public interface IProductManager
    {
        Task<IEnumerable<Product>> Get();

        Task<Product> Get(string id);

        Task Create(Product product);

        Task Update(Product product);

        Task Delete(string id);
    }
}
