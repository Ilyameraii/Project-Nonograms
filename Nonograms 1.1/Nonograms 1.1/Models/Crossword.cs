namespace Nonograms_1._1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Crossword")]
    public partial class Crossword
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Crossword()
        {
            SolvingProcesses = new HashSet<SolvingProcess>();
        }

        public int CrosswordID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Matrix { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Difficult { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SolvingProcess> SolvingProcesses { get; set; }
    }
}
