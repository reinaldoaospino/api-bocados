using AutoMapper;
using Domain.Entities;
using System.Threading.Tasks;
using Infraestructure.Entities;
using Infraestructure.Interfaces;
using Domain.Interfaces.Infraestructure;
using Microsoft.Extensions.Configuration;

namespace Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoService _mongoService;
        private readonly IMapper _mapper;

        private readonly string _collectionName;

        public UserRepository(IMongoService mongoService,
            IConfiguration configuration, IMapper mapper)
        {
            _mongoService = mongoService;
            _mapper = mapper;
            _collectionName = configuration["AppSettings:userCollection"];
        }

        public async Task<User> Get(string id)
        {
            var userEntity = await _mongoService.Get<UserEntity>(_collectionName,id);

            var user = _mapper.Map<User>(userEntity);

            return user;     
        }

        public Task Create(User user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);

           return _mongoService.Create(_collectionName, userEntity);
        }
    }
}
