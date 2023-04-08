using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FrontEnd;
using Httplients.ClientInterfaces;
using Httplients.Implementations;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(
    sp => 
        new HttpClient { 
            BaseAddress = new Uri("https://localhost:7093") 
        }
);
builder.Services.AddScoped<IUserService, UserHttpClient>();
builder.Services.AddScoped<IPostsService, PostHttpClient>();

await builder.Build().RunAsync();
