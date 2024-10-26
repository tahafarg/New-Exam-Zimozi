using model;
using ModelRepo.EmployeeRepo;

namespace ModelService.EmpService
{
    public class EmpService : IEmpService
    {
        private readonly IEmpRepo _employeeRepository;

        public EmpService(IEmpRepo employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAll();
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid id)
        {
            return await _employeeRepository.Get(id);
        }

        public async Task<bool> CreateEmployeeAsync(Employee employee)
        {
           return await _employeeRepository.Insert(employee);
        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.Update(employee);
        }


        public async Task<bool> DeleteEmployeeAsync(Guid id)
        {
           return await _employeeRepository.Delete(id);
        }

       
    }
}
