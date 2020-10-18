using AutoMapper;
using Domain.Entities;
using System.Threading.Tasks;
using Infraestructure.Entities;
using Infraestructure.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Domain.Interfaces.Infraestructure;

namespace Infraestructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoService _mogoService;
        private readonly IMapper _mapper;

        private readonly string _collectionName;

        public ProductRepository(IMongoService mongoService,
            IConfiguration configuration, IMapper mapper)
        {
            _mogoService = mongoService;
            _mapper = mapper;
            _collectionName = configuration["AppSettings:productCollection"];
        }

        public async Task<IEnumerable<Product>> Get()
        {
            var productEntity = await _mogoService.Get<ProductEntity>(_collectionName);

            var product = _mapper.Map<IEnumerable<Product>>(productEntity);

            return product;
        }


        public async Task<Product> Get(string id)
        {
            var productEntity = await _mogoService.Get<ProductEntity>(_collectionName, id);

            var product = _mapper.Map<Product>(productEntity);

            return product;
        }

        public Task Create(Product product)
        {
            var productEntity = _mapper.Map<ProductEntity>(product);

            return _mogoService.Create(_collectionName, productEntity);
        }

        public Task Update(Product product)
        {
            var productEntity = _mapper.Map<ProductEntity>(product);

            return _mogoService.Update(_collectionName, productEntity.Id, productEntity);
        }

        public Task Delete(string id)
        {
            return _mogoService.Delete<ProductEntity>(_collectionName, id);
        }
    }
}
