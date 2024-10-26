using Microsoft.AspNetCore.Mvc.Testing;
using model;
using System.Net;
using System.Text;
using System.Text.Json;
using EmployeeManagementSystem.API;

namespace EmployeeManagement.Tests.Integration
{
    public class EmployeesControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public EmployeesControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task CreateEmployee_ValidData_ReturnsCreatedResponse()
        {
            // Arrange
            var client = _factory.CreateClient();
            var employee = new
            {
                Name = "Test Employee",
                Department = "Test Dept",
                Salary = 75000
            };

            var content = new StringContent(
                JsonSerializer.Serialize(employee),
                Encoding.UTF8,
                "application/json");

            // Act
            var response = await client.PostAsync("/api/employees", content);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.NotNull(response.Headers.Location);

            var createdEmployee = JsonSerializer.Deserialize<Employee>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
            Assert.NotEqual(Guid.Empty, createdEmployee.Id);
        }
    }
}