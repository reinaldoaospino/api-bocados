using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Infraestructure
{
    public interface IUserRepository
    {
        Task<User> Get(string id);

        Task Create(User user);        
    }
}
