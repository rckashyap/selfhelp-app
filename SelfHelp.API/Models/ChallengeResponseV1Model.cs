using SelfHelp.Business.Entities;

namespace SelfHelp.API.Models
{
    public class ChallengeResponseV1Model : BaseResponseV1Model
    {
        public int ChallengeId { get; set; }

        public int CreatedByUserId { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public int DurationInDays { get; set; }

        public List<ChallengeStepResponseV1Model>? Steps { get; set; }

        public ChallengeResponseV1Model()
        {
        }

        public ChallengeResponseV1Model(ChallengeEntity challenge)
        {
            this.ChallengeId = challenge.Id;
            this.CreatedByUserId = challenge.CreatedByUser;
            this.Title = challenge.Title;
            this.Description = challenge.Description;
            this.StartDate = challenge.StartDate;
            this.DurationInDays = challenge.DurationInDays;
            this.CreatedOn = challenge.CreatedOn; 
            this.ModifiedOn = challenge.ModifiedOn;
            this.Steps = challenge.Steps?.Select(x => new ChallengeStepResponseV1Model
            {
                StepId = x.Id,
                Description = x.Description,
                DayNumber = x.DayNumber,
                CreatedOn = x.CreatedOn,
                ModifiedOn = x.ModifiedOn,
            }).ToList();
        }
    }
}
