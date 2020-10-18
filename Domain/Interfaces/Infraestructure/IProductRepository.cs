using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Infraestructure
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Get();

        Task<Product> Get(string id);

        Task Create(Product product);

        Task Update(Product product);

        Task Delete(string id);
    }
}
