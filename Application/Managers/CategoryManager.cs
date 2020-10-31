using System;
using Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Interfaces.Application;
using Domain.Interfaces.Infraestructure;
using System.Linq;
using Domain.Exceptions;

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

        public async Task Create(Category category)
        {
            category.CategoryName = category.CategoryName.ToLower();

            var categories = await _repository.Get();

            var existName = categories.ToList().Find(c => c.CategoryName == category.CategoryName);

            if (existName != null)
                throw new ExistingCategoryException();

            category.Id = _generatorId.GenerateId();

            await _repository.Create(category);
        }

        public async Task Update(Category category)
        {
            var existingCategory = await _repository.Get(category.Id);

            var notExist = existingCategory == null;

            if (notExist)
                throw new Exception();

            existingCategory.Update(category);

            await _repository.Update(existingCategory);
        }

        public Task Delete(string id)
        {
            return _repository.Delete(id);
        }
    }
}
