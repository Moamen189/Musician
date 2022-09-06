using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Musician.Migrations
{
    public partial class ComleteDAL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Musicians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicians", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MusicianId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Musicians_MusicianId",
                        column: x => x.MusicianId,
                        principalTable: "Musicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentMusiciann",
                columns: table => new
                {
                    InstrumentsName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    MusiciansId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentMusiciann", x => new { x.InstrumentsName, x.MusiciansId });
                    table.ForeignKey(
                        name: "FK_InstrumentMusiciann_Instruments_InstrumentsName",
                        column: x => x.InstrumentsName,
                        principalTable: "Instruments",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstrumentMusiciann_Musicians_MusiciansId",
                        column: x => x.MusiciansId,
                        principalTable: "Musicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlbumSongs",
                columns: table => new
                {
                    TitleSong = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumSongs", x => x.TitleSong);
                    table.ForeignKey(
                        name: "FK_AlbumSongs_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AlbumSongTitleSong = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Title);
                    table.ForeignKey(
                        name: "FK_Songs_AlbumSongs_AlbumSongTitleSong",
                        column: x => x.AlbumSongTitleSong,
                        principalTable: "AlbumSongs",
                        principalColumn: "TitleSong",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MusiciannSong",
                columns: table => new
                {
                    MusiciansId = table.Column<int>(type: "int", nullable: false),
                    SongsTitle = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusiciannSong", x => new { x.MusiciansId, x.SongsTitle });
                    table.ForeignKey(
                        name: "FK_MusiciannSong_Musicians_MusiciansId",
                        column: x => x.MusiciansId,
                        principalTable: "Musicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusiciannSong_Songs_SongsTitle",
                        column: x => x.SongsTitle,
                        principalTable: "Songs",
                        principalColumn: "Title",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_MusicianId",
                table: "Albums",
                column: "MusicianId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumSongs_AlbumId",
                table: "AlbumSongs",
                column: "AlbumId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentMusiciann_MusiciansId",
                table: "InstrumentMusiciann",
                column: "MusiciansId");

            migrationBuilder.CreateIndex(
                name: "IX_MusiciannSong_SongsTitle",
                table: "MusiciannSong",
                column: "SongsTitle");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumSongTitleSong",
                table: "Songs",
                column: "AlbumSongTitleSong");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstrumentMusiciann");

            migrationBuilder.DropTable(
                name: "MusiciannSong");

            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "AlbumSongs");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Musicians");
        }
    }
}
