using SelfHelp.Business.Abstraction;
using SelfHelp.Business.Entities;
using SelfHelp.PostgreSql;
using SelfHelp.PostgreSql.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Business.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly AppDbContext context;

        public ChallengeService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<ChallengeEntity> CreateChallenge(ChallengeEntity challenge)
        {
            var challengeToAdd = new Challenge
            {
                Title = challenge.Title,
                StartDate = challenge.StartDate,
                Description = challenge.Description,
                Duration = challenge.DurationInDays,
                CreatedOn = DateTime.UtcNow,
                UserId = challenge.CreatedByUser,
            };

            await this.context.AddAsync(challengeToAdd).ConfigureAwait(false);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            var addedChallenge = this.context.Challenges.Single(id => id.Id == challengeToAdd.Id);

            return new ChallengeEntity
            {
                Id = challengeToAdd.Id,
                Title = addedChallenge.Title,
                Description = addedChallenge.Description,
                DurationInDays = addedChallenge.Duration,
                StartDate = addedChallenge.StartDate,
                CreatedByUser = addedChallenge.UserId,
                CreatedOn = addedChallenge.CreatedOn,
                ModifiedOn = addedChallenge.ModifiedOn,
            };
        }

        public async Task<ChallengeEntity> CreateStepsForChallenge(List<ChallengeStepEntity> steps)
        {
            var stepsToAdd = steps.Select(step => new ChallengeStep
            {
                ChallengeId = step.ChallengeId,
                Description = step.Description,
                DayNumber = step.DayNumber,
                CreatedOn = DateTime.UtcNow
            });

            await this.context.AddRangeAsync(stepsToAdd).ConfigureAwait(false);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            var challengeAddedWithSteps = this.context.Challenges.Single(id => id.Id == steps.First().ChallengeId);
            var challengeSteps = this.context.ChallengeSteps.Where(id => id.ChallengeId == steps.First().ChallengeId);

            return new ChallengeEntity
            {
                Id = challengeAddedWithSteps.Id,
                CreatedByUser = challengeAddedWithSteps.UserId,
                Description = challengeAddedWithSteps.Description,
                DurationInDays = challengeAddedWithSteps.Duration,
                Title = challengeAddedWithSteps.Title,
                StartDate = challengeAddedWithSteps.StartDate,
                CreatedOn = challengeAddedWithSteps.CreatedOn,
                ModifiedOn = challengeAddedWithSteps.ModifiedOn,
                Steps = challengeSteps.Select(x => new ChallengeStepEntity
                {
                    ChallengeId = x.ChallengeId,
                    DayNumber = x.DayNumber,
                    Description = x.Description,
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn,
                }).ToList(),
            };
        }

        public Task JoinChallenge()
        {
            throw new NotImplementedException();
        }

        public List<ChallengeEntity> SearchChallenge(int userId, string searchText)
        {
            var userChallenges = this.context.Challenges.Where(challenge => challenge.UserId == userId).ToList();

            if (!string.IsNullOrEmpty(searchText))
            {
                userChallenges  = userChallenges.Where(userChallenges => 
                    userChallenges.Title.Contains(searchText) ||
                    (userChallenges.Description != null && userChallenges.Description.Contains(searchText))
                ).ToList();
            }

            var response = new List<ChallengeEntity>();

            foreach (var challenge in userChallenges)
            {
                var steps = this.context.ChallengeSteps.Where(steps => steps.ChallengeId == challenge.Id).ToList();

                response.Add(new ChallengeEntity
                {
                    Id = challenge.Id,
                    CreatedByUser = challenge.UserId,
                    Description = challenge.Description,
                    Title = challenge.Title,
                    CreatedOn = challenge.CreatedOn,
                    DurationInDays = challenge.Duration,
                    StartDate = challenge.StartDate,
                    ModifiedOn = challenge.ModifiedOn,
                    Steps = steps.Select(inStep => new ChallengeStepEntity
                    {
                        ChallengeId = inStep.ChallengeId,
                        DayNumber = inStep.DayNumber,
                        Description = inStep.Description,
                        Id = inStep.Id,
                        CreatedOn = inStep.CreatedOn,
                        ModifiedOn = inStep.ModifiedOn,
                    }).ToList(),
                });
            }

            return response;
        }

        public Task UpdateChallengeProgress()
        {
            throw new NotImplementedException();
        }
    }
}
