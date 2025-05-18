namespace Nonograms_1._1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            SolvingProcesses = new HashSet<SolvingProcess>();
        }

        [Key]
        public int UsersID { get; set; }

        [Required]
        [StringLength(255)]
        public string UserLogin { get; set; }

        [Required]
        [StringLength(255)]
        public string UserPassword { get; set; }

        [Required]
        [StringLength(255)]
        public string UserEmail { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RegistrationDate { get; set; }

        public int? RoleID { get; set; }

        public virtual Role Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SolvingProcess> SolvingProcesses { get; set; }
    }
}
