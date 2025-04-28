namespace Nonograms_1._1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SolvingProcess")]
    public partial class SolvingProcess
    {
        public int SolvingProcessID { get; set; }

        public int? UsersID { get; set; }

        public int? CrosswordID { get; set; }

        public bool? StatusOfCrossword { get; set; }

        public string Progress { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? StartTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EndTime { get; set; }

        public int? LeadTime { get; set; }

        public int? HintsUsed { get; set; }

        public int? Mistakes { get; set; }

        public virtual Crossword Crossword { get; set; }

        public virtual User User { get; set; }
    }
}
