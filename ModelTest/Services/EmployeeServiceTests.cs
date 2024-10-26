using Microsoft.EntityFrameworkCore;
using model;
using ModelRepo.Context;
using ModelRepo.EmployeeRepo;

namespace EmployeeManagement.Tests.Services
{
    public class EmployeeServiceTests
    {
        private readonly DbContextOptions<AppDbContext> _options;

        public EmployeeServiceTests()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>()
                // add database name
                .UseInMemoryDatabase(databaseName: "employee_management")
                .Options;
        }

        [Fact]
        public async Task CreateEmployee_ValidEmployee_ReturnsCreatedEmployee()
        {
            // Arrange
            using var context = new AppDbContext(_options);
            var service = new EmpRepo(context);
            var employee = new Employee
            {
                Name = "John Doe",
                Department = "IT",
                Salary = 50000
            };

            // Act
            var result = await service.Insert(employee);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(" the result is", result.ToString());
            //Assert.NotEqual(Guid.Empty, result.EmployeeID);
            //Assert.Equal("John Doe", result.Name);
            //Assert.Equal("IT", result.Department);
            //Assert.Equal(50000, result.Salary);
        }

        [Fact]
        public async Task GetEmployeeById_ExistingEmployee_ReturnsEmployee()
        {
            // Arrange
            using var context = new AppDbContext(_options);
            var service = new EmpRepo(context);
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                Name = "Jane Smith",
                Department = "HR",
                Salary = 60000
            };
            context.Employees.Add(employee);
            await context.SaveChangesAsync();

            // Act
            var result = await service.Get(employee.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(employee.Id, result.Id);
            Assert.Equal("Jane Smith", result.Name);
        }
    }
}
