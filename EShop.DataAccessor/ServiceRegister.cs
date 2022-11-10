using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EShop.DataAccessor.Data;
using Microsoft.EntityFrameworkCore;

namespace EShop.DataAccessor
{
    public static class ServiceRegister
    {
        public static void AddDataAccessorLayer(this IServiceCollection services, IConfiguration config) 
        {
            // services.AddDbContext<ApplicationDbContext>(options =>
            //     options.UseSqlServer(config.GetConnectionString("DbConnection"), b =>
            //         b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
            //     ));
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Server=VNNOT01554\\SANG;Database=EShop;uid=sa;password=Abcd1234!;Trusted_Connection=True", b =>
                    b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                ));
        }
    }
}