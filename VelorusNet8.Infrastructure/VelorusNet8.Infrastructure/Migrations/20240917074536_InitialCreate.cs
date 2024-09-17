using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VelorusNet8.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AngularCustomers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    city = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    postalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    company = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AngularCustomers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommissionRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CommissionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DefaultShrinkageRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsHeadOffice = table.Column<bool>(type: "bit", nullable: false),
                    IsSalesEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsAutomationIntegrationEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyBranches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Request = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParentMenuId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_Menus_Menus_ParentMenuId",
                        column: x => x.ParentMenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBranches",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBranches", x => new { x.UserId, x.BranchId });
                    table.ForeignKey(
                        name: "FK_UserBranches_CompanyBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "CompanyBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBranches_UserAccounts_UserId",
                        column: x => x.UserId,
                        principalTable: "UserAccounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuPermissions",
                columns: table => new
                {
                    MenuPermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    UserAccountId = table.Column<int>(type: "int", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    CanView = table.Column<bool>(type: "bit", nullable: false),
                    CanEdit = table.Column<bool>(type: "bit", nullable: false),
                    CanDelete = table.Column<bool>(type: "bit", nullable: false),
                    CanExcel = table.Column<bool>(type: "bit", nullable: false),
                    CanPdf = table.Column<bool>(type: "bit", nullable: false),
                    CanWord = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPermissions", x => x.MenuPermissionId);
                    table.ForeignKey(
                        name: "FK_MenuPermissions_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuPermissions_UserAccounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuPermissions_UserGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccountGroups",
                columns: table => new
                {
                    UserAccountId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccountGroups", x => new { x.UserAccountId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_UserAccountGroups_UserAccounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAccountGroups_UserGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AngularCustomers",
                columns: new[] { "id", "CreatedBy", "CreatedDate", "IsActive", "LastModifiedBy", "LastModifiedDate", "address", "city", "company", "country", "email", "firstName", "lastName", "notes", "phone", "position", "postalCode" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5979), true, null, null, "xxx sok no:2 d:15", "Tokat", "ABC Turizm", "Türkiye", "ahmet@abc.com", "Ahmet", "Yandan Bakar", "canavar manager", "5328457000", "Manager", "12345" },
                    { 2, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5987), true, null, null, "yyy sok no:3 d:5", "Ankara", "DEF Lojistik", "Türkiye", "mehmet@def.com", "Mehmet", "Yan Güler", "Başarılı supervisor", "5328457001", "Supervisor", "54321" },
                    { 3, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5989), true, null, null, "zzz sok no:8 d:10", "İstanbul", "GHI İnşaat", "Türkiye", "ayse@ghi.com", "Ayşe", "Gözde Bakar", "Yönetim dehası", "5328457002", "CEO", "67890" },
                    { 4, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5991), true, null, null, "aaa sok no:7 d:12", "İzmir", "JKL Tekstil", "Türkiye", "fatma@jkl.com", "Fatma", "Yıldız", "İnsan kaynakları uzmanı", "5328457003", "HR Manager", "11122" },
                    { 5, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5993), true, null, null, "bbb sok no:1 d:16", "Bursa", "MNO Gıda", "Türkiye", "ali@abc.com", "Ali", "Öztürk", "Satış sihirbazı", "5328457004", "Satış Müdürü", "54333" },
                    { 6, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5995), true, null, null, "ccc sok no:4 d:18", "Antalya", "PQR Bilişim", "Türkiye", "deniz@def.com", "Deniz", "Akdeniz", "Teknoloji gurusu", "5328457005", "IT Manager", "87654" },
                    { 7, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5997), true, null, null, "ddd sok no:6 d:20", "Kocaeli", "STU Otomotiv", "Türkiye", "berk@ghi.com", "Berk", "Kaya", "Operasyon ustası", "5328457006", "Operasyon Müdürü", "23456" },
                    { 8, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5999), true, null, null, "eee sok no:5 d:22", "Adana", "VWX Kimya", "Türkiye", "zeynep@jkl.com", "Zeynep", "Çelik", "Pazarlama uzmanı", "5328457007", "Pazarlama Direktörü", "99887" },
                    { 9, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(6001), true, null, null, "fff sok no:9 d:24", "Eskişehir", "YZA Medya", "Türkiye", "can@abc.com", "Can", "Demir", "Medya sihirbazı", "5328457008", "Medya Danışmanı", "45567" },
                    { 10, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(6003), true, null, null, "ggg sok no:11 d:26", "Kayseri", "BCD Sigorta", "Türkiye", "eda@def.com", "Eda", "Kırmızı", "Finans uzmanı", "5328457009", "Finansal Danışman", "98765" },
                    { 11, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(6005), true, null, null, "hhh sok no:12 d:28", "Gaziantep", "EFG Turizm", "Türkiye", "cem@ghi.com", "Cem", "Yeşil", "Turizm dehası", "5328457010", "Genel Müdür", "33221" },
                    { 12, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(6055), true, null, null, "iii sok no:15 d:30", "Trabzon", "HIJ Sağlık", "Türkiye", "murat@jkl.com", "Murat", "Altın", "Sağlık uzmanı", "5328457011", "Sağlık Direktörü", "44122" },
                    { 13, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(6057), true, null, null, "jjj sok no:13 d:32", "Muğla", "KLM Mühendislik", "Türkiye", "gul@abc.com", "Gül", "Deniz", "Mühendislik sihirbazı", "5328457012", "Baş Mühendis", "55667" },
                    { 14, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(6060), true, null, null, "kkk sok no:17 d:34", "Mersin", "NOP Emlak", "Türkiye", "selim@def.com", "Selim", "Toprak", "Emlak ustası", "5328457013", "Emlak Danışmanı", "66543" },
                    { 15, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(6063), true, null, null, "lll sok no:19 d:36", "Samsun", "QRS İnşaat", "Türkiye", "tuba@ghi.com", "Tuba", "Aslan", "Şantiye uzmanı", "5328457014", "Şantiye Şefi", "77755" }
                });

            migrationBuilder.InsertData(
                table: "CompanyBranches",
                columns: new[] { "Id", "Address", "BranchCode", "BranchName", "CommissionAmount", "CommissionRate", "CreatedBy", "CreatedDate", "DefaultShrinkageRate", "Email", "Fax", "IsActive", "IsAutomationIntegrationEnabled", "IsHeadOffice", "IsSalesEnabled", "LastModifiedBy", "LastModifiedDate", "Phone" },
                values: new object[] { 1, "Merkez", "S001", "Ana Şube (Patron)", 0m, 0.00m, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5610), 0.0m, "info@Velorus.com", "555-5678", true, true, true, true, null, null, "555-1234" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "CreatedBy", "CreatedDate", "Icon", "LastModifiedBy", "LastModifiedDate", "ParentMenuId", "Title", "Url" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5880), "home", null, null, null, "Dashboard", "/dashboard" },
                    { 2, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5885), "settings", null, null, null, "Settings", "/settings" }
                });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "UserId", "CreatedBy", "CreatedDate", "Email", "IsActive", "LastModifiedBy", "LastModifiedDate", "PasswordHash", "UserName" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5807), "admin@example.com", true, null, null, "hashedpassword", "admin" },
                    { 2, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5810), "user@example.com", true, null, null, "hashedpassword", "user" }
                });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5837), null, null, "Administrators" },
                    { 2, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5848), null, null, "Users" }
                });

            migrationBuilder.InsertData(
                table: "MenuPermissions",
                columns: new[] { "MenuPermissionId", "CanDelete", "CanEdit", "CanExcel", "CanPdf", "CanView", "CanWord", "CreatedBy", "CreatedDate", "GroupId", "LastModifiedBy", "LastModifiedDate", "MenuId", "UserAccountId" },
                values: new object[,]
                {
                    { 1, true, true, true, true, true, true, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5912), null, null, null, 1, 1 },
                    { 2, false, false, false, false, true, false, null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5915), null, null, null, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserAccountGroups",
                columns: new[] { "GroupId", "UserAccountId", "AssignedDate", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5943), null, null },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 9, 17, 7, 45, 35, 617, DateTimeKind.Utc).AddTicks(5944), null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermissions_GroupId",
                table: "MenuPermissions",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermissions_MenuId",
                table: "MenuPermissions",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermissions_UserAccountId",
                table: "MenuPermissions",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ParentMenuId",
                table: "Menus",
                column: "ParentMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountGroups_GroupId",
                table: "UserAccountGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranches_BranchId",
                table: "UserBranches",
                column: "BranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AngularCustomers");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "MenuPermissions");

            migrationBuilder.DropTable(
                name: "UserAccountGroups");

            migrationBuilder.DropTable(
                name: "UserBranches");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "CompanyBranches");

            migrationBuilder.DropTable(
                name: "UserAccounts");
        }
    }
}
