using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Contracts;
using EShop.Contracts.Constants;
using EShop.Contracts.Dtos.EnumDtos;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace EShop.Business.Extensions
{
    public static class PagingnationsExtensions
    {
        public static PagedResponse<TModel> PaginateAsync<TModel>(
            this IQueryable<TModel> query,
            BaseQueryCriteria criteriaDto, 
            CancellationToken cancellationToken)
            where TModel : class
        {
             var paged = new PagedResponse<TModel>();

            var currentPage = criteriaDto.PageNumber < 1 ? 1 : criteriaDto.PageNumber;
            
            paged.PageNumber = currentPage;

            paged.PageSize = criteriaDto.PageSize;

            try {
                if(!string.IsNullOrEmpty(criteriaDto.SortOrder.ToString()) &&
                    !string.IsNullOrEmpty(criteriaDto.SortColumn))
                {
                    var sortOrder = criteriaDto.SortOrder == (int)SortOrderEnumDto.Ascending ?
                                        PagingSortingConstant.ASC : 
                                        PagingSortingConstant.DESC;

                    var orderString = $"{criteriaDto.SortColumn} {sortOrder}";
                    query = query.OrderBy(orderString);
                }
            } catch {
                // do-some catching
            }

            var startRow = (criteriaDto.PageNumber - 1) * criteriaDto.PageSize;

            paged.Items = query
                            .Skip(startRow)
                            .Take(criteriaDto.PageSize)
                            .ToList();

            paged.TotalRecords = query.Count();
            paged.TotalPage = (int)Math.Ceiling((paged.TotalRecords/(double)paged.PageSize));

            return paged;
        }
    }
}