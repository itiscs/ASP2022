

using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApiSimple;
using WebApiSimple.Controllers;
using WebApiSimple.Data;
using WebApiSimple.Models;

namespace TestProject1
{
    public class HomeControllerTest
    {

        [Fact]
        public void WeatherNotNull()
        {
            // Arrange
            WeatherForecastController controller = new WeatherForecastController();

            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void IndexReturnsAListOfTodoItems()
        {
            // Arrange
            var mock = new Mock<IRepository<TodoItem>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetTestTodos());
            var controller = new TodoItemsController(mock.Object);

            // Act
            var result = controller.GetTodoItems();

            // Assert
            var lst = Assert.IsType<List<TodoItem>>(result);
            Assert.Equal(GetTestTodos().Count, lst.Count());
        }

        private List<TodoItem> GetTestTodos()
        {
            var todos = new List<TodoItem>
            {
                new TodoItem { Id=1, Name="Todo 1", IsComplete=true},
                new TodoItem { Id=2, Name="Todo 2", IsComplete=false},
                new TodoItem { Id=3, Name="Todo 3", IsComplete=true}
            };
            return todos;
        }
    }
}

