namespace MyWebApp.Models;

public interface ITodoList
{
    Task<IReadOnlyCollection<TodoItem>> GetTodoItemsAsync();
    Task AddTodoItemAsync(TodoItem item);
    Task DeleteTodoItemAsync(int id);
}
