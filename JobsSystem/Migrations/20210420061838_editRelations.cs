using Microsoft.EntityFrameworkCore.Migrations;

namespace JobsSystem.Migrations
{
    public partial class editRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "jobid",
                table: "Submissions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_jobid",
                table: "Submissions",
                column: "jobid");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Jobs_jobid",
                table: "Submissions",
                column: "jobid",
                principalTable: "Jobs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Jobs_jobid",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_jobid",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "jobid",
                table: "Submissions");
        }
    }
}
