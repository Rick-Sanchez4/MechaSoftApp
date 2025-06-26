using MechaSoft.Domain.Model;

namespace MechaSoft.Domain.Core.Interfaces;

public interface IServiceOrderRepository
{
    Task<ServiceOrder> SaveAsync(ServiceOrder serviceOrder);
    Task<ServiceOrder?> GetByIdAsync(Guid id);
    Task<ServiceOrder?> GetByOrderNumberAsync(string orderNumber);
    Task<IEnumerable<ServiceOrder>> GetByCustomerIdAsync(Guid customerId);
    Task<IEnumerable<ServiceOrder>> GetByStatusAsync(ServiceOrderStatus status);
    Task<IEnumerable<ServiceOrder>> GetByMechanicIdAsync(Guid mechanicId);
    Task<IEnumerable<ServiceOrder>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task<IEnumerable<ServiceOrder>> GetPendingInspectionsAsync();
    Task<ServiceOrder> UpdateAsync(ServiceOrder serviceOrder);
    Task DeleteAsync(Guid id);
}
