using Microsoft.EntityFrameworkCore.Migrations;

namespace SnQPoolIot.Logic.Migrations
{
    public partial class tryingtofixIdWithGrammar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SensorListID",
                schema: "PoolIot",
                table: "SensorData",
                newName: "SensorListId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorData_SensorListId",
                schema: "PoolIot",
                table: "SensorData",
                column: "SensorListId");

            migrationBuilder.AddForeignKey(
                name: "FK_SensorData_SensorList_SensorListId",
                schema: "PoolIot",
                table: "SensorData",
                column: "SensorListId",
                principalSchema: "PoolIot",
                principalTable: "SensorList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SensorData_SensorList_SensorListId",
                schema: "PoolIot",
                table: "SensorData");

            migrationBuilder.DropIndex(
                name: "IX_SensorData_SensorListId",
                schema: "PoolIot",
                table: "SensorData");

            migrationBuilder.RenameColumn(
                name: "SensorListId",
                schema: "PoolIot",
                table: "SensorData",
                newName: "SensorListID");
        }
    }
}
