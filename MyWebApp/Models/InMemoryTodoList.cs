namespace MyWebApp.Models;

public class InMemoryTodoList : ITodoList
{
    private int _nextId = 3;

    private List<TodoItem> _todoItems = new List<TodoItem>
    {
        new TodoItem { Id = 1, Text = "Publish app as single WASI-compliant file" },
        new TodoItem { Id = 2, Text = "Explore other WASI hosting scenarios" },
    };

    public Task AddTodoItemAsync(TodoItem item)
    {
        item.Id = _nextId++;
        _todoItems.Add(item);

        return Task.CompletedTask;
    }

    public Task DeleteTodoItemAsync(int id)
    {
        _todoItems.RemoveAll(x => x.Id == id);
        return Task.CompletedTask;
    }

    public Task<IReadOnlyCollection<TodoItem>> GetTodoItemsAsync()
    {
        return Task.FromResult((IReadOnlyCollection<TodoItem>)_todoItems);
    }
}
