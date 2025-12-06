using Shared.Domain.Base;
using ToDoApp.Domain.Enums;

namespace ToDo.Domain.Entities;

public sealed class TodoItem : Entity
{
    private TodoItem() { }

    internal TodoItem(
        string title,
        string? description,
        Priority priority,
        DateTime? dueDateUtc)
    {
        Update(title, description, priority, dueDateUtc);
        IsCompleted = false;
        CreatedOnUtc = DateTime.UtcNow;
    }

    public string Title { get; private set; } = default!;
    public string? Description { get; private set; }
    public Priority Priority { get; private set; }
    public DateTime? DueDateUtc { get; private set; }

    public bool IsCompleted { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? CompletedOnUtc { get; private set; }


    public void Update(
        string title,
        string? description,
        Priority priority,
        DateTime? dueDateUtc)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Todo item title cannot be empty.");

        Title = title;
        Description = description;
        Priority = priority;
        DueDateUtc = dueDateUtc;
    }

    public void Complete()
    {
        if (IsCompleted)
            return;

        IsCompleted = true;
        CompletedOnUtc = DateTime.UtcNow;
    }

    public void Reopen()
    {
        if (!IsCompleted)
            return;

        IsCompleted = false;
        CompletedOnUtc = null;
    }
}
