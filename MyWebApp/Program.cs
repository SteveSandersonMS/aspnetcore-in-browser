using MyWebApp.Models;
using Wasi.AspNetCore.Server.CustomHost;

var builder = WebApplication.CreateBuilder(args).UseWasiCustomHostServer();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<ITodoList, InMemoryTodoList>();

var app = builder.Build();

app.UsePathBase(Environment.GetEnvironmentVariable("ASPNETCORE_APPL_PATH"));
app.UseRouting();
app.UseBundledStaticFiles();
app.MapRazorPages();

app.MapGet("/api/todos", (ITodoList todoList) => todoList.GetTodoItemsAsync());

app.Run();
