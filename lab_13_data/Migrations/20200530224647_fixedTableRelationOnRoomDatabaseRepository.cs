using Microsoft.EntityFrameworkCore.Migrations;

namespace lab_13_data.Migrations
{
    public partial class fixedTableRelationOnRoomDatabaseRepository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenities_Rooms_RoomsId",
                table: "Amenities");

            migrationBuilder.DropIndex(
                name: "IX_Amenities_RoomsId",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "RoomsId",
                table: "Amenities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomsId",
                table: "Amenities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_RoomsId",
                table: "Amenities",
                column: "RoomsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenities_Rooms_RoomsId",
                table: "Amenities",
                column: "RoomsId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
