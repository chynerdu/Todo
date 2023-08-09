namespace newWebAppA00272195.Models;

public class TodoItem
{
     public int Id { get; }
    public string Description { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime? CompletionDate { get; set; }

    private static List<TodoItem> _instances = new List<TodoItem> { };

    // Initialize model and create new todo 
    public TodoItem(string description)
    {
      Description = description;
      _instances.Add(this);
      Id = _instances.Count;
    }

    // Get all created todo 
    public static List<TodoItem> GetAll()
    {
        return _instances;
    }

     // Mark checked todo items as completed
    public static void MarkAsCompleted(int[] todoIds)
    {
        foreach (TodoItem item in _instances)
        {
            if (todoIds.Contains(item.Id))
            {
                item.IsCompleted = true;
                item.CompletionDate = DateTime.Now;
            }
        }
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }
}
