using Blog.Domain.Abstractions;
using MediatR;

namespace Blog.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}