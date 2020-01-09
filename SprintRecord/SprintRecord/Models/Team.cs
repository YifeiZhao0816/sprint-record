using System.Collections.Generic;

namespace SprintRecord.Models
{
    public class Team
    {
        public List<Developer> TeamMembers { get; set; }
        public int TeamID { get; set; }
        public string Name { get; set; }
        public int SprintPercent { get; set; }


    }
}
