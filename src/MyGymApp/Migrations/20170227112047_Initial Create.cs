﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyGymApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Postcode = table.Column<int>(nullable: false),
                    StreetName = table.Column<string>(type: "varchar(20)", nullable: false),
                    StreetNumber = table.Column<string>(type: "varchar(7)", nullable: false),
                    Suburb = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Muscles",
                columns: table => new
                {
                    MuscleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muscles", x => x.MuscleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: true),
                    Avatar = table.Column<byte[]>(nullable: true),
                    AvatarId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(type: "varchar(30)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(20)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(20)", nullable: false),
                    MobileNumber = table.Column<string>(type: "varchar(13)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    AdministratorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.AdministratorId);
                    table.ForeignKey(
                        name: "FK_Administrators_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutSessions",
                columns: table => new
                {
                    WorkoutSessionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSessions", x => x.WorkoutSessionId);
                    table.ForeignKey(
                        name: "FK_WorkoutSessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutRecords",
                columns: table => new
                {
                    WorkoutRecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityName = table.Column<string>(nullable: false),
                    DurationInMinutes = table.Column<int>(nullable: true),
                    NumberOfReps = table.Column<int>(nullable: true),
                    NumberOfSets = table.Column<int>(nullable: true),
                    WorkoutSessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutRecords", x => x.WorkoutRecordId);
                    table.ForeignKey(
                        name: "FK_WorkoutRecords_WorkoutSessions_WorkoutSessionId",
                        column: x => x.WorkoutSessionId,
                        principalTable: "WorkoutSessions",
                        principalColumn: "WorkoutSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutRecordMuscles",
                columns: table => new
                {
                    MuscleId = table.Column<int>(nullable: false),
                    WorkoutRecordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutRecordMuscles", x => new { x.MuscleId, x.WorkoutRecordId });
                    table.ForeignKey(
                        name: "FK_WorkoutRecordMuscles_Muscles_MuscleId",
                        column: x => x.MuscleId,
                        principalTable: "Muscles",
                        principalColumn: "MuscleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutRecordMuscles_WorkoutRecords_WorkoutRecordId",
                        column: x => x.WorkoutRecordId,
                        principalTable: "WorkoutRecords",
                        principalColumn: "WorkoutRecordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_UserId",
                table: "Administrators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRecords_WorkoutSessionId",
                table: "WorkoutRecords",
                column: "WorkoutSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRecordMuscles_WorkoutRecordId",
                table: "WorkoutRecordMuscles",
                column: "WorkoutRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_UserId",
                table: "WorkoutSessions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "WorkoutRecordMuscles");

            migrationBuilder.DropTable(
                name: "Muscles");

            migrationBuilder.DropTable(
                name: "WorkoutRecords");

            migrationBuilder.DropTable(
                name: "WorkoutSessions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
