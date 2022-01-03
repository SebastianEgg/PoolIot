using Microsoft.EntityFrameworkCore.Migrations;

namespace SnQPoolIot.Logic.Migrations
{
    public partial class changedId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SensorList_SensorID",
                schema: "PoolIot",
                table: "SensorList");

            migrationBuilder.DropColumn(
                name: "SensorID",
                schema: "PoolIot",
                table: "SensorList");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SensorID",
                schema: "PoolIot",
                table: "SensorList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SensorList_SensorID",
                schema: "PoolIot",
                table: "SensorList",
                column: "SensorID",
                unique: true);
        }
    }
}
