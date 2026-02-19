using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ToDoListCrossPlatform.ViewModels;

public partial class MainViewModel : ViewModelBase
{

    /// <summary>
    /// Gets a collection of <see cref="Models.ToDoItem"/> to allow adding and removing items
    /// </summary>
    public ObservableCollection<ToDoItemViewModel> ToDoItems { get; } = [];

    /// <summary>
    /// Gets or sets teh conetnt for the new Items to add. If this stirng is not empty, the add item command will be enabled
    /// </summary>
    [ObservableProperty]
    [NotifyCanExecuteChangedFor((nameof(AddItemCommand)))] //Attribute to invalidate command each time this property changes
    private string? _newItemContent;
    
    /// <summary>
    /// Returns if a new Item can be added. We require to have the NewItem some Text
    /// </summary>
    /// <returns></returns>
    private bool CanAddItem() => !string.IsNullOrWhiteSpace(NewItemContent);

    
    /// <summary>
    /// Command to add new item to the list
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanAddItem))]
    private void AddItem()
    {
        //Add new item to the list
        ToDoItems.Add(new ToDoItemViewModel(){Content = NewItemContent});
        
        // reset the NewItemContent
        NewItemContent = null;
    }

    /// <summary>
    /// Removes the given item from the list
    /// </summary>
    /// <param name="item">the item to remove</param>
    [RelayCommand]
    private void RemoveItem(ToDoItemViewModel item)
    {
        ToDoItems.Remove(item);
    }
}