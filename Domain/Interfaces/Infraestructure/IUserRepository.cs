using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Infraestructure
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> Get(string id);

        Task Create(User user);        
    }
}
