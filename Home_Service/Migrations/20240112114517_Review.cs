using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Home_Service.Migrations
{
    public partial class Review : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08e8709b-14ca-4a80-bd9e-6b8d6859386f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d107a788-89ff-4a9f-b2b0-fcfa5f2df323");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5cd2b05-f40b-4120-8278-54ae2b8423f7");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "services",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28ee1bdc-682a-41b8-9f53-95d4babf2523", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7dca485e-f90f-4a8b-b989-e2c95caec5f3", "3", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d390ca82-0e17-48ce-817c-9c65a9f56d29", "2", "Seller", "Seller" });

            migrationBuilder.CreateIndex(
                name: "IX_services_UserId",
                table: "services",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_services_AspNetUsers_UserId",
                table: "services",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_services_AspNetUsers_UserId",
                table: "services");

            migrationBuilder.DropIndex(
                name: "IX_services_UserId",
                table: "services");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28ee1bdc-682a-41b8-9f53-95d4babf2523");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dca485e-f90f-4a8b-b989-e2c95caec5f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d390ca82-0e17-48ce-817c-9c65a9f56d29");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "services");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "08e8709b-14ca-4a80-bd9e-6b8d6859386f", "2", "Seller", "Seller" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d107a788-89ff-4a9f-b2b0-fcfa5f2df323", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5cd2b05-f40b-4120-8278-54ae2b8423f7", "3", "Customer", "Customer" });
        }
    }
}
