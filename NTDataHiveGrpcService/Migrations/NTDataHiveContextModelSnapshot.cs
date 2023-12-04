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

            modelBuilder.Entity("NTDataHiveGrpcService.DAL.Model.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("NTDataHiveGrpcService.DAL.Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Create_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublisherIdentity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ScoreCard")
                        .HasColumnType("int");

                    b.Property<string>("WebId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("NTDataHiveGrpcService.DAL.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("CompanyId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("NTDataHiveGrpcService.DAL.Model.PersonTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PersonTypes");
                });

            modelBuilder.Entity("NTDataHiveGrpcService.DAL.Model.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("NTDataHiveGrpcService.DAL.Model.PreEditing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArticleId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CopyEditedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CopyEditingLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrectiveAction")
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

                    b.Property<int>("ErrorCount")
                        .HasColumnType("int");

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

                    b.Property<string>("NatureOfCA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NatureOfPM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerOfCA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<string>("PreventiveMeasure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublisherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QualityAssurance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RootCause")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusOfCA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusOfPM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TargetDateOfCompletionCA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TargetDateOfCompletionPM")
                        .HasColumnType("datetime2");

                    b.Property<string>("WebId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PreEditing");
                });

            modelBuilder.Entity("NTDataHiveGrpcService.DAL.Model.Revision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArticleId")
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

                    b.Property<int>("ErrorCount")
                        .HasColumnType("int");

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

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<string>("PublisherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QualityAssurance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Revisions");
                });
#pragma warning restore 612, 618
        }
    }
}
