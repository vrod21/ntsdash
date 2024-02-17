﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NTDataHiveGrpcService.DAL.Data;

#nullable disable

namespace NTDataHiveGrpcService.Migrations
{
    [DbContext(typeof(NTDataHiveContext))]
    partial class NTDataHiveContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NTDataHiveGrpcService.DAL.Model.Approval", b =>
                {
                    b.Property<int>("ApprovalIdExt")
                        .HasColumnType("int");

                    b.Property<string>("CorrectiveAction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NatureOfCA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NatureOfPM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerOfCA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerOfPM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreventiveMeasure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RootCause")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusOfCA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusOfPM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TargetDateOfCompletionCA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TargetDateOfCompletionPM")
                        .HasColumnType("datetime2");

                    b.Property<string>("Validate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApprovalIdExt");

                    b.ToTable("Approval");
                });

            modelBuilder.Entity("NTDataHiveGrpcService.DAL.Model.Evaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArticleId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CopyEditedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CopyEditingLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionOfError")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ErrorCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ErrorCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ErrorCount")
                        .HasColumnType("float");

                    b.Property<string>("ErrorLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ErrorSubtype")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ErrorType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IntroducedOrMissed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JournalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Matter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MegaEvaluation")
                        .HasColumnType("int");

                    b.Property<double>("PageCount")
                        .HasColumnType("float");

                    b.Property<string>("PublisherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QualityAssurance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("YearMonth")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MegaEvaluation");

                    b.ToTable("Evaluation");
                });

            modelBuilder.Entity("NTDataHiveGrpcService.DAL.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("CompanyId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportingManager")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("NTDataHiveGrpcService.DAL.Model.Quality", b =>
                {
                    b.Property<int>("QualityIdExt")
                        .HasColumnType("int");

                    b.Property<double>("AccuracyRating")
                        .HasColumnType("float");

                    b.Property<double>("AccuracyRatingFC")
                        .HasColumnType("float");

                    b.Property<double>("AccuracyRatingIPF")
                        .HasColumnType("float");

                    b.Property<string>("Component")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DCF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateChecked")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateProcessed")
                        .HasColumnType("datetime2");

                    b.Property<double>("ErrorPerPages")
                        .HasColumnType("float");

                    b.Property<double>("FinalErrorPoints")
                        .HasColumnType("float");

                    b.Property<double>("OverallAccuracyRating")
                        .HasColumnType("float");

                    b.Property<string>("PageType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalErrorPoints")
                        .HasColumnType("float");

                    b.Property<double>("TotalTSPages")
                        .HasColumnType("float");

                    b.Property<double>("WeightPercentFC")
                        .HasColumnType("float");

                    b.Property<double>("WeightPercentIPF")
                        .HasColumnType("float");

                    b.Property<double>("WeightedRatingFC")
                        .HasColumnType("float");

                    b.Property<double>("WeightedRatingIPF")
                        .HasColumnType("float");

                    b.HasKey("QualityIdExt");

                    b.ToTable("Quality");
                });

            modelBuilder.Entity("NTDataHiveGrpcService.DAL.Model.Approval", b =>
                {
                    b.HasOne("NTDataHiveGrpcService.DAL.Model.Evaluation", "EvaluationNavigation")
                        .WithOne("Approval")
                        .HasForeignKey("NTDataHiveGrpcService.DAL.Model.Approval", "ApprovalIdExt")
                        .IsRequired()
                        .HasConstraintName("FK_Approval_Evaluation");

                    b.Navigation("EvaluationNavigation");
                });

            modelBuilder.Entity("NTDataHiveGrpcService.DAL.Model.Evaluation", b =>
                {
                    b.HasOne("NTDataHiveGrpcService.DAL.Model.Evaluation", "MegaEvaluationNavigation")
                        .WithMany("InverseMegaEvaluationNavigation")
                        .HasForeignKey("MegaEvaluation")
                        .HasConstraintName("FK_Evaluation_Evaluation");

                    b.Navigation("MegaEvaluationNavigation");
                });

            modelBuilder.Entity("NTDataHiveGrpcService.DAL.Model.Quality", b =>
                {
                    b.HasOne("NTDataHiveGrpcService.DAL.Model.Evaluation", "EvaluationNavigation")
                        .WithOne("Quality")
                        .HasForeignKey("NTDataHiveGrpcService.DAL.Model.Quality", "QualityIdExt")
                        .IsRequired()
                        .HasConstraintName("FK_Quality_Evaluation");

                    b.Navigation("EvaluationNavigation");
                });

            modelBuilder.Entity("NTDataHiveGrpcService.DAL.Model.Evaluation", b =>
                {
                    b.Navigation("Approval");

                    b.Navigation("InverseMegaEvaluationNavigation");

                    b.Navigation("Quality");
                });
#pragma warning restore 612, 618
        }
    }
}
