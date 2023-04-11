using Application.Logic;
using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostsLogic PostsLogic;

    public PostsController(IPostsLogic postsLogic)
    {
        PostsLogic = postsLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync([FromBody] PostCreationDto dto)
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

    [HttpGet("postid={postId}")]
    public async Task<ActionResult<IEnumerable<Post>>> GetUserById(int postId)
    {
        try
        {
            var posts = await PostsLogic.GetPostByIdAsync(postId);
            return Ok(posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}