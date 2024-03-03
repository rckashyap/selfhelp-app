namespace SelfHelp.API.Models
{
    public class ChallengeRequestV1Model
    {
        /// <summary>
        /// The user identifier who is creating the challenge.
        /// </summary>
        /// <example>3</example>
        public required int CreatedByUserId { get; set; }

        /// <summary>
        /// Title of the challenge.
        /// </summary>
        /// <example>Keyboard challenge</example>
        public required string Title { get; set; }

        /// <summary>
        /// A breif description of the challenge.
        /// </summary>
        /// <example>Learn to type 250 words per min in 5 days</example>
        public string? Description { get; set; }

        /// <summary>
        /// Start date of the challenge.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Number of days required to complete the challenge.
        /// </summary>
        /// <example>5</example>
        public int DurationInDays { get; set; } = 7;
    }
}
