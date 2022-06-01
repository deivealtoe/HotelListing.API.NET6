using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.API.Migrations
{
    public partial class RemovedPasswordColumnFromUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0247953b-4db6-49bd-bfbb-efc9b78a600a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8802ed53-a186-491a-9dd1-1547a086f524");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "890f853b-f7e8-4a85-9ab1-4dd0108b272c", "ac66adb7-4e27-4006-9541-45f09080202a", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "da1c0379-7736-4ab6-a732-8b6b513a7317", "68d968a0-77f9-4473-bbad-96c94f8f7302", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "890f853b-f7e8-4a85-9ab1-4dd0108b272c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da1c0379-7736-4ab6-a732-8b6b513a7317");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0247953b-4db6-49bd-bfbb-efc9b78a600a", "cb499c9c-66f2-495b-aff8-00f06a421013", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8802ed53-a186-491a-9dd1-1547a086f524", "83c122d6-d3cd-4dff-a7eb-5e4abb0acf59", "Administrator", "ADMINISTRATOR" });
        }
    }
}
