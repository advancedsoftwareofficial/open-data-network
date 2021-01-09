namespace NETBoilerplate.Shared
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Token { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
