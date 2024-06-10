namespace Blog.API.Controllers.Posts;

public record CreatePostRequest(string title, string content, Guid authorId);
