namespace SelfHelp.API.Models
{
    public class ChallengeStepResponseV1Model : BaseResponseV1Model
    {
        public int StepId { get; set; }

        public int DayNumber { get; set; }

        public string Description { get; set; }
    }
}
