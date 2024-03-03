using SelfHelp.Business.Entities;

namespace SelfHelp.API.Models
{
    public class UserChallengeListV1ResponseModel
    {
        public List<ChallengeResponseV1Model> Challenges { get; set; } = new List<ChallengeResponseV1Model>();

        public UserChallengeListV1ResponseModel()
        {
        }

        public UserChallengeListV1ResponseModel(List<ChallengeEntity> challenges)
        {
            foreach (var item in challenges)
            {
                this.Challenges.Add(new ChallengeResponseV1Model(item));
            }
        }
    }
}
