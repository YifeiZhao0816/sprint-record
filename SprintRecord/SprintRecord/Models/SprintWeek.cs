using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SprintRecord.Models
{
    public class SprintWeek
    {
        public int Year { get; set; }
        public int Period { get; set; }
        public int CarryOver { get; set; }
        public int Commitment { get; set; }
        public int PointsAdded { get; set; }
        public int Completed { get; set; }
        public int TeamCapacity { get; set; }
        
        public SprintWeek(int carryOver, int commitment, int pointsAdded, int completed, int teamCapacity)
        {
            CarryOver = carryOver;
            Commitment = commitment;
            PointsAdded = pointsAdded;
            Completed = completed;
            TeamCapacity = teamCapacity;
        }
    }
}
