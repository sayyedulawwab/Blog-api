using Blog.Domain.Abstractions;

namespace Blog.Application.Abstractions.Auth;
public interface IJwtService
{
    Result<string> GetAccessToken(string email, Guid userId, CancellationToken cancellationToken = default);
}
