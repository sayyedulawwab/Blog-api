using Blog.Application.Abstractions.Auth;
using Blog.Application.Abstractions.Messaging;
using Blog.Domain.Abstractions;
using Blog.Domain.Users;

namespace Blog.Application.Users.Register;
internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandler(IAuthService authService, IUserRepository userRepository)
    {
        _authService = authService;
        _userRepository = userRepository;
    }
    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var existingUserByEmail = await _userRepository.GetByEmail(request.email);

        if (existingUserByEmail is not null)
        {
            return Result.Failure<Guid>(UserErrors.AlreadyExists);
        }

        var passwordSalt = _authService.GenerateSalt();
        var hashedPassword = _authService.HashPassword(request.password, passwordSalt);

        var user = User.Create(request.firstName,request.lastName,request.email, hashedPassword, passwordSalt, false);

        await _userRepository.AddAsync(user);

        return user.Id.Value;
    }
}
