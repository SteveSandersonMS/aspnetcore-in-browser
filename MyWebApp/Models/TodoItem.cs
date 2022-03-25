using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models;

public class TodoItem
{
    public int Id { get; set; }
    
    [Required, StringLength(20)] public string? Text { get; set; }
}
