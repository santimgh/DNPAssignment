﻿using System.Net.Http.Json;
using System.Text.Json;
using Httplients.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace Httplients.Implementations;

public class UserHttpClient : IUserService
{
    private readonly HttpClient client;

    public UserHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<User> Create(UserCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/users", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        User user = JsonSerializer.Deserialize<User>(result)!;
        return user;
    }
}