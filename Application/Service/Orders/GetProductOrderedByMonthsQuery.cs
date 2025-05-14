using Application.DTO.Response.Orders;
using MediatR;

namespace Application.Service.Orders
{
    // for generating graph
    public record GetProductOrderedByMonthsQuery(string UserId = null) : IRequest<IEnumerable<GetProductOrderedByMonthsResponseDTO>>;
    
}
