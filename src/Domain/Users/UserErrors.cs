﻿using SharedKernel;

namespace Domain.Users;

public static class UserErrors
{
    public static Error NotFound(Guid userId)
    {
        return Error.NotFound("Users.NotFound", $"The user with id '{userId}' was not found.");
    }

    public static Error Unauthorized()
    {
        return Error.Failure("Users.Unauthorized", "You are not authorized to perform this action.");
    }

    public static readonly Error NotFoundByEmail = Error.NotFound("Users.NotFoundByEmail", "The user with the provided email was not found.");

    public static readonly Error EmailNotUnique = Error.Conflict("Users.EmailNotUnique", "The provided email is already in use.");
}
