
using Application.DTO.Response.Products;
using MediatR;

namespace Application.Service.Products.Queries.Products
{
    public class GetProductsWithQuantityLeftQuery : IRequest<IEnumerable<GetProductsWithQuantityLeftResponseDTO>> { }
}
