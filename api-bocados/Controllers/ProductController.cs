using AutoMapper;
using Domain.Entities;
using api_bocados.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Domain.Interfaces.Application;

namespace api_bocados.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductManager _manager;
        private readonly IMapper _mapper;

        public ProductController(IProductManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<ProductModel>>> Get()
        {
            var product = await _manager.Get();
            var productModel = _mapper.Map<IEnumerable<ProductModel>>(product);
            return Ok(productModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> Get(string id)
        {
            var product = await _manager.Get(id);
            var productModel = _mapper.Map<ProductModel>(product);
            return Ok(productModel);
        }

        [HttpPost] 
        public async Task<ActionResult> Create(ProductModel productModel)
        {
            var product = _mapper.Map<Product>(productModel);
            await _manager.Create(product);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProductModel productModel)
        {
            var product = _mapper.Map<Product>(productModel);
            await _manager.Update(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _manager.Delete(id);
            return Ok();
        }
    }
}