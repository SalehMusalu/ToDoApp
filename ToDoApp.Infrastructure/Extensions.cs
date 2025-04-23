using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoApp.Domain.Repositories.ToDo;
using ToDoApp.Infrastructure.Context;
using ToDoApp.Infrastructure.Repositories;

namespace ToDoApp.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection ConfigureInfraServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Repositories
            services.AddScoped<IToDoItemRepository, ToDoItemRepository>();
            #endregion

            #region Database


            services.AddDbContext<ToDoContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            #endregion

            return services;

        }
    }
}
