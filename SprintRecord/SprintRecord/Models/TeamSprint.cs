using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SprintRecord.Models
{
    [Table("team_sprint")]
    public partial class TeamSprint
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("sprintid", TypeName = "int(11)")]
        public int Sprintid { get; set; }
        [Column("teamid", TypeName = "int(11)")]
        public int Teamid { get; set; }
        [Column("capacity", TypeName = "int(11)")]
        public int Capacity { get; set; }
        [Column("carryover", TypeName = "int(11)")]
        public int Carryover { get; set; }
        [Column("pointsadded", TypeName = "int(11)")]
        public int Pointsadded { get; set; }
        [Column("completed", TypeName = "int(11)")]
        public int Completed { get; set; }
        [Column("commitment", TypeName = "int(11)")]
        public int Commitment { get; set; }
    }
}
