using SelfHelp.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Business.Abstraction
{
    public interface IChallengeService
    {
        Task<ChallengeEntity> CreateChallenge(ChallengeEntity challenge);

        Task<ChallengeEntity> CreateStepsForChallenge(List<ChallengeStepEntity> steps);

        List<ChallengeEntity> SearchChallenge(int userId, string searchText);

        Task UpdateChallengeProgress();

        Task JoinChallenge();  
    }
}
