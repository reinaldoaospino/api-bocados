using System;
using Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Interfaces.Application;
using Domain.Interfaces.Infraestructure;

namespace Application.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _repository;

        public ProductManager(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Product>> Get()
        {
            return _repository.Get();
        }

        public Task<Product> Get(string id)
        {
            return _repository.Get(id);
        }

        public Task Create(Product product)
        {
            product.Id = product.GenerateGuid();

           return _repository.Create(product);
        }

        public async Task Update(Product product)
        {
            var existingProduct = await _repository.Get(product.Id);

            var notExist = existingProduct == null;

            if (notExist)
                throw new Exception();

            existingProduct.Update(product);

            await _repository.Update(existingProduct);
        }

        public Task Delete(string id)
        {
            return _repository.Delete(id);
        }
    }
}
