namespace SelfHelp.API.Models
{
    public class ChallengeStepRequestV1Model
    {
        /// <summary>
        /// A number corresponding to each day of the challenge.
        /// Describe which day to perform a certain task.
        /// </summary>
        /// <example>1</example>
        public int DayNumber { get; set; }

        /// <summary>
        /// Detailed description of the goal/challenge to be achieved on the specified day.
        /// </summary>
        /// <example>Type 100 words per min.</example>
        public string Description { get; set; }
    }
}
