﻿using System.Collections.Generic;

namespace SprintRecord.Models
{
    public class Team
    {
        public string Name { get; set; }
        public int AvgVelocity { get; set; }
        public int TotalWorkHrs { get; set; }
        public int TotalSprintHrs { get; set; }
        public int SprintPercent { get; set; }
        private Dictionary<string, int[]> MemberStatus { get; set; } // <string name, int[2]{workHrs, sprintHrs}>
        private List<SprintWeek> Sprints { get; set; }

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

        public void UpdateSprintWeek(Dictionary<string, int[]> memberCapacity,
                                     int carryOver,
                                     int commitment,
                                     int ptsAdded,
                                     int completed)
        {
            MemberStatus = memberCapacity;
            TotalWorkHrs = 0;
            TotalSprintHrs = 0;
            foreach (var member in MemberStatus)
            {
                TotalWorkHrs += member.Value[0];
                TotalSprintHrs += member.Value[1];
            }

            Sprints.Add(new SprintWeek(carryOver, commitment, ptsAdded, completed, TotalSprintHrs * 100 / TotalWorkHrs));
        }


    }
}
