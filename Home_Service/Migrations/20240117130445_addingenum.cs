using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Home_Service.Migrations
{
    public partial class addingenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e9db2a7-c8d0-4c80-92b9-3853cbcad123");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bffad6f5-7dca-4f27-81ca-23bee6b21064");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dffb9f41-e4c6-4457-8040-d2fa9938b582");

            migrationBuilder.RenameColumn(
                name: "RejectionReason",
                table: "services",
                newName: "Justification");

            migrationBuilder.AddColumn<int>(
                name: "serviceStatus",
                table: "bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5b59cac-b2e0-43bd-a72a-7d913b7019b0", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea114813-5e7a-46b2-aa48-acec64be5522", "2", "Seller", "Seller" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7af602b-8227-44b1-bc90-7dcc0135daaf", "3", "Customer", "Customer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5b59cac-b2e0-43bd-a72a-7d913b7019b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea114813-5e7a-46b2-aa48-acec64be5522");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7af602b-8227-44b1-bc90-7dcc0135daaf");

            migrationBuilder.DropColumn(
                name: "serviceStatus",
                table: "bookings");

            migrationBuilder.RenameColumn(
                name: "Justification",
                table: "services",
                newName: "RejectionReason");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5e9db2a7-c8d0-4c80-92b9-3853cbcad123", "3", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bffad6f5-7dca-4f27-81ca-23bee6b21064", "2", "Seller", "Seller" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dffb9f41-e4c6-4457-8040-d2fa9938b582", "1", "Admin", "Admin" });
        }
    }
}
