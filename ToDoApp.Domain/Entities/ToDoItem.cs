namespace ToDoApp.Domain.Entities
{
    public class ToDoItem
    {
        public Guid Id { get; private set; } 
        public string Title { get; private set; }
        public string Description { get; private set; }
        public ToDoStatus Status { get; private set; } = ToDoStatus.Pending;

        private ToDoItem() { }

        public ToDoItem(string title, string description)
        {
            SetTitle(title);
            SetDescription(description);
        }

        public ToDoItem(Guid id, string title, string description)
        {
            SetId(id);
            SetTitle(title);
            SetDescription(description);
        }

        public void SetId(Guid id)
        {
            Id = id;
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty");
            Title = title;
        }

        public void SetDescription(string description)
        {
            Description = description ?? "";
        }

        public void MarkAsCompleted()
        {
            Status = ToDoStatus.Completed;
        }

        public void MarkAsPending()
        {
            Status = ToDoStatus.Pending;
        }
    }

    public enum ToDoStatus
    {
        Pending,
        Completed
    }
}
