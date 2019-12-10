using System.Collections.Generic;

namespace SprintRecord.Models
{
    public class Team
    {
        public string Name { get; set; }
        public int AvgVelocity { get; set; }
        public int TotalWorkHrs { get; set; }
        public int TotalSprintHrs { get; set; }
        public int SprintPercent { get; set; }
        public Dictionary<string, int[]> MemberStatus { get; private set; } // <string name, int[2]{workHrs, sprintHrs}>
        public List<SprintWeek> Sprints { get; private set; }

        public Team(string name, IEnumerable<string> members)
        {
            AvgVelocity = int.MinValue;
            TotalWorkHrs = int.MinValue;
            TotalSprintHrs = int.MinValue;
            SprintPercent = int.MinValue;
            Name = name;
            Sprints = new List<SprintWeek>();
            MemberStatus = new Dictionary<string, int[]>();
            foreach (var member in members)
            {
                MemberStatus.Add(member, new int[2] { int.MinValue, int.MinValue });
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
            MemberStatus = new Dictionary<string, int[]>();
        }

        public void UpdateSprintWeek(Dictionary<string, int[]> memberCapacity,
                                     int carryOver,
                                     int commitment,
                                     int ptsAdded,
                                     int completed,
                                     int year,
                                     int period)
        {
            MemberStatus = memberCapacity;
            TotalWorkHrs = 0;
            TotalSprintHrs = 0;
            foreach (var member in MemberStatus)
            {
                TotalWorkHrs += member.Value[0];
                TotalSprintHrs += member.Value[1];
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
            MemberStatus = memberCapacity;
            TotalWorkHrs = workHrs;
            TotalSprintHrs = sprintHrs;
          
            Sprints.Add(new SprintWeek(year, period, carryOver, commitment, ptsAdded, completed, TotalSprintHrs * 100 / TotalWorkHrs));
        }


    }
}
