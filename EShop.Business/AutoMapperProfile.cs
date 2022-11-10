using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.DataAccessor.Model;
using EShop.Contracts.Dtos.Category;

namespace EShop.Business
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            FromPresentationLayer();
            FromDataAccesorLayer();
        }

        private void FromPresentationLayer() 
        {

        }

        private void FromDataAccesorLayer() 
        {
            MapCategory();
        }

        private void MapCategory()
        {
            CreateMap<Category ,CategoryDto>()
                .ReverseMap();
            CreateMap<Category ,CategoryCreateDto>()
                .ReverseMap();
            CreateMap<Category ,CategoryUpdateDto>()
                .ReverseMap();
        }
    }
}