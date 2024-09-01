﻿// <auto-generated />
using System;
using LiftLog.Data.Concrete.EfCore.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LiftLog.Data.Migrations
{
    [DbContext(typeof(EfDbContext))]
    [Migration("20240708084042_WorkoutSession_and_WorkoutSessionLog_Added")]
    partial class WorkoutSession_and_WorkoutSessionLog_Added
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LiftLog.Entity.Models.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("MovementId")
                        .HasColumnType("integer");

                    b.Property<Guid>("MovementId1")
                        .HasColumnType("uuid");

                    b.Property<string>("MovementName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("SetCount")
                        .HasColumnType("smallint");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<int>("WeightType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MovementId1");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("LiftLog.Entity.Models.Movement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MusclesEngaged")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("VideoLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Movements");
                });

            modelBuilder.Entity("LiftLog.Entity.Models.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<int>("ThighSize")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<int>("WaistSize")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("LiftLog.Entity.Models.WorkoutSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("WorkoutSessions");
                });

            modelBuilder.Entity("LiftLog.Entity.Models.WorkoutSessionLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<int>("WorkoutSessionId")
                        .HasColumnType("integer");

                    b.Property<Guid>("WorkoutSessionId1")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutSessionId1");

                    b.ToTable("WorkoutSessionLogs");
                });

            modelBuilder.Entity("LiftLog.Entity.Models.Exercise", b =>
                {
                    b.HasOne("LiftLog.Entity.Models.Movement", "Movement")
                        .WithMany()
                        .HasForeignKey("MovementId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movement");
                });

            modelBuilder.Entity("LiftLog.Entity.Models.WorkoutSession", b =>
                {
                    b.HasOne("LiftLog.Entity.Models.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("LiftLog.Entity.Models.WorkoutSessionLog", b =>
                {
                    b.HasOne("LiftLog.Entity.Models.WorkoutSession", "WorkoutSession")
                        .WithMany()
                        .HasForeignKey("WorkoutSessionId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkoutSession");
                });
#pragma warning restore 612, 618
        }
    }
}
