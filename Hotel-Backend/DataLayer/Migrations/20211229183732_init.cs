using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_card_number = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Room_Number = table.Column<int>(type: "int", nullable: false),
                    Room_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Room_Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Room_Number);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Guest_ID = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Hotel_Room_Number = table.Column<int>(type: "int", nullable: false),
                    CheckIn_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => new { x.Guest_ID, x.Hotel_Room_Number, x.CheckIn_date });
                    table.ForeignKey(
                        name: "FK_Reservations_Guests_Guest_ID",
                        column: x => x.Guest_ID,
                        principalTable: "Guests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_Hotel_Room_Number",
                        column: x => x.Hotel_Room_Number,
                        principalTable: "Rooms",
                        principalColumn: "Room_Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Hotel_Room_Number",
                table: "Reservations",
                column: "Hotel_Room_Number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
