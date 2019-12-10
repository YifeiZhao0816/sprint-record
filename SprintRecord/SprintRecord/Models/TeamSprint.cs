using System;
namespace SprintRecord.Models
{
    public class TeamSprint
    {
        public Team Team { get; set; }
        public int AvgVelocity { get; set; }
        public int TotalWorkHrs { get; set; }
        public int TotalSprintHrs { get; set; }
        public int SprintPercent { get; set; }


        //private void NeverDoThis()
        //{
        //    var thingIWillNeverUnderstandWithoutLotsOfDebuggingAndFury = new Tuple<Team, int, int, string, int>(new Team(), 1, 2, null, 3);
        //}
    }
}