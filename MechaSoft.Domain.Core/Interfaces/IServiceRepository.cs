using MechaSoft.Domain.Model;

namespace MechaSoft.Domain.Core.Interfaces;

public interface IServiceRepository
{
    Task<Service> SaveAsync(Service service);
    Task<Service?> GetByIdAsync(Guid id);
    Task<IEnumerable<Service>> GetAllAsync();
    Task<IEnumerable<Service>> GetByCategoryAsync(ServiceCategory category);
    Task<IEnumerable<Service>> GetActiveServicesAsync();
    Task<IEnumerable<Service>> SearchByNameAsync(string name);
    Task<Service> UpdateAsync(Service service);
    Task DeleteAsync(Guid id);
}