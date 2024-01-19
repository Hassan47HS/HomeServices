using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Home_Service.Migrations
{
    public partial class check : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_services_servicesId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_servicesId",
                table: "Reviews");

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
                name: "servicesId",
                table: "Reviews");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "98e6ad23-85a1-46bd-be12-137ff2cddf96", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f476b9bb-c0d6-4e15-9509-5bd47eb4264d", "2", "Seller", "Seller" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd1483b9-9a50-4001-906a-1ae6cd0e9a28", "3", "Customer", "Customer" });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ServiceId",
                table: "Reviews",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_services_ServiceId",
                table: "Reviews",
                column: "ServiceId",
                principalTable: "services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_services_ServiceId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ServiceId",
                table: "Reviews");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98e6ad23-85a1-46bd-be12-137ff2cddf96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f476b9bb-c0d6-4e15-9509-5bd47eb4264d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd1483b9-9a50-4001-906a-1ae6cd0e9a28");

            migrationBuilder.AddColumn<int>(
                name: "servicesId",
                table: "Reviews",
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

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_servicesId",
                table: "Reviews",
                column: "servicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_services_servicesId",
                table: "Reviews",
                column: "servicesId",
                principalTable: "services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
