using AutoMapper;
using Domain.Entities;
using System.Threading.Tasks;
using Infraestructure.Entities;
using Infraestructure.Interfaces;
using System.Collections.Generic;
using Domain.Interfaces.Infraestructure;
using Microsoft.Extensions.Configuration;

namespace Infraestructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoService _mongoService;
        private readonly IMapper _mapper;

        private readonly string _collectionName;

        public CategoryRepository(IMongoService mongoService,
            IConfiguration configuration, IMapper mapper)
        {
            _mongoService = mongoService;
            _mapper = mapper;
            _collectionName = configuration["AppSettings:categoryCollection"];
        }

        public async Task<IEnumerable<Category>> Get()
        {
            var categoryEntity = await _mongoService.Get<CategoryEntity>(_collectionName);

            var category = _mapper.Map<IEnumerable<Category>>(categoryEntity);

            return category;
        }

        public async Task<Category> Get(string id)
        {
            var categoryEntity = await _mongoService.Get<CategoryEntity>(_collectionName, id);

            var category = _mapper.Map<Category>(categoryEntity);

            return category;
        }

        public Task Create(Category category)
        {
            var categoryEntity = _mapper.Map<CategoryEntity>(category);

            return _mongoService.Create(_collectionName, categoryEntity);
        }

        public Task Update(Category category)
        {
            var categoryEntity = _mapper.Map<CategoryEntity>(category);

            return _mongoService.Update(_collectionName, categoryEntity.Id, categoryEntity);
        }

        public Task Delete(string id)
        {
            return _mongoService.Delete<CategoryEntity>(_collectionName, id);
        }
    }
}
