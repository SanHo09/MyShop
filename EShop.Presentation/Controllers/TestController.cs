using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EShop.DataAccessor.Model;
using EShop.Business.Interfaces;
using EShop.Contracts.Dtos.Category;
using EShop.Contracts.Exceptions;

namespace EShop.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public TestController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // [HttpGet("All")]
        // public async Task<ActionResult<IEnumerable<Category>>> returnCategoryValue() 
        // {
        //     var data = await _categoryService.GetAll();
        //     throw new NotFoundException();
        //     return Ok(data);
        // }

        [HttpPost("Add")]
        public async Task<ActionResult<Category>> TestPostValue(CategoryCreateDto input) 
        {
            var returnData = await _categoryService.Insert(input);
            
            return returnData;
        }

        [HttpPut("update")]
        public async Task<ActionResult<Category>> TestPutValue(CategoryUpdateDto input) 
        {
            var returnData = await _categoryService.Update(input);

            return returnData;
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> TestDeleteValue(int input) 
        {
            await _categoryService.Remove(input);

            return Ok();
        }
    }
}