using MediatR;
using MechaSoft.Domain.Model;

namespace MechaSoft.Application.Customers.Queries
{
    public record GetCustomerByIdQuery(Guid Id) : IRequest<Customer>;
}