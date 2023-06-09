﻿namespace Shared.Models;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public int SecurityLevel { get; set; }
    public ICollection<Post> Posts { get; set; }

}