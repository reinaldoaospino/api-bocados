using System;
using Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Interfaces.Application;
using Domain.Interfaces.Infraestructure;

namespace Application.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository _repository;
        private readonly IGeneratorIdService _generatorId;

        public CategoryManager(ICategoryRepository repository, IGeneratorIdService generatorId)
        {
            _repository = repository;
            _generatorId = generatorId;
        }

        public Task<IEnumerable<Category>> Get()
        {
            return _repository.Get();
        }

        public Task<Category> Get(string id)
        {
            return _repository.Get(id);
        }

        public Task Create(Category category)
        {
            category.Id = _generatorId.GenerateId();

            return _repository.Create(category);
        }

        public async Task Update(Category category)
        {
            var existingCategory = await _repository.Get(category.Id);

            var notExist = existingCategory == null;

            if (notExist)
                throw new Exception();

            // existingProduct.Update(category); //Todo crear el update

            await _repository.Update(existingCategory);
        }

        public Task Delete(string id)
        {
            return _repository.Delete(id);
        }
    }
}
