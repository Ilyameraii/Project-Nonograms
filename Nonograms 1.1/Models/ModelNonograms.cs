namespace Nonograms_1._1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelNonograms : DbContext
    {
        public ModelNonograms()
            : base("name=ModelNonograms")
        {
        }

        public virtual DbSet<Crossword> Crosswords { get; set; }
        public virtual DbSet<SolvingProcess> SolvingProcesses { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
