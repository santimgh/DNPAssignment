
using System.Text.Json;
using Shared.Models;

namespace FileData;

public class FileContext
{
    private const string filePath = "data.json";
    private DataContainer? DataContainer;

    public ICollection<User> Users
    {
        get
        {
            LoadData();
            return DataContainer!.Users;
        }
    }

    public ICollection<Post> Posts
    {
        get
        {
            LoadData();
            return DataContainer!.Posts;
        }
    }

    private void LoadData()
    {
        if(DataContainer != null) return;
        
        if(!File.Exists(filePath))
        {
            DataContainer = new()
            {
                Users = new List<User>(),
                Posts = new List<Post>()
            };
            return;
        }

        string content = File.ReadAllText(filePath);
        DataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }

    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(DataContainer, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(filePath, serialized);
        DataContainer = null;

    }
    
}