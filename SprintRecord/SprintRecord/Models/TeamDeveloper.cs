using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SprintRecord.Models
{
    [Table("team_developer")]
    public partial class TeamDeveloper
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("teamid", TypeName = "int(11)")]
        public int Teamid { get; set; }
        [Column("developerid", TypeName = "int(11)")]
        public int Developerid { get; set; }

        public TeamDeveloper(int teamId, int developerId)
        {
            Teamid = teamId;
            Developerid = developerId;
        }

        public TeamDeveloper()
        {
        }
    }
}
