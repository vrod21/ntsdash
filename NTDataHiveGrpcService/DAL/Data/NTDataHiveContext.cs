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
        public virtual DbSet<Feedback> Feedback { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new Exception("DbContext has no connection");
            }            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.WebId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PageCount).HasColumnType("float");

                entity.Property(e => e.RootCause)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CorrectiveAction)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NatureOfCA)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerOfCA)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TargetDateOfCompletionCA)
                    .HasColumnType("datetime");              

                entity.Property(e => e.PreventiveMeasure)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NatureOfPM)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerOfPM)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TargetDateOfCompletionPM)
                    .HasColumnType("datetime");

                entity.Property(e => e.StatusOfCA)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusOfPM)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime");

                entity.Property(e => e.MegaFeedback).HasColumnName("megaFeedback");

                entity.HasOne(d => d.MegaFeedbackNavigation)
                    .WithMany(p => p.InverseMegaFeedbackNavigation)
                    .HasForeignKey(d => d.MegaFeedback)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_Address");
            });

            modelBuilder.Entity<Credit>(entity =>
            {
                entity.HasKey(e => e.CreditIdExt);

                entity.Property(e => e.CreditIdExt).ValueGeneratedNever();

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.QualityAssurance)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PublisherName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JournalId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ArticleId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CopyEditedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CopyEditingLevel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.FeedbackCreditNavigation)
                    .WithOne(p => p.Credit)
                    .HasForeignKey<Credit>(d => d.CreditIdExt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Credit_Feedback");
            });

            modelBuilder.Entity<Error>(entity =>
            {
                entity.HasKey(e => e.ErrorIdExt);

                entity.Property(e => e.ErrorIdExt).ValueGeneratedNever();

                entity.Property(e => e.WebId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorCount)
                    .HasColumnType("float");

                entity.Property(e => e.DescriptionOfError)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Matter)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorLocation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorSubtype)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorCategory)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IntroducedOrMissed)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.FeedbackErrorNavigation)
                    .WithOne(p => p.Error)
                    .HasForeignKey<Error>(d => d.ErrorIdExt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Error_Feedback");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
