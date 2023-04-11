using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Httplients.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace Httplients.Implementations;

public class PostHttpClient : IPostsService
{
    private readonly HttpClient client;

    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task CreateAsync(PostCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/posts", dto);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }


    public async Task<ICollection<Post>> GetAsync(string? title, int? userId, int? postId, string? body)
    {
        //string querry = ConstructQuery(title, userId, postId, body);
        string querry;
        if (postId == null)
        {
            querry = "";
        }
        else
        {
            querry = $"/postid={postId}";
        }

        HttpResponseMessage response = await client.GetAsync("/posts" + querry);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }

    public int id { get; set; }


    private static string ConstructQuery(string? title, int? userId, int? postId, string? body)
    {
        string query = "";
        if (!string.IsNullOrEmpty(title))
        {
            query += $"?posttitle={title}";
        }

        if (userId != null)
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"?userid={userId}";
        }

        if (postId != null)
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"?postid={postId}";
        }

        if (!string.IsNullOrEmpty(body))
        {
            query += $"?body={body}";
        }

        return query;
    }
}