using ToDoApp.Domain.Entities;

namespace ToDoApp.Domain.Factories
{
    public class ToDoItemFactory : IToDoItemFactory
    {
        public ToDoItem Create(string title, string description, ToDoStatus status)
        {
            var item = new ToDoItem(title, description);

            if (status == ToDoStatus.Completed)
                item.MarkAsCompleted();

            return item;

        }

        public ToDoItem Update(Guid id, string title, string description, ToDoStatus status)
        {
            var item = new ToDoItem(id,title, description);

            if (status == ToDoStatus.Completed)
                item.MarkAsCompleted();

            return item;
        }
    }
}
