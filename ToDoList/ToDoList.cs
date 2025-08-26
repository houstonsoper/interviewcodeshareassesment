using System.Text;
using ToDoList.Models;
using Task = ToDoList.Models.Task;

namespace ToDoList;

public class ToDoList
{
    public List<Task> Tasks { get; }

    public ToDoList()
    {
        Tasks = new List<Task>();
    }

    public Task AddNewTask(string description, Priority priority = Priority.Medium)
    {
        var incompleteTasks = ListIncompleteTasks();

        if (incompleteTasks.Any(t => t.Description.ToLower() == description.ToLower()))
        {
			throw new TaskAlreadyExistsException();
		}

        var task = new Task(description, priority, DateTime.Now);
		Tasks.Add(task);

        return task;
    }

    public void RemoveTask(string description)
    {
        var taskToRemove = Tasks.FirstOrDefault(x => x.Description == description);

        if (taskToRemove != null)
            Tasks.Remove(taskToRemove);
        else
            throw new TaskDoesNotExistException();
    }

    public List<Task> ListIncompleteTasks()
    {
        var incompleteTasks = new List<Task>();

        foreach (var task in Tasks)
        {
            if (!task.Complete)
                incompleteTasks.Add(task);
        }

        return incompleteTasks;
    }
}

public class TaskAlreadyExistsException : ApplicationException
{
}

public class TaskDoesNotExistException : ApplicationException
{
}