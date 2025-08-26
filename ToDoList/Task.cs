namespace ToDoList;

public class Task
{
    public string Description { get; set; }
    public bool Complete { get; private set; }
    public Priority Priority { get; }
    public DateTime StartDate { get; set; }

    public Task(string description, Priority priority, DateTime startDate)
    {
        StartDate = startDate;
        Complete = false;
        Priority = priority;
        Description = description;
    }

    public bool IsOverdue()
    {
        switch (Priority)
        {
            case Priority.Critical:
                if ((DateTime.Now - StartDate).Days > 2 && !Complete)
                {
                    Description = "!! CRITICAL PRIORITY TASK OVERDUE !!" + Description;
                    return true;
                }
                break;
            case Priority.High:
                if ((DateTime.Now - StartDate).Days > 5 && !Complete)
                {
                    Description = "!! HIGH PRIORITY TASK OVERDUE !!" + Description;
                    return true;
                }
                break;
            case Priority.Medium:
                if ((DateTime.Now - StartDate).Days > 10 && !Complete)
                {
                    Description = "!! MEDIUM PRIORITY TASK OVERDUE !!" + Description;
                    return true;
                }
                break;
            case Priority.Low:
                if ((DateTime.Now - StartDate).Days > 30 && !Complete)
                {
                    Description = "!! LOW PRIORITY TASK OVERDUE !!" + Description;
                    return true;
                }
                break;
            default:
                throw new NotSupportedException();
        }

        return false;
    }

    public void MarkAsComplete()
    {
        Complete = true;
    }
}

public enum Priority
{
    Critical,
    High, 
    Medium, 
    Low
}