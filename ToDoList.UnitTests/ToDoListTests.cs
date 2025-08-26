namespace ToDoList.UnitTests;


[TestFixture]
public class ToDoListTests
{
    [Test]
    public void CanAddANewItem()
    {
        // Arrange
        var todoList = new ToDoList();

        // Act
        todoList.AddNewTask("Test task");

        // Assert
        Assert.That(todoList.Tasks.Exists(x => x.Description == "Test task"), Is.True);
    }

    [Test]
    public void AddingDuplicateItemThrows()
    {
        // Arrange
        var todoList = new ToDoList();
        string taskName = "Test task";

        todoList.AddNewTask(taskName);

        // Act + assert
        Assert.Throws<TaskAlreadyExistsException>(() =>
        {
            todoList.AddNewTask(taskName);
        });
    }

    [Test]
    public void CanAddDuplicateTaskIfPreviousIsComplete()
    {
		//Arrange
		var todoList = new ToDoList();
        string taskName = "Test task";

        var task = todoList.AddNewTask(taskName);
        task.MarkAsComplete();

		// Act + assert
		Assert.That(todoList.Tasks.Exists(x => x.Description == taskName), Is.True);
	}

    [Test]
    public void CanMarkTaskAsComplete()
    {
        // Arrange
        var todoList = new ToDoList();
        string taskName = "Test task";

        todoList.AddNewTask(taskName);

        // Assert guard
        Assert.IsFalse(todoList.Tasks.First(x => x.Description == taskName).Complete);

        // Act
        todoList.Tasks.First(x => x.Description == taskName).MarkAsComplete();

        // Assert
        Assert.That(todoList.Tasks.First(x => x.Description == taskName).Complete, Is.True);
    }

    [Test]
    public void CanRemoveTask()
    {
        // Arrange
        var todoList = new ToDoList();
        string taskName = "Test task";

        todoList.AddNewTask(taskName);

        // Act
        todoList.RemoveTask(taskName);

        // Assert
        Assert.That(todoList.Tasks.Exists(x => x.Description == taskName), Is.False);
    }

    [Test]
    public void RemoveTaskThatDoesntExistThrows()
    {
        // Arrange
        var todoList = new ToDoList();
        string taskName = "Test task";

        // Act + assert
        Assert.Throws<TaskDoesNotExistException>(() =>
        {
            todoList.RemoveTask(taskName);
        });
    }

    [Test]
    public void ListIncompleteTasks()
    {
        // Arrange
        var todoList = new ToDoList();

        todoList.AddNewTask("Empty bins");
        todoList.AddNewTask("Make dinner");
        todoList.AddNewTask("Wash up");
        todoList.Tasks.First(x => x.Description == "Empty bins").MarkAsComplete();

        // Act
        var incompleteTasks = todoList.ListIncompleteTasks();

		// Assert
		Assert.That(incompleteTasks.Any(t => t.Description == "Make dinner"));
	}
}