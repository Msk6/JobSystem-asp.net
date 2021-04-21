using Microsoft.EntityFrameworkCore.Migrations;

namespace JobsSystem.Migrations
{
    public partial class addedJobIdToSubmission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Jobs_jobid",
                table: "Submissions");

            migrationBuilder.RenameColumn(
                name: "jobid",
                table: "Submissions",
                newName: "JobId");

            migrationBuilder.RenameIndex(
                name: "IX_Submissions_jobid",
                table: "Submissions",
                newName: "IX_Submissions_JobId");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "Submissions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Jobs_JobId",
                table: "Submissions",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Jobs_JobId",
                table: "Submissions");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "Submissions",
                newName: "jobid");

            migrationBuilder.RenameIndex(
                name: "IX_Submissions_JobId",
                table: "Submissions",
                newName: "IX_Submissions_jobid");

            migrationBuilder.AlterColumn<int>(
                name: "jobid",
                table: "Submissions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Jobs_jobid",
                table: "Submissions",
                column: "jobid",
                principalTable: "Jobs",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
