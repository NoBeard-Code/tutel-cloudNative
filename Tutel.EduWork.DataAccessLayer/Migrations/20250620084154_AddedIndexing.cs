using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tutel.EduWork.Migrations
{
    /// <inheritdoc />
    public partial class AddedIndexing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSessions_IsOvertime",
                table: "WorkSessions",
                column: "IsOvertime");

            migrationBuilder.CreateIndex(
                name: "IX_WorkDays_WorkDate",
                table: "WorkDays",
                column: "WorkDate");

            migrationBuilder.CreateIndex(
                name: "IX_WorkDays_WorkDayStart",
                table: "WorkDays",
                column: "WorkDayStart");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_EndDate",
                table: "Vacations",
                column: "EndDate");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_IsTeamBuilding",
                table: "Vacations",
                column: "IsTeamBuilding");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_StartDate",
                table: "Vacations",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_SickLeaves_EndDate",
                table: "SickLeaves",
                column: "EndDate");

            migrationBuilder.CreateIndex(
                name: "IX_SickLeaves_StartDate",
                table: "SickLeaves",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_IsActive",
                table: "Projects",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_IsBillable",
                table: "Projects",
                column: "IsBillable");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Name",
                table: "Projects",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Name",
                table: "AspNetUsers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Surname",
                table: "AspNetUsers",
                column: "Surname");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkSessions_IsOvertime",
                table: "WorkSessions");

            migrationBuilder.DropIndex(
                name: "IX_WorkDays_WorkDate",
                table: "WorkDays");

            migrationBuilder.DropIndex(
                name: "IX_WorkDays_WorkDayStart",
                table: "WorkDays");

            migrationBuilder.DropIndex(
                name: "IX_Vacations_EndDate",
                table: "Vacations");

            migrationBuilder.DropIndex(
                name: "IX_Vacations_IsTeamBuilding",
                table: "Vacations");

            migrationBuilder.DropIndex(
                name: "IX_Vacations_StartDate",
                table: "Vacations");

            migrationBuilder.DropIndex(
                name: "IX_SickLeaves_EndDate",
                table: "SickLeaves");

            migrationBuilder.DropIndex(
                name: "IX_SickLeaves_StartDate",
                table: "SickLeaves");

            migrationBuilder.DropIndex(
                name: "IX_Projects_IsActive",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_IsBillable",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_Name",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Name",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Surname",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
