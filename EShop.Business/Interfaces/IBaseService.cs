using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Contracts;

namespace EShop.Business.Interfaces
{
    public interface IBaseService<T, CreateDto, UpdateDto>
    {
        Task<PagedResponse<T>> GetAll(BaseQueryCriteria baseQueryCriterial, CancellationToken token);
        Task<T> GetById(object id);
        Task<T> Insert(CreateDto entity);
        Task<T> Update(UpdateDto entity);
        Task Remove(object id);
    }
}