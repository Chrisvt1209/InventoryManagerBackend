using Application.Products.UpdateProduct;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Products;

internal sealed class UpdateProduct : IEndpoint
{
    public sealed record Request(string Name, string Description, decimal Price, int Quantity);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("products/{id:guid}", async (Guid id, Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new UpdateProductCommand(id, request.Name, request.Description, request.Price, request.Quantity);

            Result result = await sender.Send(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.Products)
        .RequireAuthorization();
    }
}