namespace ToDoListCrossPlatform.Models;
/// <summary>
/// This is our Model for a simple ToDoTItem
/// </summary>
public class ToDoItem
{
    /// <summary>
    /// Gets or sets the chceked status of each item
    /// </summary>
    public bool IsChecked { get; set; }
    
    /// <summary>
    /// Gets or sets the content of the todo item
    /// </summary>
    public string? Content { get; set; }
}