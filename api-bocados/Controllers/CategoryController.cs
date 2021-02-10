using AutoMapper;
using Domain.Entities;
using api_bocados.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Domain.Interfaces.Application;
using Microsoft.AspNetCore.Authorization;

namespace api_bocados.Controllers
{
    [Route("api/category")]
    [ApiController]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _manager;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<CategoryModel>>> Get()
        {
            var categories = await _manager.Get();
            var categoriesModel = _mapper.Map<IEnumerable<CategoryModel>>(categories);
            return Ok(categoriesModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModel>> Get(string id)
        {
            var category = await _manager.Get(id);
            var categoryModel = _mapper.Map<CategoryModel>(category);
            return Ok(categoryModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CategoryModel categoryModel)
        {
            var category = _mapper.Map<Category>(categoryModel);
            await _manager.Create(category);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(CategoryModel categoryModel)
        {
            var category = _mapper.Map<Category>(categoryModel);
            await _manager.Update(category);
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
