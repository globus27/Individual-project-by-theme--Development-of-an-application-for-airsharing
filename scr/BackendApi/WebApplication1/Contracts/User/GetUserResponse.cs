namespace WebApplication1.Contracts.User
{
    public class GetUserResponse
    {
        public int IdUser { get; set; }
        public string Login { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int IdPassport { get; set; }
    }
}
