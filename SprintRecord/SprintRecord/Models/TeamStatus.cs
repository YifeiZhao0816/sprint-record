using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SprintRecord.Models
{
    public class TeamStatus
    {
        public TeamStatus(Teams team, int averageVelocity, int totalSprint,
            List<Developers> developers, List<TeamSprint> teamSprints, List<Sprints> sprints)
        {
            this.Team = team;
            AverageVelocity = averageVelocity;
            SprintCounts = totalSprint;
            Developers = developers;
            TeamSprints = teamSprints;
            Sprints = sprints;
        }

        public TeamStatus(Teams team, int averageVelocity, int totalSprint,
            TeamSprint teamSprint)
        {
            Team = team;
            AverageVelocity = averageVelocity;
            SprintCounts = totalSprint;
            TeamSprints = new List<TeamSprint> { teamSprint };
        }

        public Teams Team { get; set; }
        public List<Developers> Developers { get; set; }
        public List<TeamSprint> TeamSprints { get; set; }
        public List<Sprints> Sprints { get; set; }
        public int AverageVelocity { get; set; }
        public int SprintCounts { get; set; }

    }
}
