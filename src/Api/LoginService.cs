using Api.Interfaces;
using Api.Models;

namespace Api;

public class LoginService : ILoginService
{
    private const string Token = "600E74C5-976C-47E6-8589-E3FD9D118095";
    
    public string? Login(LoginRequest loginRequest)
    {
        // check if the username and password is acceptable,
        return Token;
    }

    public bool IsValidToken(string authorization)
    {
        return authorization == Token;
    }
}