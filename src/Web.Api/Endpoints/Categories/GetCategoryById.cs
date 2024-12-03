
using Application.Categories;
using Application.Categories.GetCategoryById;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Categories;

internal sealed class GetCategoryById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("categories/{categoryId}", async (Guid categoryId, ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetCategoryByIdQuery(categoryId);

            Result<CategoryResponse> result = await sender.Send(query, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Categories);
    }
}
