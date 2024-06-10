using Blog.Application.Abstractions.Messaging;
using Blog.Domain.Abstractions;
using Blog.Domain.Posts;

namespace Blog.Application.Posts.DeletePost;
internal sealed class DeletePostCommandHandler : ICommandHandler<DeletePostCommand, Guid>
{
    private readonly IPostRepository _postRepository;
    public DeletePostCommandHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Result<Guid>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(new PostId(request.id));

        _postRepository.RemoveAsync(new PostId(request.id), cancellationToken);

        return post.Id.Value;
    }
}
