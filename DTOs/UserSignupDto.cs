namespace AuthApi.DTOs;

public sealed class UserSignupDto
{
    public required string Fullname {get; set;} = string.Empty;
    public required string Email { get; set; } = string.Empty;
    public required string Password { get; set; } = string.Empty;
}
