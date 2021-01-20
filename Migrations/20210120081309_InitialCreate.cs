using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hostel.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    PasswordHash = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    ReservationCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Reservation = table.Column<bool>(type: "INTEGER", nullable: false),
                    ReservationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BlockName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    RoomNumber = table.Column<string>(type: "TEXT", nullable: true),
                    RoomIdForUser = table.Column<int>(type: "INTEGER", nullable: false),
                    AdmissionNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Lga = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BlockName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    BlockGender = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Occupied = table.Column<bool>(type: "INTEGER", maxLength: 30, nullable: false),
                    Reserved = table.Column<bool>(type: "INTEGER", nullable: false),
                    BlockId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Blocks_BlockId",
                        column: x => x.BlockId,
                        principalTable: "Blocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Blocks",
                columns: new[] { "Id", "BlockGender", "BlockName" },
                values: new object[] { 1, 1, "Block A" });

            migrationBuilder.InsertData(
                table: "Blocks",
                columns: new[] { "Id", "BlockGender", "BlockName" },
                values: new object[] { 2, 1, "Block B" });

            migrationBuilder.InsertData(
                table: "Blocks",
                columns: new[] { "Id", "BlockGender", "BlockName" },
                values: new object[] { 3, 0, "Block C" });

            migrationBuilder.InsertData(
                table: "Blocks",
                columns: new[] { "Id", "BlockGender", "BlockName" },
                values: new object[] { 4, 0, "Block D" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 1, 1, false, false, "Room 1" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 30, 4, false, false, "Room 6" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 29, 4, false, false, "Room 5" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 28, 4, false, false, "Room 4" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 27, 4, false, false, "Room 3" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 26, 4, false, false, "Room 2" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 25, 4, false, false, "Room 1" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 24, 3, false, false, "Room 8" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 23, 3, false, false, "Room 7" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 22, 3, false, false, "Room 6" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 21, 3, false, false, "Room 5" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 20, 3, false, false, "Room 4" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 19, 3, false, false, "Room 3" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 18, 3, false, false, "Room 2" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 17, 3, false, false, "Room 1" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 16, 2, false, false, "Room 8" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 15, 2, false, false, "Room 7" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 14, 2, false, false, "Room 6" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 13, 2, false, false, "Room 5" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 12, 2, false, false, "Room 4" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 11, 2, false, false, "Room 3" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 10, 2, false, false, "Room 2" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 9, 2, false, false, "Room 1" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 8, 1, false, false, "Room 8" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 7, 1, false, false, "Room 7" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 6, 1, false, false, "Room 6" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 5, 1, false, false, "Room 5" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 4, 1, false, false, "Room 4" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 3, 1, false, false, "Room 3" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 2, 1, false, false, "Room 2" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 31, 4, false, false, "Room 7" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BlockId", "Occupied", "Reserved", "RoomName" },
                values: new object[] { 32, 4, false, false, "Room 8" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BlockId",
                table: "Rooms",
                column: "BlockId");
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
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Blocks");
        }
    }
}
