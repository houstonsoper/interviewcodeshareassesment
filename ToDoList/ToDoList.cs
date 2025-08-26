using System.Text;

namespace ToDoList;

public class ToDoList
{
    public List<Task> Tasks { get; }

    public ToDoList()
    {
        Tasks = new List<Task>();
    }

    public void AddNewTask(string description, Priority priority = Priority.Medium)
    {
        Tasks.Add(new Task(description, priority, DateTime.Now));
    }

    public void RemoveTask(string description)
    {
        var taskToRemove = Tasks.FirstOrDefault(x => x.Description == description);

        if (taskToRemove != null)
            Tasks.Remove(taskToRemove);
        else
            throw new TaskDoesNotExistException();
    }

    public string ListIncompleteTasks()
    {
        StringBuilder taskList = new StringBuilder();

        foreach (var task in Tasks)
        {
            if (!task.Complete)
                taskList.AppendFormat("{0},", task.Description);
        }

        taskList.Length--;

        return taskList.ToString();
    }
}

public class TaskAlreadyExistsException : ApplicationException
{
}

public class TaskDoesNotExistException : ApplicationException
{
}