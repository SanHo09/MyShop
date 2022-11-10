using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.DataAccessor.Data;
using EShop.DataAccessor.Model;
using System.Collections.Generic;
using EShop.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using EShop.Business.Repository;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace EShop.Business
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Category> _categories;
        private IGenericRepository<Product> _products;
        private IGenericRepository<User> _users;
        private IGenericRepository<Order> _orders;
        public UnitOfWork(ApplicationDbContext context)
        {   
            _context = context;
        }

        public IGenericRepository<Category> Categories => _categories ??= new GenericRepository<Category>(_context);

        public IGenericRepository<Product> Products => _products ??= new GenericRepository<Product>(_context);

        public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(_context);

        public IGenericRepository<Order> Orders => _orders ??= new GenericRepository<Order>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}