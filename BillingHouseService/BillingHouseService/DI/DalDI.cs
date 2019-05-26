using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BH.DAL.Repositories;
using BH.DTOL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BH.WebApi.DI
{
    public static class DalDI
    {
        public static void ConfigureMsSqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<IUnitOfWork, EntityFrameworkUnitOfWork>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("BH.WebApi"))
            );
        }
    }
}
