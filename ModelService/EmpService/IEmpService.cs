using model;

namespace ModelService.EmpService
{
    public interface IEmpService
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(Guid id);
        Task<bool> CreateEmployeeAsync(Employee employee);
        Task<bool> UpdateEmployeeAsync(Employee employee);
        //Task<Employee?> UpdateEmployeeAsync1(int id, Employee employee);
        Task<bool> DeleteEmployeeAsync(Guid id);
        
    }
}
