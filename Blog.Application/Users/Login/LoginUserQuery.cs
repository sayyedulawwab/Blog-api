using Blog.Application.Abstractions.Messaging;

namespace Blog.Application.Users.Login;

public record LoginUserQuery(string email, string password) : IQuery<AccessTokenResponse>;