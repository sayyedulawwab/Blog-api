using Blog.Application.Abstractions.Clock;
using Blog.Application.Abstractions.Messaging;
using Blog.Domain.Abstractions;
using Blog.Domain.Posts;

namespace Blog.Application.Posts.EditPost;
internal sealed class EditPostCommandHandler : ICommandHandler<EditPostCommand, Guid>
{
    private readonly IPostRepository _postRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public EditPostCommandHandler(IPostRepository postRepository, IDateTimeProvider dateTimeProvider)
    {
        _postRepository = postRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result<Guid>> Handle(EditPostCommand request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(new PostId(request.id));

        if (post is null)
        {
            return Result.Failure<Guid>(PostErrors.NotFound);
        }

        post = Post.Update(post, request.title, request.content, _dateTimeProvider.UtcNow);

        await _postRepository.UpdateAsync(new PostId(request.id), post, cancellationToken);

        return post.Id.Value;
    }
}
