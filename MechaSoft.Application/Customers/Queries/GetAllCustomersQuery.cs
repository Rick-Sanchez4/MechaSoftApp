using MediatR;
using MechaSoft.Domain.Model;
using System.Collections.Generic;

namespace MechaSoft.Application.Customers.Queries
{
    public record GetAllCustomersQuery() : IRequest<IEnumerable<Customer>>;
}