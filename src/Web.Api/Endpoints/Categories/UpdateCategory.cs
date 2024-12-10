
using Application.Categories.UpdateCategory;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Categories;

internal sealed class UpdateCategory : IEndpoint
{
    public sealed record Request(string Name);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("categories/{id:guid}", async (Guid id, Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new UpdateCategoryCommand(id, request.Name);

            Result result = await sender.Send(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.Categories);
        //.RequireAuthorization();
    }
}
