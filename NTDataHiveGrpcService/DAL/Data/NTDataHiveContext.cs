﻿using Microsoft.EntityFrameworkCore;
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
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Evaluation> Evaluation { get; set; }
        public virtual DbSet<Approval> Approval { get; set; }
        public virtual DbSet<Quality> Quality { get; set; }

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

            modelBuilder.Entity<Quality>(entity =>
            {
                entity.HasKey(e => e.QualityIdExt);
                
                entity.Property(e => e.QualityIdExt).ValueGeneratedNever();

                entity.HasOne(d => d.EvaluationNavigation)
                    .WithOne(p => p.Quality)
                    .HasForeignKey<Quality>(d => d.QualityIdExt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quality_Evaluation");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
