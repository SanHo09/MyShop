using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Contracts.Dtos.Category
{
    public class CategoryUpdateDto
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}