using Application.Logic;
using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
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
    public async Task<ActionResult<Post>> CreateAsync([FromBody]PostCreationDto dto)
    {
        try
        {
            Post postCreated = await PostsLogic.Create(dto);
            return Created($"/post/{postCreated.postId}", postCreated);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(403, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetAllAsync()
    {
        try
        {
            var posts = await PostsLogic.GetAllAsync();
            return Ok(posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}