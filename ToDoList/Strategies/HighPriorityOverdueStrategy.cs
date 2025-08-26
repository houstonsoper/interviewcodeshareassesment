using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;
using Task = ToDoList.Models.Task;


namespace ToDoList.Strategies
{
	public class HighPriorityOverdueStrategy : IOverdueStrategy
	{
		public bool IsOverdue(Task task)
		{
			if ((DateTime.Now - task.StartDate).Days > 5 && !task.Complete)
			{
				task.Description = "!! HIGH PRIORITY TASK OVERDUE !!" + task.Description;
				return true;
			}
			return false;
		}
	}
}
