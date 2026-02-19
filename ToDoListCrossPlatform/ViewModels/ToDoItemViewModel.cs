using CommunityToolkit.Mvvm.ComponentModel;
using ToDoListCrossPlatform.Models;
using ToDoListCrossPlatform.ViewModels;

namespace ToDoListCrossPlatform.ViewModels;
/// <summary>
/// This is a ViewModel which represents a <see cref="Models.ToDoItem"/>
/// </summary>

public partial class ToDoItemViewModel : ViewModelBase
{
    /// <summary>
    /// Gets pr sets the checked status of each item
    /// </summary>
    [ObservableProperty]
    private bool _isChecked;
    
    /// <summary>
    /// Gets or sets the contenmt of the to-do item
    /// </summary>
    [ObservableProperty]
    private string? _content;

    /// <summary>
    /// Creates an empty ToDoItemViewModel
    /// </summary>
    public ToDoItemViewModel()
    {
        
    }
    
    /// <summary>
    /// Creates a new TodoItemViewModel from a <see cref="Models.ToDoItem"/>
    /// </summary>
    /// <param name="toDoItem"></param>
    public ToDoItemViewModel(ToDoItem toDoItem)
    {
        IsChecked = toDoItem.IsChecked;
        Content = toDoItem.Content;
    }

    public ToDoItem GetToDoItem()
    {
        return new ToDoItem()
        {
            IsChecked = this.IsChecked,
            Content = this.Content
        };
    }
}