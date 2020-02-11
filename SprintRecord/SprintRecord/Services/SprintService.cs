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

        public List<TeamOverview> GetActiveTeamStatuses()
        {
            List<TeamOverview> list = new List<TeamOverview>();
            List<Teams> teams = Context.Teams.ToList();
            foreach (TeamSprint record in Context.TeamSprint)
            {
                Teams targetTeam = teams.Single(x => x.Id == record.Teamid);
                if (!TeamExistInList(record.Teamid, list))
                {
                    list.Add(new TeamOverview(targetTeam, record, record.Completed, 1));
                }
                else
                {
                    list.Find(x => x.Team == targetTeam).SprintCounts++;
                    list.Find(x => x.Team == targetTeam).AverageVelocity += record.Completed;
                    list.Find(x => x.Team == targetTeam).TeamSprints.Add(record);
                }
            }
            foreach (TeamOverview status in list)
            {
                status.AverageVelocity /= status.SprintCounts;
                status.Developers = GetTeamDevelopers(status.Team.Id);
            }
            return list;
        }

        public TeamOverview GetTeamOverview(int teamId)
        {
            List<TeamSprint> teamSprintsRecords = Context.TeamSprint.ToList().FindAll(x => x.Teamid == teamId);
            List<Sprints> sprintslist = GetSprints(teamId);
            List<Developers> developers = GetTeamDevelopers(teamId);
            Teams team = Context.Teams.Find(teamId);
            TeamOverview resultTeam = new TeamOverview(team, developers, teamSprintsRecords, sprintslist);
            resultTeam.SprintCounts = teamSprintsRecords.Count;
            if (resultTeam.SprintCounts == 0)
            {
                return resultTeam;
            }
            foreach (var item in teamSprintsRecords)
            {
                resultTeam.AverageVelocity += item.Completed;
                resultTeam.AveragePtsAdded += item.Pointsadded;
                resultTeam.AverageCommitment += item.Commitment;
                resultTeam.AverageCarryOver += item.Carryover;
            }
            resultTeam.AverageVelocity /= resultTeam.SprintCounts;
            resultTeam.AveragePtsAdded /= resultTeam.SprintCounts;
            resultTeam.AverageCommitment /= resultTeam.SprintCounts;
            resultTeam.AverageCarryOver /= resultTeam.SprintCounts;
            return resultTeam;
        }

        private bool TeamExistInList(int TeamId, List<TeamOverview> list)
        {
            return list.Exists(x => x.Team.Id == TeamId);
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
            List<TeamDeveloper> teamDeveloperRecords = Context.TeamDeveloper.ToList().FindAll(td => td.Teamid == teamId);
            return Context.Developers.ToList().FindAll(d => teamDeveloperRecords.Exists(td => td.Developerid == d.Id));
        }

        public void DeleteTeam(int Id)
        {
            var team = Context.Teams.Find(Id);
            var teamDevList = Context.TeamDeveloper.ToList().FindAll(r => r.Teamid == Id);
            var teamSprintList = Context.TeamSprint.ToList().FindAll(r => r.Teamid == Id);
            Context.Teams.Remove(team);
            foreach (var dev in teamDevList)
            {
                Context.TeamDeveloper.Remove(dev);
            }
            foreach (var teamSprintRecord in teamSprintList)
            {
                Context.TeamSprint.Remove(teamSprintRecord);
            }
            Context.SaveChanges();
        }
    }
}
