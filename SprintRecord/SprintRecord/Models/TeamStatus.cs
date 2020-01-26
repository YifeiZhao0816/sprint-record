using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SprintRecord.Models
{
    public class TeamStatus
    {
        public TeamStatus(Teams team, int averageVelocity, int totalSprint)
        {
            this.team = team;
            AverageVelocity = averageVelocity;
            SprintCounts = totalSprint;
        }

        public Teams team { get; set; }
        public int AverageVelocity { get; set; }
        public int SprintCounts { get; set; }

    }
}
