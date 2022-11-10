using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using EShop.DataAccessor.Model;
using System.Collections;

namespace EShop.Business.Validator
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(Category => Category.Id).NotEmpty();
        }
    }
}