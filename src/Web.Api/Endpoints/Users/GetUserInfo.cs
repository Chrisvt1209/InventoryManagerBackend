using Application.Abstractions.Authentication;
using Application.Users;
using Application.Users.GetById;
using MediatR;
using Serilog;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Users;

internal sealed class GetLoggedInUser : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("users/me", async (IUserContext userContext, ISender sender, CancellationToken cancellationToken) =>
        {
            try
            {
                Guid userId = userContext.UserId;

                var query = new GetUserByIdQuery(userId);

                Result<UserResponse> result = await sender.Send(query, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error getting user info");
                return Results.Problem("An unexpected error occurred", statusCode: StatusCodes.Status500InternalServerError);
            }

        })
        .RequireAuthorization()
        .WithTags(Tags.Users);
    }
}
