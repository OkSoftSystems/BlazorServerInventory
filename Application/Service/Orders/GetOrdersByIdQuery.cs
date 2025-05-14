
using Application.DTO.Response.Orders;
using MediatR;

namespace Application.Service.Orders
{
    public record GetOrdersByIdQuery(string UserId) : IRequest<IEnumerable<GetOrderResponseDTO>>;
    
}
