using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BadgemaniaAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Badgegroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badgegroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
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
                name: "Badgetypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BadgegroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badgetypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Badgetypes_Badgegroups_BadgegroupId",
                        column: x => x.BadgegroupId,
                        principalTable: "Badgegroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SchoolId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Badges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    BadgeImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BadgetypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BadgegroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Badges_Badgegroups_BadgegroupId",
                        column: x => x.BadgegroupId,
                        principalTable: "Badgegroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Badges_Badgetypes_BadgetypeId",
                        column: x => x.BadgetypeId,
                        principalTable: "Badgetypes",
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
                name: "CustomUserBadgegroups",
                columns: table => new
                {
                    CustomUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BadgegroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomUserBadgegroups", x => new { x.CustomUserId, x.BadgegroupId });
                    table.ForeignKey(
                        name: "FK_CustomUserBadgegroups_AspNetUsers_CustomUserId",
                        column: x => x.CustomUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomUserBadgegroups_Badgegroups_BadgegroupId",
                        column: x => x.BadgegroupId,
                        principalTable: "Badgegroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomUserBadges",
                columns: table => new
                {
                    CustomUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BadgeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomUserBadges", x => new { x.CustomUserId, x.BadgeId });
                    table.ForeignKey(
                        name: "FK_CustomUserBadges_AspNetUsers_CustomUserId",
                        column: x => x.CustomUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomUserBadges_Badges_BadgeId",
                        column: x => x.BadgeId,
                        principalTable: "Badges",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "30cfae89-ac70-4d27-a033-384bf4287716", "30cfae89-ac70-4d27-a033-384bf4287716", "SuperAdmin", "SUPERADMIN" },
                    { "71c497af-4809-40f2-82c2-c770eb00150a", "71c497af-4809-40f2-82c2-c770eb00150a", "SchoolAdmin", "SCHOOLADMIN" },
                    { "82f4b7a1-c728-4522-a51d-04741cdeee2a", "82f4b7a1-c728-4522-a51d-04741cdeee2a", "Teacher", "TEACHER" },
                    { "f378e6ae-dbb3-415f-83ce-e069d4c16073", "f378e6ae-dbb3-415f-83ce-e069d4c16073", "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("213b864f-c265-491c-a2cb-77038bc93e26"), "Väggaskolan" },
                    { new Guid("d8628307-3d6c-49bc-8c41-d53c482b1b93"), "Aleholmsskolan" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SchoolId", "SecurityStamp", "TokenExpires", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5f0da40b-c93e-4227-8747-45eaa53ccc78", 0, "d732f560-f309-4c5e-9f92-d9ce7bc99a35", "vagga@teacher1.com", true, false, null, "VAGGA@TEACHER1.COM", "VAGGA@TEACHER1.COM", "AQAAAAIAAYagAAAAEJUYOZCIj6sIyGecfASrWwxODcJdm4/BAfo+bITcrdsxIzFrjkjzmmh0XR4b1UxBMw==", null, false, "", new Guid("213b864f-c265-491c-a2cb-77038bc93e26"), "401f786f-4709-44a4-8d65-b2cb1e9e77ea", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "vagga@teacher1.com" },
                    { "b383d2b5-5786-4188-b1b7-248ea6533cd9", 0, "57db5a88-a4d7-43e4-88b9-e4ee41777fbd", "vagga@admin.com", true, false, null, "VAGGA@ADMIN.COM", "VAGGA@ADMIN.COM", "AQAAAAIAAYagAAAAEHDJzdMJNB+KQKe+QxuJDh/jLYcLkoOzYRHvWSR4JYsc7Z8nFqBCA9FPSqsD06dp8A==", null, false, "", new Guid("213b864f-c265-491c-a2cb-77038bc93e26"), "5ec2136b-c606-4d7c-8f5c-37e684cf11aa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "vagga@admin.com" },
                    { "ea5d94ef-655a-4565-bde4-f2098d4f81d1", 0, "5a71d8be-6228-40f6-8349-353cbdf16dbb", "vagga@student1.com", true, false, null, "VAGGA@STUDENT1.COM", "VAGGA@STUDENT1.COM", "AQAAAAIAAYagAAAAEIIXifWl5wHi7ecsmwNN/FGI30+IqOK2tMp+Y93sIne2X9LLdlVY+F3UOSj4P8UtHg==", null, false, "", new Guid("213b864f-c265-491c-a2cb-77038bc93e26"), "6a86ba86-703a-462c-898c-15b367d9f324", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "vagga@student1.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "82f4b7a1-c728-4522-a51d-04741cdeee2a", "5f0da40b-c93e-4227-8747-45eaa53ccc78" },
                    { "71c497af-4809-40f2-82c2-c770eb00150a", "b383d2b5-5786-4188-b1b7-248ea6533cd9" },
                    { "f378e6ae-dbb3-415f-83ce-e069d4c16073", "ea5d94ef-655a-4565-bde4-f2098d4f81d1" }
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
                name: "IX_AspNetUsers_SchoolId",
                table: "AspNetUsers",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Badges_BadgegroupId",
                table: "Badges",
                column: "BadgegroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Badges_BadgetypeId",
                table: "Badges",
                column: "BadgetypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Badgetypes_BadgegroupId",
                table: "Badgetypes",
                column: "BadgegroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomUserBadgegroups_BadgegroupId",
                table: "CustomUserBadgegroups",
                column: "BadgegroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomUserBadges_BadgeId",
                table: "CustomUserBadges",
                column: "BadgeId");
        }

        /// <inheritdoc />
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
                name: "CustomUserBadgegroups");

            migrationBuilder.DropTable(
                name: "CustomUserBadges");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Badges");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Badgetypes");

            migrationBuilder.DropTable(
                name: "Badgegroups");
        }
    }
}
