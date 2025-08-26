using ToDoList.Factories;

namespace ToDoList.Models;

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
		var overdueStrategy = OverdueStrategyFactory.GetStrategy(Priority);
		return overdueStrategy.IsOverdue(this);
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