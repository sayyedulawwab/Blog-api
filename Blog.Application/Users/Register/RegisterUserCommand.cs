using Blog.Application.Abstractions.Messaging;

namespace Blog.Application.Users.Register;

public record RegisterUserCommand(string firstName, string lastName, string email, string password) : ICommand<Guid>;
