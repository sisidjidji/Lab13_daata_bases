using Microsoft.EntityFrameworkCore.Migrations;

namespace lab_13_data.Migrations
{
    public partial class seeding_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Rooms_RoomId",
                table: "HotelRoom");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "HotelRoom",
                newName: "RoomID");

            migrationBuilder.RenameIndex(
                name: "IX_HotelRoom_RoomId",
                table: "HotelRoom",
                newName: "IX_HotelRoom_RoomID");

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Name", "RoomsId" },
                values: new object[,]
                {
                    { 1, "tv", null },
                    { 2, "toaster", null },
                    { 3, "hair dryer", null }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "City", "Country", "Name", "Phone", "State", "StreetName" },
                values: new object[,]
                {
                    { 1, "north liberty", null, "mercure", null, null, "progress st" },
                    { 2, "north liberty", null, "hilton", null, null, "marylyn dr " },
                    { 3, "north liberty", null, "azure", null, null, "H st" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Layout", "RoomName" },
                values: new object[,]
                {
                    { 1, 0, "red" },
                    { 2, 0, "bleu" },
                    { 3, 0, "pink" },
                    { 4, 0, "purple" }
                });

            migrationBuilder.InsertData(
                table: "HotelRoom",
                columns: new[] { "HotelId", "Number", "PetFrindly", "Rate", "RoomID" },
                values: new object[,]
                {
                    { 1, 250, false, 9.5m, 1 },
                    { 1, 20, false, 5m, 2 },
                    { 1, 300, false, 10m, 3 },
                    { 2, 250, true, 9.5m, 4 }
                });

            migrationBuilder.InsertData(
                table: "RoomAmenities",
                columns: new[] { "AmenitiesId", "RoomId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Rooms_RoomID",
                table: "HotelRoom",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Rooms_RoomID",
                table: "HotelRoom");

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 1, 20 });

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 1, 250 });

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 1, 300 });

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumns: new[] { "HotelId", "Number" },
                keyValues: new object[] { 2, 250 });

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenitiesId", "RoomId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenitiesId", "RoomId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenitiesId", "RoomId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenitiesId", "RoomId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "RoomID",
                table: "HotelRoom",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelRoom_RoomID",
                table: "HotelRoom",
                newName: "IX_HotelRoom_RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Rooms_RoomId",
                table: "HotelRoom",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
