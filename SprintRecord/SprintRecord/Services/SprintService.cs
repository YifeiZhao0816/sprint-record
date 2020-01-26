using SprintRecord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SprintRecord.Services
{
    public class SprintService
    {
        public SprintContext Context { get; set; }


        public SprintService(SprintContext context) 
        {
            Context = context;
        }

        public List<TeamStatus> GetActiveTeamStatuses()
        {
            List<TeamStatus> list = new List<TeamStatus>();
            List<Teams> teams = Context.Teams.ToList();
            foreach (TeamSprint record in Context.TeamSprint)
            {
                Teams targetTeam = teams.Single(x => x.Id == record.Teamid);
                if (!TeamExistInList(record.Teamid, list))
                {
                    list.Add(new TeamStatus(targetTeam, record.Completed, 1));
                }
                else
                {
                    list.Find(x => x.team == targetTeam).SprintCounts++;
                    list.Find(x => x.team == targetTeam).AverageVelocity += record.Completed;
                }
            }
            foreach (TeamStatus status in list)
            {
                status.AverageVelocity /= status.SprintCounts;
            }
            return list;
        }

        private bool TeamExistInList(int TeamId, List<TeamStatus> list)
        {
            return list.Exists(x => x.team.Id == TeamId);
        }

        public List<Sprints> GetSprints(int teamId)
        {
            List<Sprints> sprints = Context.Sprints.ToList();
            List<TeamSprint> TeamSprints = Context.TeamSprint.ToList().FindAll(ts => ts.Teamid == teamId);
            List<Sprints> list = sprints.FindAll(s => TeamSprints.Exists(ts => ts.Sprintid == s.Id));
            list = list.OrderBy(x => x.Name).ToList();
            return list;
        }

        public List<Developers> GetTeamDevelopers(int teamId)
        {
            List<TeamDeveloper> teamDeveloperRecords = Context.TeamDeveloper.ToList();
            return Context.Developers.ToList().FindAll(d => teamDeveloperRecords.Exists(td => td.Teamid == teamId && td.Developerid == d.Id));
        }
    }
}
