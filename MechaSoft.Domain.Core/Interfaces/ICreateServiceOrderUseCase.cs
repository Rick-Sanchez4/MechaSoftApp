using MechaSoft.Domain.Model;

namespace MechaSoft.Domain.Core.Interfaces;

public interface ICreateServiceOrderUseCase
{
    Task<ServiceOrder> ExecuteAsync(CreateServiceOrderRequest request);
}
