using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MyGymApp.DataAccess.Models;

namespace MyGymApp.Migrations
{
    [DbContext(typeof(MyGymAppDbContext))]
    [Migration("20170223080727_RemovedSomeEntities")]
    partial class RemovedSomeEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("MyGymApp.DataAccess.Models.Muscle", b =>
                {
                    b.Property<int>("MuscleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("WorkoutRecordId");

                    b.HasKey("MuscleId");

                    b.HasIndex("WorkoutRecordId");

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

                    b.Property<string>("MobileNumber")
                        .HasColumnType("varchar(13)");

                    b.HasKey("UserId");

                    b.HasIndex("AddressId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyGymApp.DataAccess.Models.WorkoutRecord", b =>
                {
                    b.Property<int>("WorkoutRecordId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DurationInMinutes");

                    b.Property<int?>("NumberOfReps");

                    b.Property<int?>("NumberOfSets");

                    b.Property<int>("WorkoutSessionId");

                    b.HasKey("WorkoutRecordId");

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

                    b.HasKey("WorkoutSessionId");

                    b.HasIndex("UserId");

                    b.ToTable("WorkoutSessions");
                });

            modelBuilder.Entity("MyGymApp.DataAccess.Models.Administrator", b =>
                {
                    b.HasOne("MyGymApp.DataAccess.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyGymApp.DataAccess.Models.Muscle", b =>
                {
                    b.HasOne("MyGymApp.DataAccess.Models.WorkoutRecord")
                        .WithMany("MusclesTargeted")
                        .HasForeignKey("WorkoutRecordId");
                });

            modelBuilder.Entity("MyGymApp.DataAccess.Models.User", b =>
                {
                    b.HasOne("MyGymApp.DataAccess.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("MyGymApp.DataAccess.Models.WorkoutRecord", b =>
                {
                    b.HasOne("MyGymApp.DataAccess.Models.WorkoutSession", "WorkoutSession")
                        .WithMany("WorkoutRecords")
                        .HasForeignKey("WorkoutSessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyGymApp.DataAccess.Models.WorkoutSession", b =>
                {
                    b.HasOne("MyGymApp.DataAccess.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
