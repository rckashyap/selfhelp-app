using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Business.Entities
{
    public sealed class ChallengeEntity : BaseEntity
    {
        public int CreatedByUser { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public int DurationInDays { get; set; } = 7;

        public List<ChallengeStepEntity> Steps { get; set; }
    }
}
