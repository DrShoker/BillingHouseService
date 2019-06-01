﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BH.ServiceLayer.Services.CompanyServices;
using BH.ServiceLayer.Services.Interfaces.Company;
using BH.ServiceLayer.Services.Interfaces.User;
using BH.ServiceLayer.Services.UserServices;
using Microsoft.Extensions.DependencyInjection;

namespace BH.WebApi.DI
{
    public static class ServicesDI
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserProjectService, UserProjectService>();
            services.AddScoped<IProjectSchemaService, ProjectSchemaService>();
            services.AddScoped<ICompanyService, CompanyService>();
        }

    }
}
