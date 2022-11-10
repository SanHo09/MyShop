using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EShop.Business.Interfaces;
using EShop.Contracts.Dtos.Category;
using EShop.DataAccessor.Model;
using EShop.Contracts;
using EShop.Business.Extensions;
namespace EShop.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedResponse<Category>> GetAll(BaseQueryCriteria baseQueryCriterial, CancellationToken token)
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();

            var query = categories
                                .Where(category => CheckContainAllPropertiesInEntity
                                                .Filter(category, baseQueryCriterial.Search))
                                .AsQueryable();

            var paging = query.PaginateAsync(baseQueryCriterial, token);
            
            return paging;
        }   

        public async Task<Category> Insert(CategoryCreateDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);

            await _unitOfWork.Categories.InsertAsync(category);

            await _unitOfWork.SaveAsync();

            return category;
        }

        public async Task<Category> Update(CategoryUpdateDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            
            await _unitOfWork.Categories.UpdateAsync(category);

            await _unitOfWork.SaveAsync();

            return category;
        }

        public async Task Remove(Object id)
        {
            await _unitOfWork.Categories.RemoveAsync(id);

            await _unitOfWork.SaveAsync();
        }

        public async Task<Category> GetById(object id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);

            return category;
        }

    }
}