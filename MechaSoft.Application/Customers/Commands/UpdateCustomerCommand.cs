using MediatR;
using MechaSoft.Domain.Model;

namespace MechaSoft.Application.Customers.Commands
{
    public record UpdateCustomerCommand(
        Guid Id,
        string Email,
        string Phone,
        Address Address,
        string? Notes = null
    ) : IRequest;
}