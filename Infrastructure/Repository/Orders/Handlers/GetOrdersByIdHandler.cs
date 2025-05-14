
using Application.DTO.Response.Orders;
using Application.Service.Orders;
using Domain.Entities.Orders;
using Infrastructure.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Orders.Handlers
{
    public class GetOrdersByIdHandler(DataAccess.IDbContextFactory<AppDbContext> contextFactory) : IRequestHandler<GetOrdersByIdQuery, IEnumerable<GetOrderResponseDTO>>
    {
        public async Task<IEnumerable<GetOrderResponseDTO>> Handle(GetOrdersByIdQuery request, CancellationToken cancellationToken)
        {
            using var dbContext = contextFactory.CreateDbContext();
            var orders = await dbContext.Orders.AsNoTracking().Where(o => o.ClientId.ToString() == request.UserId).ToListAsync(cancellationToken: cancellationToken);
            var products = await dbContext.Products.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
            return orders.Select(order => new GetOrderResponseDTO
            {
                Id = order.Id,
                ProductName = products.FirstOrDefault(p => p.Id == order.ProductId)!.Name,
                Price = order.Price,
                DeliveringDate = order.DeliveringDate,
                OrderedDate = order.DateOrdered,
                ProductId = order.ProductId,
                ProductImage = products.FirstOrDefault(_ => _.Id == order.ProductId)!.Base64Image,
                Quantity = order.Quantity,
                SerialNumber = products.FirstOrDefault(p => p.Id == order.ProductId)!.SerialNumber,
                State = order.OrderState                
            }).ToList();
        }
    }
}
