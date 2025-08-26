using Task = ToDoList.Models.Task;
using ToDoList.Models;

namespace ToDoList.UnitTests;
using NUnit.Framework;

[TestFixture]
public class TaskTests
{
    [Test]
    public void IsOverdue_ShouldReturnTrue_WhenCriticalTaskIsOverdue()
    {
        // Arrange
        Task task = new Task("Critical Task", Priority.Critical, DateTime.Now.AddDays(-3));

        // Act
        bool result = task.IsOverdue();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsOverdue_ShouldReturnTrue_WhenHighTaskIsOverdue()
    {
        // Arrange
        Task task = new Task("High Priority Task", Priority.High, DateTime.Now.AddDays(-6));

        // Act
        bool result = task.IsOverdue();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsOverdue_ShouldReturnTrue_WhenMediumTaskIsOverdue()
    {
        // Arrange
        Task task = new Task("Medium Priority Task", Priority.Medium, DateTime.Now.AddDays(-11));

        // Act
        bool result = task.IsOverdue();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsOverdue_ShouldReturnTrue_WhenLowTaskIsOverdue()
    {
        // Arrange
        Task task = new Task("Low Priority Task", Priority.Low, DateTime.Now.AddDays(-31));

        // Act
        bool result = task.IsOverdue();

        // Assert
        Assert.IsTrue(result);
    }
}