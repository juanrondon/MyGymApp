using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyGymApp.Migrations
{
    public partial class RemovedSomeEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutRecords_Exercises_ExerciseId",
                table: "WorkoutRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSessions_WorkoutPlans_WorkoutPlanId",
                table: "WorkoutSessions");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutSessions_WorkoutPlanId",
                table: "WorkoutSessions");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutRecords_ExerciseId",
                table: "WorkoutRecords");

            migrationBuilder.DropColumn(
                name: "WorkoutPlanId",
                table: "WorkoutSessions");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "WorkoutRecords");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "WorkoutPlans");

            migrationBuilder.AddColumn<int>(
                name: "WorkoutRecordId",
                table: "Muscles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Muscles_WorkoutRecordId",
                table: "Muscles",
                column: "WorkoutRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Muscles_WorkoutRecords_WorkoutRecordId",
                table: "Muscles",
                column: "WorkoutRecordId",
                principalTable: "WorkoutRecords",
                principalColumn: "WorkoutRecordId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameColumn(
                name: "mobileNumber",
                table: "Users",
                newName: "MobileNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Muscles_WorkoutRecords_WorkoutRecordId",
                table: "Muscles");

            migrationBuilder.DropIndex(
                name: "IX_Muscles_WorkoutRecordId",
                table: "Muscles");

            migrationBuilder.DropColumn(
                name: "WorkoutRecordId",
                table: "Muscles");

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(20)", nullable: false),
                    TargetedMuscles = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ExerciseId);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutPlans",
                columns: table => new
                {
                    WorkoutPlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(max)", nullable: true),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPlans", x => x.WorkoutPlanId);
                });

            migrationBuilder.AddColumn<int>(
                name: "WorkoutPlanId",
                table: "WorkoutSessions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "WorkoutRecords",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_WorkoutPlanId",
                table: "WorkoutSessions",
                column: "WorkoutPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRecords_ExerciseId",
                table: "WorkoutRecords",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutRecords_Exercises_ExerciseId",
                table: "WorkoutRecords",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSessions_WorkoutPlans_WorkoutPlanId",
                table: "WorkoutSessions",
                column: "WorkoutPlanId",
                principalTable: "WorkoutPlans",
                principalColumn: "WorkoutPlanId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameColumn(
                name: "MobileNumber",
                table: "Users",
                newName: "mobileNumber");
        }
    }
}
