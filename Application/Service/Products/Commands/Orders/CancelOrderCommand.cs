
using Application.DTO.Response;
using MediatR;

namespace Application.Service.Products.Commands.Orders
{
    public record CancelOrderCommand(Guid OrderId) : IRequest<ServiceResponse>;
    
}
