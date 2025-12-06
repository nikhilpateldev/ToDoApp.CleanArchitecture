using Shared.Domain.Base;
using System;
using ToDoApp.Domain.Enums;

namespace ToDo.Domain.Entities;

public sealed class TodoList : AggregateRoot
{
    private readonly List<TodoItem> _items = new();

    private TodoList() { }

    public TodoList(string name, string? description = null)
    {
        Rename(name, description);
        CreatedOnUtc = DateTime.UtcNow;
    }

    public string Name { get; private set; } = default!;
    public string? Description { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }

    public IReadOnlyCollection<TodoItem> Items => _items.AsReadOnly();

    public TodoItem AddItem(
        string title,
        string? description,
        Priority priority,
        DateTime? dueDateUtc)
    {
        var item = new TodoItem(title, description, priority, dueDateUtc);
        _items.Add(item);
        return item;
    }

    public void RemoveItem(Guid itemId)
    {
        var item = _items.FirstOrDefault(x => x.Id == itemId);
        if (item != null)
            _items.Remove(item);
    }

    public void Rename(string name, string? description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Todo list name cannot be empty.");

        Name = name;
        Description = description;
    }
}
