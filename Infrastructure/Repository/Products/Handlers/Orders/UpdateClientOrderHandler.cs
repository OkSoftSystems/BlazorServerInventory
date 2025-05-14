using Application.DTO.Response;
using Application.Service.Products.Commands.Orders;
using Domain.Entities.Products;
using Infrastructure.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Products.Handlers.Orders
{
    public class UpdateClientOrderHandler(DataAccess.IDbContextFactory<AppDbContext> contextFactory) : IRequestHandler<UpdateClientOrderCommand, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(UpdateClientOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                using var dbContext = contextFactory.CreateDbContext();
                var data = await dbContext.Orders
                    .Where(o => o.Id == request.Model.OrderId)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);
                if (data == null)
                    return new ServiceResponse(false, "Order not found");

                data.OrderState = request.Model.OrderState;
                data.DeliveringDate = request.Model.DeliveringDate;                
                await dbContext.SaveChangesAsync(cancellationToken);
                return new ServiceResponse(true,"Order successfully updated");
            }
            catch (Exception ex)
            {
                return new ServiceResponse(true, ex.Message);
            }
        }
    }
}
