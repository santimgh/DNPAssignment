using System.Security.Claims;
using FrontEnd.Services.Http;
using Microsoft.AspNetCore.Components.Authorization;

namespace FrontEnd.Auth;

public class CustomAuthProvider : AuthenticationStateProvider
{
    private readonly IAuthService authService;

    public CustomAuthProvider(IAuthService authService)
    {
        this.authService = authService;
        authService.OnAuthStateChanged += AuthStateChanged;
    }

    private void AuthStateChanged(ClaimsPrincipal obj)
    {
        NotifyAuthenticationStateChanged(
            Task.FromResult(new AuthenticationState(obj)));
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsPrincipal principal = await authService.GetAuthAsync();
        return new AuthenticationState(principal);
    }
}