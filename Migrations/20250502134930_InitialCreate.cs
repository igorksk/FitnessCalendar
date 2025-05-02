using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessCalendar.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FitnessRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FullBodyTrainingId = table.Column<int>(type: "int", nullable: true),
                    StretchingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FitnessRecords_TrainingTypes_FullBodyTrainingId",
                        column: x => x.FullBodyTrainingId,
                        principalTable: "TrainingTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FitnessRecords_TrainingTypes_StretchingId",
                        column: x => x.StretchingId,
                        principalTable: "TrainingTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "TrainingTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Тренировка всего тела", "FullBody" },
                    { 2, "Растяжка", "Stretching" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FitnessRecords_FullBodyTrainingId",
                table: "FitnessRecords",
                column: "FullBodyTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessRecords_StretchingId",
                table: "FitnessRecords",
                column: "StretchingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FitnessRecords");

            migrationBuilder.DropTable(
                name: "TrainingTypes");
        }
    }
}
