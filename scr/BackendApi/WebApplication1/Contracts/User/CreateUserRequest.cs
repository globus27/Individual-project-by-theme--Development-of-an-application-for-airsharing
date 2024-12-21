namespace WebApplication1.Contracts.User
{
    public class CreateUserRequest
    {
        public string Login { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int IdPassport { get; set; }
    }
}
