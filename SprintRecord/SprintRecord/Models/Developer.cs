using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SprintRecord.Models
{
    public class Developer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }

        // At this time I suppose each developer could only join 1 team
        // if not, create a new DeveloperStatus class, let Team own a list
        // of DeveloperStatus.
        public MemberStatus CurrentSchedule { get; set; } 
    }
}
