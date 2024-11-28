using Application.Products.CreateProduct;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Products;

internal sealed class CreateProduct : IEndpoint
{
    public sealed record Request(string Name, string Description, decimal Price, int Quantity, Guid CategoryId);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("products/create", async (Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new CreateProductCommand(
                request.Name,
                request.Description,
                request.Price,
                request.Quantity,
                request.CategoryId);

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Products);
    }
}