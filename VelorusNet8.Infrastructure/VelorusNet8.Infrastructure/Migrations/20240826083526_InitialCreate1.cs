using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelorusNet8.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 26, 11, 35, 24, 910, DateTimeKind.Local).AddTicks(2193));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 26, 7, 36, 28, 386, DateTimeKind.Local).AddTicks(194));
        }
    }
}
