using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Nonograms_1._1.Models
{
    public partial class ModelNonograms : DbContext
    {
        public ModelNonograms()
            : base("name=ModelNonograms2")
        {
        }

        public virtual DbSet<Crossword> Crosswords { get; set; }
        public virtual DbSet<Difficult> Difficults { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SolvingProcess> SolvingProcesses { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Difficult>()
                .HasMany(e => e.Crosswords)
                .WithRequired(e => e.Difficult)
                .WillCascadeOnDelete(false);
        }
    }
}
