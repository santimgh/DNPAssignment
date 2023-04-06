using Application.Logic;
using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsControllers : ControllerBase
{
    private readonly IPostsLogic PostsLogic;

    public PostsControllers(IPostsLogic postsLogic)
    {
        PostsLogic = postsLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync(Post post, [FromRoute]User user)
    {
        try
        {
            Post postCreated = await PostsLogic.Create(post, user);
            return Created($"/posts/{post.Owner}", post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}