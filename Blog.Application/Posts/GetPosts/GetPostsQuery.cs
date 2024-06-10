using Blog.Application.Abstractions.Messaging;

namespace Blog.Application.Posts.GetPosts;
public record GetPostsQuery() : IQuery<IReadOnlyList<PostResponse>>;
