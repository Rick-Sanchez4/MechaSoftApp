using MediatR;
using MechaSoft.Domain.Model;

namespace MechaSoft.Application.Customers.Commands
{
    public record CreateCustomerCommand(
        string FirstName,
        string LastName,
        string Email,
        string Phone,
        Address Address,
        CustomerType Type,
        string? Nif = null,
        string? CitizenCard = null,
        string? Notes = null
    ) : IRequest<Guid>;
}