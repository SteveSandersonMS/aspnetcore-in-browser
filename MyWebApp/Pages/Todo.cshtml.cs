using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWebApp.Models;

namespace MyWebApp.Pages;

[IgnoreAntiforgeryToken(Order = 2000)]
public class TodoModel : PageModel
{
    public IReadOnlyCollection<TodoItem> TodoItems { get; private set; } = default!;

    public async Task OnGetAsync([FromServices] ITodoList todoList)
    {
        TodoItems = await todoList.GetTodoItemsAsync();
    }

    public async Task<IActionResult> OnPostAsync([FromServices] ITodoList todoList, TodoItem item)
    {
        if (!ModelState.IsValid)
        {
            await OnGetAsync(todoList);
            return Page();
        }

        await todoList.AddTodoItemAsync(item);

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAsync([FromServices] ITodoList todoList, int id)
    {
        await todoList.DeleteTodoItemAsync(id);
        return RedirectToPage();
    }
}
