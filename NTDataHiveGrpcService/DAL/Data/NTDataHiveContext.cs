using Microsoft.EntityFrameworkCore;
using NTDataHiveGrpcService.DAL.Model;

namespace NTDataHiveGrpcService.DAL.Data
{
    public partial class NTDataHiveContext : DbContext
    {
        public NTDataHiveContext()
        {            
        }
        public NTDataHiveContext(DbContextOptions<NTDataHiveContext> options) : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonTypes> PersonType { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<PreEditing> PreEditing { get; set; }
        public virtual DbSet<Revision> Revision { get; set; }
        public virtual DbSet<Publisher> Publisher { get; set; }
        public virtual DbSet<Credit> Credit { get; set; }
        public virtual DbSet<Error> Error { get; set; }
        public virtual DbSet<Evaluation> Evaluation { get; set; }
        public virtual DbSet<Approval> Approval { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new Exception("DbContext has no connection");
            }            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evaluation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MegaEvaluation);

                entity.HasOne(d => d.MegaEvaluationNavigation)
                    .WithMany(p => p.InverseMegaEvaluationNavigation)
                    .HasForeignKey(d => d.MegaEvaluation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Evaluation_Evaluation");
            });

            modelBuilder.Entity<Approval>(entity =>
            {
                entity.HasKey(e => e.ApprovalIdExt);

                entity.Property(e => e.ApprovalIdExt).ValueGeneratedNever();

                entity.HasOne(d => d.EvaluationNavigation)
                    .WithOne(p => p.Approval)
                    .HasForeignKey<Approval>(d => d.ApprovalIdExt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Approval_Evaluation");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
