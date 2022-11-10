using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Contracts.Dtos.EnumDtos;

namespace EShop.Contracts
{
    public class BaseQueryCriteria
    {
        public string? Search { get; set; } 
        public string? SortColumn {get; set;}
        public SortOrderEnumDto? SortOrder { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;

    }
}