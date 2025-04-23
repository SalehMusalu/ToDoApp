using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ToDoApp.Application.Extension;
using ToDoApp.Domain.Factories;

namespace ToDoApp.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationConfigurations(this IServiceCollection services)
        {
            services.AddSingleton<IToDoItemFactory, ToDoItemFactory>();


            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));



            return services;
        }
    }
}