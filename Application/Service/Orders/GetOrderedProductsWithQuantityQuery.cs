
using Application.DTO.Response.Orders;
using MediatR;

namespace Application.Service.Orders
{
    public record GetOrderedProductsWithQuantityQuery(string UserId = null) : IRequest<IEnumerable<GetOrderedProductsWithQuantityResponseDTO>>;
   
}
