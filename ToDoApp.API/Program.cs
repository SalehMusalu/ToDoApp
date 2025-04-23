using Microsoft.EntityFrameworkCore;
using System;
using ToDoApp.Application;
using ToDoApp.Application.Commands;
using ToDoApp.Infrastructure;
using ToDoApp.Infrastructure.Context;

namespace ToDoApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApplicationConfigurations();

            builder.Services.ConfigureInfraServices(builder.Configuration);



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AddToDoItem>());

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
