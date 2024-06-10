using Blog.Application.Abstractions.Clock;
using Blog.Application.Abstractions.Messaging;
using Blog.Domain.Abstractions;
using Blog.Domain.Posts;
using Blog.Domain.Users;

namespace Blog.Application.Posts.CreatePost;
internal sealed class CreatePostCommandHandler : ICommandHandler<CreatePostCommand, Guid>
{
    private readonly IPostRepository _postRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    public CreatePostCommandHandler(IPostRepository postRepository, IDateTimeProvider dateTimeProvider)
    {
        _postRepository = postRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result<Guid>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = Post.Create(request.title, request.content, new UserId(request.authorId), _dateTimeProvider.UtcNow);

        await _postRepository.AddAsync(post, cancellationToken);

        return post.Id.Value;
    }
}
