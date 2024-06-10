using Blog.Application.Abstractions.Messaging;
using Blog.Domain.Abstractions;
using Blog.Domain.Posts;

namespace Blog.Application.Posts.GetPosts;
internal sealed class GetPostsQueryHandler : IQueryHandler<GetPostsQuery, IReadOnlyList<PostResponse>>
{
    private readonly IPostRepository _postRepository;
    public GetPostsQueryHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Result<IReadOnlyList<PostResponse>>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        var posts = await _postRepository.GetAllAsync(cancellationToken);

        var postList = posts.Select(post => new PostResponse 
        { 
            Id = post.Id.Value,
            Title = post.Title,
            Content = post.Content,
            CreatedOn = post.CreatedOn
            
        });

        return postList.ToList();
    }
}
