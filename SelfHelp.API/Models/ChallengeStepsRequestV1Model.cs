namespace SelfHelp.API.Models
{
    public class ChallengeStepsRequestV1Model
    {
        /// <summary>
        /// The challenge identifier to which the steps will be added for.
        /// </summary>
        /// <example>3</example>
        public int ChallengeId { get; set; }

        /// <summary>
        /// List of steps in the challenge.
        /// </summary>
        public List<ChallengeStepRequestV1Model> Steps { get; set; }
    }
}
