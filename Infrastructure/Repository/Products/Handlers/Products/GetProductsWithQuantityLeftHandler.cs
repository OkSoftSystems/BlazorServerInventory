
using Application.DTO.Response.Products;
using Application.Extension;
using Application.Service.Products.Queries.Products;
using Infrastructure.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Products.Handlers.Products
{
    public class GetProductsWithQuantityLeftHandler(DataAccess.IDbContextFactory<AppDbContext> contextFactory) : IRequestHandler<GetProductsWithQuantityLeftQuery, IEnumerable<GetProductsWithQuantityLeftResponseDTO>>
    {
        public async Task<IEnumerable<GetProductsWithQuantityLeftResponseDTO>> Handle(GetProductsWithQuantityLeftQuery request, CancellationToken cancellationToken)
        {
            using var dbContext = contextFactory.CreateDbContext();
            var productsWithStock = await dbContext.Products
                .AsNoTracking()
                .Include(c => c.Category)
                .Include(l => l.Location)
                .ToListAsync(cancellationToken: cancellationToken);
            return productsWithStock.Select(product => new GetProductsWithQuantityLeftResponseDTO     // Can use mapper instead, mapster seems not working 
            {
                Id = product!.Id,
                Name = product.Name,
                Description = product.Description,
                Base64Image = product.Base64Image,
                CategoryId = product.CategoryId,
                LocationId = product.LocationId,
                Price = product.Price,
                DateAdded = product.DateAdded,
                Quantity = product.Quantity,
                SerialNumber = product.SerialNumber,
                Location = new GetLocationResponseDTO
                {
                    Id = product.LocationId,
                    Name = product.Location.Name
                },
                Category = new GetCategoryResponseDTO
                {
                    Id = product.CategoryId,
                    Name = product.Category.Name
                },
                QuantityLeft = product.Quantity - dbContext.Orders
                 .Where(o => o.ProductId == product.Id &&
                      (o.OrderState == OrderState.Processing ||
                      o.OrderState == OrderState.Delivering ||
                      o.OrderState == OrderState.Delivered))
                 .Sum(o => (int?)o.Quantity) ?? 0
            }).ToList();
        }
    }
}
