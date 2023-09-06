namespace AuthApi.Models;

public sealed class User
{
    public int Id {get; set;}
    public string? Fullname {get; set;} = string.Empty;
    public string? Email {get; set;} = string.Empty;
    public byte[] PasswordHash {get; set;} = default!;
    public byte[] PasswordSalt {get; set;} = default!;
}
