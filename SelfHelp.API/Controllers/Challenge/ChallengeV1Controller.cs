using Microsoft.AspNetCore.Mvc;
using SelfHelp.API.Models;
using SelfHelp.Business.Abstraction;
using SelfHelp.Business.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace SelfHelp.API.Controllers.Challenge
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("/app/challenge")]
    public class ChallengeV1Controller : BaseController
    {
        private readonly IChallengeService challengeService;

        public ChallengeV1Controller(IChallengeService challengeService)
        {
            this.challengeService = challengeService;
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.Created, "ChallengeResponseV1Model", typeof(ChallengeResponseV1Model))]
        public async Task<IActionResult> CreateChallenge(
            [FromBody] ChallengeRequestV1Model challengeV1Model)
        {
            var error = this.ValidateChallenge(challengeV1Model);
            if (!string.IsNullOrEmpty(error))
            {
                this.GetActionResult(HttpStatusCode.BadRequest, error);
            }

            var challenge = new ChallengeEntity
            {
                Title = challengeV1Model.Title,
                CreatedByUser = challengeV1Model.CreatedByUserId,
                Description = challengeV1Model.Description,
                DurationInDays = challengeV1Model.DurationInDays,
                StartDate = challengeV1Model.StartDate,
            };

            var result = await this.challengeService.CreateChallenge(challenge).ConfigureAwait(true);

            return this.GetActionResult(HttpStatusCode.Created, new ChallengeResponseV1Model(result));
        }

        [HttpPost]
        [Route("steps")]
        [SwaggerResponse((int)HttpStatusCode.Created, "ChallengeResponseV1Model", typeof(ChallengeResponseV1Model))]
        public async Task<IActionResult> CreateChallengeSteps(
            [FromBody] ChallengeStepsRequestV1Model challengeDetails)
        {
            if (challengeDetails.ChallengeId <= 0 || challengeDetails.Steps.Any(title => string.IsNullOrEmpty(title.Description)))
            {
                return this.GetActionResult(HttpStatusCode.BadRequest, $"Challenge Id is invalid or one of the steps is missing description");
            }

            var stepsToAdd = challengeDetails.Steps.Select(item =>
                new ChallengeStepEntity
                {
                    ChallengeId = challengeDetails.ChallengeId,
                    Description = item.Description,
                    DayNumber = item.DayNumber
                }).ToList();

            var result = await this.challengeService.CreateStepsForChallenge(stepsToAdd).ConfigureAwait(true);

            return this.GetActionResult(HttpStatusCode.Created, new ChallengeResponseV1Model(result));
        }

        [HttpGet]
        [Route("{userId}/list")]
        [SwaggerResponse((int)HttpStatusCode.OK, "UserChallengeListV1ResponseModel", typeof(UserChallengeListV1ResponseModel))]
        public IActionResult CreateChallengesList(
            [FromRoute] int userId,
            [FromQuery] string? searchText)
        {
            var result = this.challengeService.SearchChallenge(userId, searchText);

            return this.GetActionResult(HttpStatusCode.OK, new UserChallengeListV1ResponseModel(result));
        }

        private string ValidateChallenge(ChallengeRequestV1Model challenge)
        {
            string error = string.Empty;
            if (challenge.CreatedByUserId <= 0)
            {
                error = "Challenge CreatedBy should not be empty.";
            }
            else if (string.IsNullOrEmpty(challenge.Title))
            {
                error = "Challenge Title should not be empty.";
            }

            return error;
        }
    }
}
