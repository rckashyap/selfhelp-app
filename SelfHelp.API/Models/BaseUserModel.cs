namespace SelfHelp.API.Models
{
    public class BaseUserModel
    {
        public required string UserName { get; set; }

        public required string Password { get; set; }

        public required string Email { get; set; }
    }
}
