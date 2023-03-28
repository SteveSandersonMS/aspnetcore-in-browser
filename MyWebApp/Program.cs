using MyWebApp.Models;

var builder = WebApplication.CreateBuilder(args).UseWasiConnectionListener();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<ITodoList, InMemoryTodoList>();

var app = builder.Build();

app.UsePathBase(Environment.GetEnvironmentVariable("ASPNETCORE_APPL_PATH"));
app.UseRouting();
app.UseBundledStaticFiles();
app.MapRazorPages();

app.MapGet("/api/todos", (ITodoList todoList) => todoList.GetTodoItemsAsync());

app.Run();
