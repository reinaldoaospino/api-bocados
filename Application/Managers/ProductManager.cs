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

        public async Task Create(Product product)
        {
            var products = await _repository.Get();

            var featuredProductCount = products.Where(p => bool.Parse(p.FeaturedProduct) == bool.Parse(product.FeaturedProduct)).Count();

            if (featuredProductCount >= 6)
                throw new MaxFeatureProductException();

            product.Id = product.GenerateGuid();

            await _repository.Create(product);
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
