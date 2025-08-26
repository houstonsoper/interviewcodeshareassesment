using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;
using Task = ToDoList.Models.Task;

namespace ToDoList.Strategies
{
	public interface IOverdueStrategy
	{
		bool IsOverdue(Task task);
	}
}
