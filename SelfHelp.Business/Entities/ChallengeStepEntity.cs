using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Business.Entities
{
    public class ChallengeStepEntity : BaseEntity
    {
        public int ChallengeId { get; set; }

        public int DayNumber { get; set; }

        public string Description { get; set; }
    }
}
