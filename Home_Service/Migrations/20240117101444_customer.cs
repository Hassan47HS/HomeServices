using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Home_Service.Migrations
{
    public partial class customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_services_SerivceId",
                table: "Reviews");

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

            migrationBuilder.RenameColumn(
                name: "SerivceId",
                table: "Reviews",
                newName: "servicesId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_SerivceId",
                table: "Reviews",
                newName: "IX_Reviews_servicesId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "services",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookings_services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_bookings_ServiceId",
                table: "bookings",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_UserId",
                table: "bookings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_services_servicesId",
                table: "Reviews",
                column: "servicesId",
                principalTable: "services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_services_servicesId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "bookings");

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

            migrationBuilder.DropColumn(
                name: "Date",
                table: "services");

            migrationBuilder.RenameColumn(
                name: "servicesId",
                table: "Reviews",
                newName: "SerivceId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_servicesId",
                table: "Reviews",
                newName: "IX_Reviews_SerivceId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_services_SerivceId",
                table: "Reviews",
                column: "SerivceId",
                principalTable: "services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
