using Xunit;
using Moq;
using FizzBuzz.Services.Interfaces;
using FizzBuzzApp.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FizzBizzApp.Test
{
    public class FizzBuzzControllerTests
    {
        [Fact]
        public async Task GetResult_ReturnsOk_WithValidNumber()
        {
            // Arrange
            var mockFizzBuzz = new Mock<IFizzBuzz>();
            mockFizzBuzz.Setup(service => service.GetFizzBuzz("15")).ReturnsAsync("FizzBuzz");
            var controller = new FizzBuzzController(mockFizzBuzz.Object);

            // Act
            var result = await controller.GetResult("15");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("FizzBuzz", okResult.Value);
        }

        [Fact]
        public async Task GetResult_ReturnsBadRequest_WithInvalidNumber()
        {
            // Arrange
            var mockFizzBuzz = new Mock<IFizzBuzz>();
            mockFizzBuzz.Setup(service => service.GetFizzBuzz("invalid")).ThrowsAsync(new System.ArgumentException("Invalid number"));
            var controller = new FizzBuzzController(mockFizzBuzz.Object);

            // Act
            var result = await controller.GetResult("invalid");

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid number", badRequestResult.Value);
        }

        [Fact]
        public async Task GetResult_HandlesException()
        {
            // Arrange
            var mockFizzBuzz = new Mock<IFizzBuzz>();
            mockFizzBuzz.Setup(service => service.GetFizzBuzz(null)).ThrowsAsync(new System.Exception("An error occurred"));
            var controller = new FizzBuzzController(mockFizzBuzz.Object);

            // Act
            var result = await controller.GetResult(null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("An error occurred", badRequestResult.Value);
        }
    }
}
