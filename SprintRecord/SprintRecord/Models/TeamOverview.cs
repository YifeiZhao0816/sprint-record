using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SprintRecord.Models
{
    public class TeamOverview
    {
        public TeamOverview(Teams team, List<Developers> developers, List<TeamSprint> teamSprints, 
            List<Sprints> sprints, int averageVelocity, int averageCarryOver, 
            int averageCommitment, int averagePtsAdded, int totalSprint)
        {
            this.Team = team;
            AverageVelocity = averageVelocity;
            SprintCounts = totalSprint;
            Developers = developers;
            TeamSprints = teamSprints;
            Sprints = sprints;
            AverageCarryOver = averageCarryOver;
            AverageCommitment = averageCommitment;
            AveragePtsAdded = averagePtsAdded;
        }

        public TeamOverview(Teams team, List<Developers> developers, List<TeamSprint> teamSprints,
            List<Sprints> sprints)
        {
            this.Team = team;
            Developers = developers;
            TeamSprints = teamSprints;
            Sprints = sprints;
            AverageVelocity = 0;
            SprintCounts = 0;
            AverageCarryOver = 0;
            AverageCommitment = 0;
            AveragePtsAdded = 0;
        }

        public TeamOverview(Teams team, TeamSprint teamSprint, 
            int averageVelocity, int totalSprint)
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
        public int AverageCarryOver { get; set; }
        public int AverageCommitment { get; set; }
        public int AveragePtsAdded { get; set; }
        public int SprintCounts { get; set; }
    }
}
