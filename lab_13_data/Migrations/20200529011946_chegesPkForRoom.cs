using Microsoft.EntityFrameworkCore.Migrations;

namespace lab_13_data.Migrations
{
    public partial class chegesPkForRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Room_RoomId",
                table: "HotelRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Room_RoomId",
                table: "RoomAmenities");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.AlterColumn<string>(
                name: "StreetName",
                table: "Hotels",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Hotels",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Hotels",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Hotels",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Hotels",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.AddColumn<int>(
                name: "RoomsId",
                table: "Amenities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(nullable: false),
                    Layout = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Rooms_RoomId",
                table: "HotelRoom",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomId",
                table: "RoomAmenities",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenities_Rooms_RoomsId",
                table: "Amenities");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Rooms_RoomId",
                table: "HotelRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomId",
                table: "RoomAmenities");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Amenities_RoomsId",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "RoomsId",
                table: "Amenities");

            migrationBuilder.AlterColumn<string>(
                name: "StreetName",
                table: "Hotels",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Hotels",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Hotels",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Hotels",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Hotels",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Layout = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Room_RoomId",
                table: "HotelRoom",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Room_RoomId",
                table: "RoomAmenities",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
