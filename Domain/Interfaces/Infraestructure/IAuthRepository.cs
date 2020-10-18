using Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Interfaces.Infraestructure
{
   public interface IAuthRepository
    {
        Task<IEnumerable<AuthUser>> GetAuthUser();
        Task Create(AuthUser authUser);
    }
}
