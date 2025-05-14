using Application.DTO.Request.Orders;
using Application.DTO.Response;
using MediatR;

namespace Application.Service.Products.Commands.Orders
{
    public record CreateOrderCommand(CreateOrderRequestDTO Model) : IRequest<ServiceResponse>;
    
}
