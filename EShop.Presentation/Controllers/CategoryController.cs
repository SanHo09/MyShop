using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EShop.DataAccessor.Model;
using EShop.Business.Interfaces;
using EShop.Contracts.Dtos.Category;
using EShop.Contracts;
using EShop.Contracts.Exceptions;

namespace EShop.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll([FromQuery]BaseQueryCriteria baseQueryCriteria, CancellationToken token) 
        {
            var data = await _categoryService.GetAll(baseQueryCriteria, token);
            return Ok(data);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Category>> Insert(CategoryCreateDto input) 
        {
            var returnData = await _categoryService.Insert(input);
            
            return returnData;
        }

        [HttpPut("update")]
        public async Task<ActionResult<Category>> Update(CategoryUpdateDto input) 
        {
            var returnData = await _categoryService.Update(input);

            return returnData;
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int input) 
        {
            await _categoryService.Remove(input);

            return Ok();
        }
    }
}