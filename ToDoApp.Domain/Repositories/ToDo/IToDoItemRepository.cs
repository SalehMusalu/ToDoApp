using ToDoApp.Domain.Entities;

namespace ToDoApp.Domain.Repositories.ToDo
{
    public interface IToDoItemRepository : IGenericRepository<ToDoItem>
    {
        Task<ToDoItem> GetToDoItemById(Guid id);
        Task<List<ToDoItem>> GetAllToDoItem();
        Task<bool> IsToDoExistsByTitle(string title);
        Task<ToDoItem> GetToDoByIdAndTitle(Guid id,string title);
    }
}
