namespace Nonograms_1._1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Difficult")]
    public partial class Difficult
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Difficult()
        {
            Crosswords = new HashSet<Crossword>();
        }

        public int DifficultID { get; set; }

        [Required]
        [StringLength(255)]
        public string DifficultName { get; set; }

        public int DifficultLevel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Crossword> Crosswords { get; set; }
    }
}
