using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Strategies;

namespace ToDoList.Factories
{
	public static class OverdueStrategyFactory
	{
		public static IOverdueStrategy GetStrategy(Priority priority)
		{
			return priority switch
			{
				Priority.Critical => new CriticalPriorityOverdueStrategy(),
				Priority.High => new HighPriorityOverdueStrategy(),
				Priority.Medium => new MediumPriorityOverdueStrategy(),
				Priority.Low => new LowPriorityOverdueStrategy(),
				_ => throw new NotSupportedException()
			};
		}
	}
}
