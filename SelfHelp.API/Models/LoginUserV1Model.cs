using SelfHelp.API.Enums;

namespace SelfHelp.API.Models
{
    public class LoginUserV1Model : BaseUserModel
    {
        /// <example>John</example>
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public Gender Gender { get; set; } = Gender.Unknown;

        public int Age { get; set; }
    }
}
