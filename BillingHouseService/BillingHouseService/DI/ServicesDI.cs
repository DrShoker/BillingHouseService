using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BH.ServiceLayer.Services.CompanyServices;
using BH.ServiceLayer.Services.ConstructionWorksServices;
using BH.ServiceLayer.Services.FeedbackServices;
using BH.ServiceLayer.Services.Interfaces.Company;
using BH.ServiceLayer.Services.Interfaces.ConstructionWorks;
using BH.ServiceLayer.Services.Interfaces.Feedback;
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
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IConstructionWorksService, ConstructionWorksService>();
            services.AddScoped<ICompanyConstructionWorksService, CompanyConstructionWorksService>();
        }
    }
}
