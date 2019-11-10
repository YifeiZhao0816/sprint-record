using System.Collections.Generic;

namespace SprintRecord.Models
{
    public class Team
    {
        public string Name { get; set; }
        public int AvgVelocity { get; set; }
        public int TotalHrs { get; set; }
        public int SprintPercent { get; set; }
        public Dictionary<string, int[]> MemberStatus { get;  }
        public List<SprintWeek> Sprints { get; }

        public Team(string name, IEnumerable<string> members)
        {
            AvgVelocity = int.MinValue;
            TotalHrs = int.MinValue;
            SprintPercent = int.MinValue;
            Name = name;
            Sprints = new List<SprintWeek>();
            MemberStatus = new Dictionary<string, int[]>();
            foreach (var member in members)
            {
                MemberStatus.Add(member, new int[2] { int.MinValue, int.MinValue });
            }
        }

    }
}
