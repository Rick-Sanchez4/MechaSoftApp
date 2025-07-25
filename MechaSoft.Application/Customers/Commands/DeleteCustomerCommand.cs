using MediatR;

namespace MechaSoft.Application.Customers.Commands
{
    public record DeleteCustomerCommand(Guid Id) : IRequest;
}