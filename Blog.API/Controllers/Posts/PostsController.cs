using Blog.Application.Posts.CreatePost;
using Blog.Application.Posts.DeletePost;
using Blog.Application.Posts.EditPost;
using Blog.Application.Posts.GetPosts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.Posts;
[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly ISender _sender;
    public PostsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetPosts(CancellationToken cancellationToken)
    {
        var query = new GetPostsQuery();

        var result = await _sender.Send(query, cancellationToken);

        return Ok(result.Value);
    }


    [HttpPost]
    public async Task<IActionResult> CreatePost(CreatePostRequest request, CancellationToken cancellationToken)
    {
        var command = new CreatePostCommand(request.title, request.content, request.authorId);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditPost(Guid id, EditPostRequest request, CancellationToken cancellationToken)
    {
        var command = new EditPostCommand(id, request.title, request.content);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(new { id = result.Value });
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeletePostCommand(id);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(new { id = result.Value });
    }


}
