using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.DataAccessor.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EShop.Business.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<Product> Products { get; }
        IGenericRepository<User> Users { get; }
        IGenericRepository<Order> Orders { get; }
        Task SaveAsync();
    }
}