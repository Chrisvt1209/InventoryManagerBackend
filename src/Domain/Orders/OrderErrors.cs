using SharedKernel;

namespace Domain.Orders;

public static class OrderErrors
{
    public static Error NotFound(Guid orderId) => Error.NotFound(
        "Orders.NotFound",
        $"The order with id {orderId} was not found.");
}
