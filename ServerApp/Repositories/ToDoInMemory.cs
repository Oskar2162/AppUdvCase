using ServerApp.Model;

namespace ServerApp.Repositories;

public class ToDoInMemory
{
    private List<TodoItem> items = new List<TodoItem>();

    public void AddItem(TodoItem item)
    {
        items.Add(item);
    }

    public TodoItem[] GetAll()
    {
        return items.ToArray();
    }
    
    public void UpdateItem(TodoItem item)
    {
        var existingItem = items.FirstOrDefault(i => i.Title == item.Title);
        if (existingItem != null)
        {
            existingItem.IsDone = item.IsDone;
        }
    }
}