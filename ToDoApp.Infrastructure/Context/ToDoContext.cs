using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Infrastructure.Context
{
    public class ToDoContext : DbContext
    {
        #region constractor
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {

        }
        #endregion

        #region ToDoItem
        public DbSet<ToDoItem> ToDoItems { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configuration = new ToDoItemConfiguration();

            #region ToDo Management Configurations

            modelBuilder.ApplyConfiguration<ToDoItem>(configuration);

            #endregion

        }
    }
}
