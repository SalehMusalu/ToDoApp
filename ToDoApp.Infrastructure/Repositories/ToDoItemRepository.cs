using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Repositories.ToDo;
using ToDoApp.Infrastructure.Context;

namespace ToDoApp.Infrastructure.Repositories
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly ToDoContext _context;

        public ToDoItemRepository(ToDoContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ToDoItem entity)
        {
            await _context.ToDoItems.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<ToDoItem>> GetAll()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        public async Task<List<ToDoItem>> GetAllToDoItem()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        public async Task<ToDoItem> GetAsync(Guid id)
        {
            return await _context.ToDoItems
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ToDoItem> GetToDoByIdAndTitle(Guid id, string title)
        {
            return await _context.ToDoItems
                 .FirstOrDefaultAsync(t => t.Id == id && t.Title == title);
        }

        public async Task<ToDoItem> GetToDoItemById(Guid id)
        {
            return await _context.ToDoItems
                 .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<bool> IsToDoExistsByTitle(string title)
        {
            return await _context.ToDoItems
                .AnyAsync(c => c.Title == title);
        }

        public async Task RemoveAsync(ToDoItem entity)
        {
            _context.ToDoItems.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ToDoItem entity)
        {
            _context.ToDoItems.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
