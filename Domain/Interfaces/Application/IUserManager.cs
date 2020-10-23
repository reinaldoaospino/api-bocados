using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Application
{
    public interface IUserManager
    {
        Task<User> Get(string id);

        Task Create(User user);
    }
}
