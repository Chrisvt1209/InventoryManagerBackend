using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Orders;
using Domain.Orders.DomainEvents;
using Domain.Products;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Orders.CreateOrder;

internal sealed class CreateOrderCommandHandler(
    IApplicationDbContext context,
    IDateTimeProvider dateTimeProvider,
    IUserContext userContext)
    : ICommandHandler<CreateOrderCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        if (userContext.UserId != command.UserId)
        {
            return Result.Failure<Guid>(UserErrors.Unauthorized());
        }

        User? user = await context.Users.AsNoTracking()
            .SingleOrDefaultAsync(u => u.Id == command.UserId, cancellationToken);

        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound(command.UserId));
        }

        var productIds = command.Items.Select(item => item.ProductId).ToList();
        var products = await context.Products
            .Where(p => productIds.Contains(p.Id))
            .ToListAsync(cancellationToken);

        if (products.Count != command.Items.Count)
        {
            return Result.Failure<Guid>(ProductErrors.InvalidQuantity);
        }

        var orderItems = new List<OrderItem>();

        foreach (var item in command.Items)
        {
            var product = products.First(p => p.Id == item.ProductId);

            if (product.Quantity < item.Quantity)
            {
                return Result.Failure<Guid>(ProductErrors.InvalidQuantity);
            }

            orderItems.Add(new OrderItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = product.Price,
            });

            product.Quantity -= item.Quantity;
        }

        var order = new Order
        {
            UserId = user.Id,
            Items = orderItems,
            CreatedAt = dateTimeProvider.UtcNow,
        };

        order.Raise(new OrderCreatedDomainEvent(order.Id));

        context.Orders.Add(order);

        await context.SaveChangesAsync(cancellationToken);

        return order.Id;
    }
}
