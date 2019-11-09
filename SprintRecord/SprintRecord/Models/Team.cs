using System.Collections.Generic;

namespace SprintRecord.Models
{
    public class Team
    {
        public List<SprintWeek> Sprints { get;  }
        public string Name { get; set; }
        public int AvgVelocity { get; set; }
        public int MyProperty { get; set; }
        public int SprintPercent { get; set; }

    }
}
