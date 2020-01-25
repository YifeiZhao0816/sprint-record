using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SprintRecord.Models
{
    [Table("sprints")]
    public partial class Sprints
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("name", TypeName = "varchar(45)")]
        public string Name { get; set; }
    }
}
