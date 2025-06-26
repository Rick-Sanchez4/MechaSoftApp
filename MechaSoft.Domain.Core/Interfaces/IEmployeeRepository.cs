using MechaSoft.Domain.Model;

namespace MechaSoft.Domain.Core.Interfaces;

public interface IEmployeeRepository
{
    Task<Employee> SaveAsync(Employee employee);
    Task<Employee?> GetByIdAsync(Guid id);
    Task<Employee?> GetByEmailAsync(string email);
    Task<IEnumerable<Employee>> GetAllAsync();
    Task<IEnumerable<Employee>> GetByRoleAsync(EmployeeRole role);
    Task<IEnumerable<Employee>> GetMechanicsWithSpecialtyAsync(ServiceCategory specialty);
    Task<IEnumerable<Employee>> GetActiveEmployeesAsync();
    Task<Employee> UpdateAsync(Employee employee);
    Task DeleteAsync(Guid id);
}