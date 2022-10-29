using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveMom.IdentityApp.Migrations
{
    public partial class intial_create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUserRole = table.Column<bool>(type: "bit", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IdentityDocumentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Category", "ConcurrencyStamp", "Discriminator", "IsUserRole", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1829528e-4314-4ed2-a05a-57418fe7c872", "Manager", "842f06a1-18e6-43a3-8bd5-abada0d1fdaa", "AppRole", true, "Ministry ", "Ministry" },
                    { "1c773b50-f979-41c9-9209-e2f8b00501f4", "Admin", "234669ca-39c5-46ba-8e56-a34c11784ddb", "AppRole", false, "SubAdmin", "SubAdmin" },
                    { "6b1bdb24-0c40-4fa1-a5d8-52e147ea1ebb", "User", "18755597-02d9-454c-b4d8-5b230b14fbd1", "AppRole", true, "Doctor", "Doctor" },
                    { "94108f28-b9ac-4ad0-a069-c3ab8613aff3", "Admin", "f35f1c71-a7ce-46c1-8dc5-790bb1c44795", "AppRole", false, "Admin", "Admin" },
                    { "a099b82e-40eb-4aaa-915a-d6a43052077b", "User", "26fa685c-2373-44ea-9a31-0ca0991752a5", "AppRole", true, "HealthCareProvider", "Health Care Provider" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "IdentityDocumentUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "00bcc664-8e54-49cf-bd26-13796fc2ec05", 0, "282d40a4-81de-4651-b7f9-d9fac708e9f7", "AppUser", "GENEVA.MILLS54@GMAIL.COM", true, "Geneva", null, "Mills", false, null, null, "GENEVA.MILLS54@GMAIL.COM", "AQAAAAEAACcQAAAAEJEMWlkMFxTxyajwZKSOCJHPkUqcCJY2OjUgyqIYNkCZdAnXFXv8hZj7Q27YWmygGA==", null, false, "a15a3a1f-3667-415f-90cd-f1ac68522b4d", false, "Geneva.Mills54@gmail.com" },
                    { "09973040-681e-4b7e-91d8-5daa2fc37c45", 0, "1e49bee5-767f-4adb-8a73-d5bafa7227a2", "AppUser", "IRVIN75@GMAIL.COM", false, "Irvin", null, "Pacocha", false, null, null, "IRVIN75@GMAIL.COM", "AQAAAAEAACcQAAAAEFLXO7w/mfbWx73w2detc0Lx8JUTRyiMDXz8cGMrnnvYkHQBF/XXuVNhSJaLNHozLg==", null, false, "6fd24e67-9193-4521-821a-c4dd2976dc04", false, "Irvin75@gmail.com" },
                    { "3c71d3a3-cc24-4ebd-bd29-943c2086bc12", 0, "35dae5ae-d616-4fd2-8959-946da9ef3a38", "AppUser", "NICHOLAS21@YAHOO.COM", true, "Nicholas", null, "Boehm", false, null, null, "NICHOLAS21@YAHOO.COM", "AQAAAAEAACcQAAAAEC+LxKPyE97Db2AW8SMiu2jY50bERwfZYreiECoeP+J+oXF3ic7TAX6MQwKRx3PPQQ==", null, false, "b263fc3a-d9cc-4be9-a40e-98153aabd111", false, "Nicholas21@yahoo.com" },
                    { "b4e1609e-d661-4a9d-97b4-abd1220b05a7", 0, "0f5355b8-5866-4176-a256-dc45b9e810e9", "AppUser", "OMAR_MILLS@HOTMAIL.COM", false, "Omar", null, "Mills", false, null, null, "OMAR_MILLS@HOTMAIL.COM", "AQAAAAEAACcQAAAAEAR8euRF4enlSwYcxb6FaEfGmnRAkQx727azL3KMksKX8k3VcWVc4PTEhwD6wUr7SQ==", null, false, "6653805d-b7cc-425e-bc4d-b3087f1e27e7", false, "Omar_Mills@hotmail.com" },
                    { "b70a2f8a-7869-4482-9cb9-3abeca6ba1da", 0, "3850f064-c785-4839-883d-eb8e0ebd0be2", "AppUser", "DEBRA.RAU@HOTMAIL.COM", true, "Debra", null, "Rau", false, null, null, "DEBRA.RAU@HOTMAIL.COM", "AQAAAAEAACcQAAAAEMuRmiXX/SJvJODN3sH9wa0PO1LWdS1fnQmHdZ/z+xVJYYpXtgsxXIyOtsdeRKGKiQ==", null, false, "a20fc75b-5d1e-40bc-9a35-dc24d9c3577e", false, "Debra.Rau@hotmail.com" }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
