using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MyGymApp.DataAccess.Models;

namespace MyGymApp.Migrations
{
    [DbContext(typeof(MyGymAppDbContext))]
    partial class MyGymAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyGymApp.DataAccess.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Postcode");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("varchar(7)");

                    b.Property<string>("Suburb")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("MyGymApp.DataAccess.Models.Administrator", b =>
                {
                    b.Property<int>("AdministratorId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserId");

                    b.HasKey("AdministratorId");

                    b.HasIndex("UserId");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("MyGymApp.DataAccess.Models.Exercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("TargetedMuscles")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("ExerciseId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("MyGymApp.DataAccess.Models.Muscle", b =>
                {
                    b.Property<int>("MuscleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("MuscleId");

                    b.ToTable("Muscles");
                });

            modelBuilder.Entity("MyGymApp.DataAccess.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressId");

                    b.Property<byte[]>("Avatar");

                    b.Property<int>("AvatarId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("mobileNumber")
                        .HasColumnType("varchar(13)");

                    b.HasKey("UserId");

                    b.HasIndex("AddressId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyGymApp.DataAccess.Models.WorkoutPlan", b =>
                {
                    b.Property<int>("WorkoutPlanId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("WorkoutPlanId");

                    b.ToTable("WorkoutPlans");
                });

            modelBuilder.Entity("MyGymApp.DataAccess.Models.WorkoutRecord", b =>
                {
                    b.Property<int>("WorkoutRecordId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DurationInMinutes");

                    b.Property<int>("ExerciseId");

                    b.Property<int?>("NumberOfReps");

                    b.Property<int?>("NumberOfSets");

                    b.Property<int>("WorkoutSessionId");

                    b.HasKey("WorkoutRecordId");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("WorkoutSessionId");

                    b.ToTable("WorkoutRecords");
                });

            modelBuilder.Entity("MyGymApp.DataAccess.Models.WorkoutSession", b =>
                {
                    b.Property<int>("WorkoutSessionId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<int>("UserId");

                    b.Property<int?>("WorkoutPlanId");

                    b.HasKey("WorkoutSessionId");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkoutPlanId");

                    b.ToTable("WorkoutSessions");
                });

            modelBuilder.Entity("MyGymApp.DataAccess.Models.Administrator", b =>
                {
                    b.HasOne("MyGymApp.DataAccess.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyGymApp.DataAccess.Models.User", b =>
                {
                    b.HasOne("MyGymApp.DataAccess.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("MyGymApp.DataAccess.Models.WorkoutRecord", b =>
                {
                    b.HasOne("MyGymApp.DataAccess.Models.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyGymApp.DataAccess.Models.WorkoutSession", "WorkoutSession")
                        .WithMany()
                        .HasForeignKey("WorkoutSessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyGymApp.DataAccess.Models.WorkoutSession", b =>
                {
                    b.HasOne("MyGymApp.DataAccess.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyGymApp.DataAccess.Models.WorkoutPlan", "WorkoutPlan")
                        .WithMany("WorkoutSessions")
                        .HasForeignKey("WorkoutPlanId");
                });
        }
    }
}
