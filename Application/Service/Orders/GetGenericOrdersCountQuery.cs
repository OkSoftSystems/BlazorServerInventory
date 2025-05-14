
using Application.DTO.Response;
using Application.DTO.Response.Orders;
using MediatR;

namespace Application.Service.Orders
{
    public record GetGenericOrdersCountQuery(string UserId, bool IsAdmin = false) : IRequest<GetOrdersCountResponseDTO>;
    
}
