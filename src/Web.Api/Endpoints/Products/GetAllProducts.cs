using Application.Products;
using Application.Products.GetAllProducts;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Products;

internal class GetAllProducts : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (string? searchTerm, ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetAllProductsQuery(searchTerm);

            Result<List<ProductResponse>> result = await sender.Send(query, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Products);
    }
}
