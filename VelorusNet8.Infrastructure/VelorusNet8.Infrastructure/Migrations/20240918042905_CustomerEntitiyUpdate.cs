using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelorusNet8.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CustomerEntitiyUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BalanceCredit",
                table: "AngularCustomers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BalanceDebt",
                table: "AngularCustomers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Credit",
                table: "AngularCustomers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Debt",
                table: "AngularCustomers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "BalanceCredit", "BalanceDebt", "CreatedDate", "Credit", "Debt" },
                values: new object[] { 0m, 0m, new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5257), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "BalanceCredit", "BalanceDebt", "CreatedDate", "Credit", "Debt" },
                values: new object[] { 0m, 0m, new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5263), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "BalanceCredit", "BalanceDebt", "CreatedDate", "Credit", "Debt" },
                values: new object[] { 0m, 0m, new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5265), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "BalanceCredit", "BalanceDebt", "CreatedDate", "Credit", "Debt" },
                values: new object[] { 0m, 0m, new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5268), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "BalanceCredit", "BalanceDebt", "CreatedDate", "Credit", "Debt" },
                values: new object[] { 0m, 0m, new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5307), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "BalanceCredit", "BalanceDebt", "CreatedDate", "Credit", "Debt" },
                values: new object[] { 0m, 0m, new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5310), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "BalanceCredit", "BalanceDebt", "CreatedDate", "Credit", "Debt" },
                values: new object[] { 0m, 0m, new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5313), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "BalanceCredit", "BalanceDebt", "CreatedDate", "Credit", "Debt" },
                values: new object[] { 0m, 0m, new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5315), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "BalanceCredit", "BalanceDebt", "CreatedDate", "Credit", "Debt" },
                values: new object[] { 0m, 0m, new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5317), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "BalanceCredit", "BalanceDebt", "CreatedDate", "Credit", "Debt" },
                values: new object[] { 0m, 0m, new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5320), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "BalanceCredit", "BalanceDebt", "CreatedDate", "Credit", "Debt" },
                values: new object[] { 0m, 0m, new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5322), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "BalanceCredit", "BalanceDebt", "CreatedDate", "Credit", "Debt" },
                values: new object[] { 0m, 0m, new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5324), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "BalanceCredit", "BalanceDebt", "CreatedDate", "Credit", "Debt" },
                values: new object[] { 0m, 0m, new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5327), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "BalanceCredit", "BalanceDebt", "CreatedDate", "Credit", "Debt" },
                values: new object[] { 0m, 0m, new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5329), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "BalanceCredit", "BalanceDebt", "CreatedDate", "Credit", "Debt" },
                values: new object[] { 0m, 0m, new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5331), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "CompanyBranches",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(4809));

            migrationBuilder.UpdateData(
                table: "MenuPermissions",
                keyColumn: "MenuPermissionId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5180));

            migrationBuilder.UpdateData(
                table: "MenuPermissions",
                keyColumn: "MenuPermissionId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5183));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5147));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5153));

            migrationBuilder.UpdateData(
                table: "UserAccountGroups",
                keyColumns: new[] { "GroupId", "UserAccountId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedDate",
                value: new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5211));

            migrationBuilder.UpdateData(
                table: "UserAccountGroups",
                keyColumns: new[] { "GroupId", "UserAccountId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedDate",
                value: new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5213));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5072));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5075));

            migrationBuilder.UpdateData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5105));

            migrationBuilder.UpdateData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 18, 4, 29, 3, 191, DateTimeKind.Utc).AddTicks(5113));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalanceCredit",
                table: "AngularCustomers");

            migrationBuilder.DropColumn(
                name: "BalanceDebt",
                table: "AngularCustomers");

            migrationBuilder.DropColumn(
                name: "Credit",
                table: "AngularCustomers");

            migrationBuilder.DropColumn(
                name: "Debt",
                table: "AngularCustomers");

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5979));

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5987));

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5989));

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5991));

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5993));

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5995));

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5997));

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5999));

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(6001));

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(6003));

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(6005));

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(6055));

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(6057));

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(6060));

            migrationBuilder.UpdateData(
                table: "AngularCustomers",
                keyColumn: "id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(6063));

            migrationBuilder.UpdateData(
                table: "CompanyBranches",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5610));

            migrationBuilder.UpdateData(
                table: "MenuPermissions",
                keyColumn: "MenuPermissionId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5912));

            migrationBuilder.UpdateData(
                table: "MenuPermissions",
                keyColumn: "MenuPermissionId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5915));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5880));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5885));

            migrationBuilder.UpdateData(
                table: "UserAccountGroups",
                keyColumns: new[] { "GroupId", "UserAccountId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "UserAccountGroups",
                keyColumns: new[] { "GroupId", "UserAccountId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5944));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5807));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5837));

            migrationBuilder.UpdateData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5848));
        }
    }
}
