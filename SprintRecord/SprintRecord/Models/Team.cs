using System.Collections.Generic;

namespace SprintRecord.Models
{
    public class Team
    {
        public List<Developer> Developers { get; set; }

        public string Name { get; set; }
        public int AvgVelocity { get; set; }
        public int TotalWorkHrs { get; set; }
        public int TotalSprintHrs { get; set; }
        public int SprintPercent { get; set; }
        public List<MemberStatus> MemberStatusList { get; set; } // <string name, int[2]{workHrs, sprintHrs}>
        public List<SprintWeek> Sprints { get; set; }

        public Team(string name, IEnumerable<string> members)
        {
            AvgVelocity = int.MinValue;
            TotalWorkHrs = int.MinValue;
            TotalSprintHrs = int.MinValue;
            SprintPercent = int.MinValue;
            Name = name;
            Sprints = new List<SprintWeek>();
            MemberStatusList = new List<MemberStatus>();
            foreach (var member in members)
            {
                MemberStatusList.Add(new MemberStatus { Name = member, WorkHours = int.MinValue, SprintHours = int.MinValue});
            }
        }

        public Team()
        {
            Name = "";
            AvgVelocity = int.MinValue;
            TotalWorkHrs = int.MinValue;
            TotalSprintHrs = int.MinValue;
            SprintPercent = int.MinValue;
            Sprints = new List<SprintWeek>();
            MemberStatusList = new List<MemberStatus>();
        }

        public void UpdateSprintWeek(List<MemberStatus> memberCapacity,
                                     int carryOver,
                                     int commitment,
                                     int ptsAdded,
                                     int completed,
                                     int year,
                                     int period)
        {
            MemberStatusList = memberCapacity;
            TotalWorkHrs = 0;
            TotalSprintHrs = 0;
            foreach (var member in MemberStatusList)
            {
                TotalWorkHrs += member.WorkHours;
                TotalSprintHrs += member.SprintHours;
            }

            Sprints.Add(new SprintWeek(year, period, carryOver, commitment, ptsAdded, completed, TotalSprintHrs * 100 / TotalWorkHrs));
        }

        public void UpdateSprintWeek(int carryOver,
                                     int commitment,
                                     int ptsAdded,
                                     int completed,
                                     int year,
                                     int period,
                                     int workHrs,
                                     int sprintHrs)
        {
            //MemberStatus = memberCapacity;
            TotalWorkHrs = workHrs;
            TotalSprintHrs = sprintHrs;
          
            Sprints.Add(new SprintWeek(year, period, carryOver, commitment, ptsAdded, completed, TotalSprintHrs * 100 / TotalWorkHrs));
        }


    }
}
