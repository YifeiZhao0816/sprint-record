using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SprintRecord.Models
{
    public class TeamSprint
    {
        public int ID { get; set; }
        public int TeamId { get; set; }
        public int SprintID { get; set; }
        public int Capacity { get; set; }
        public int CarryOver { get; set; }
        public int PointsAdded { get; set; }
        public int Completed { get; set; }
        public int Commitment { get; set; }
    }
}
