using Domain.Entities;
using System.Threading.Tasks;
using Domain.Interfaces.Application;
using Domain.Interfaces.Infraestructure;
using System.Linq;

namespace Application.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _repository;
        private readonly IGeneratorIdService _generatorId;

        public UserManager(IUserRepository repository, IGeneratorIdService generatorId)
        {
            _repository = repository;
            _generatorId = generatorId;
        }

        public async Task<UserResponse> Authenticate(User user)
        {
            var users = await _repository.GetUsers();

            var exist = users.ToList().Find(u => u.UserName == user.UserName && u.Password == user.Password);

            var isCorrect = exist != null;

            return new UserResponse
            {
                IsCorrect = isCorrect
            };
        }

        public Task<User> Get(string id)
        {
            return _repository.Get(id);
        }

        public Task Create(User user)
        {
            user.Id = _generatorId.GenerateId();

            return _repository.Create(user);
        }


    }
}