using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Contracts.Dtos.Category;
using EShop.DataAccessor.Model;

namespace EShop.Business.Interfaces
{
    public interface ICategoryService : IBaseService<Category, CategoryCreateDto, CategoryUpdateDto>
    {
        
    }
}