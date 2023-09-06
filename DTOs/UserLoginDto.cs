namespace AuthApi.DTOs;

public sealed class UserLoginDto
{
    public required string Email {get; set;} = string.Empty;
    public required string Password {get; set;} = string.Empty;
}
