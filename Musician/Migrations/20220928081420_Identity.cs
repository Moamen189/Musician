using Microsoft.EntityFrameworkCore.Migrations;

namespace Musician.Migrations
{
    public partial class Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentMusiciann_Instruments_InstrumentsName",
                table: "InstrumentMusiciann");

            migrationBuilder.DropForeignKey(
                name: "FK_MusiciannSong_Songs_SongsTitle",
                table: "MusiciannSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Songs",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusiciannSong",
                table: "MusiciannSong");

            migrationBuilder.DropIndex(
                name: "IX_MusiciannSong_SongsTitle",
                table: "MusiciannSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instruments",
                table: "Instruments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstrumentMusiciann",
                table: "InstrumentMusiciann");

            migrationBuilder.DropColumn(
                name: "SongsTitle",
                table: "MusiciannSong");

            migrationBuilder.DropColumn(
                name: "InstrumentsName",
                table: "InstrumentMusiciann");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SongsId",
                table: "MusiciannSong",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Instruments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Instruments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "InstrumentsId",
                table: "InstrumentMusiciann",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Songs",
                table: "Songs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusiciannSong",
                table: "MusiciannSong",
                columns: new[] { "MusiciansId", "SongsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instruments",
                table: "Instruments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstrumentMusiciann",
                table: "InstrumentMusiciann",
                columns: new[] { "InstrumentsId", "MusiciansId" });

            migrationBuilder.CreateIndex(
                name: "IX_MusiciannSong_SongsId",
                table: "MusiciannSong",
                column: "SongsId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentMusiciann_Instruments_InstrumentsId",
                table: "InstrumentMusiciann",
                column: "InstrumentsId",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusiciannSong_Songs_SongsId",
                table: "MusiciannSong",
                column: "SongsId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentMusiciann_Instruments_InstrumentsId",
                table: "InstrumentMusiciann");

            migrationBuilder.DropForeignKey(
                name: "FK_MusiciannSong_Songs_SongsId",
                table: "MusiciannSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Songs",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusiciannSong",
                table: "MusiciannSong");

            migrationBuilder.DropIndex(
                name: "IX_MusiciannSong_SongsId",
                table: "MusiciannSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instruments",
                table: "Instruments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstrumentMusiciann",
                table: "InstrumentMusiciann");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "SongsId",
                table: "MusiciannSong");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "InstrumentsId",
                table: "InstrumentMusiciann");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Songs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SongsTitle",
                table: "MusiciannSong",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Instruments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstrumentsName",
                table: "InstrumentMusiciann",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Songs",
                table: "Songs",
                column: "Title");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusiciannSong",
                table: "MusiciannSong",
                columns: new[] { "MusiciansId", "SongsTitle" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instruments",
                table: "Instruments",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstrumentMusiciann",
                table: "InstrumentMusiciann",
                columns: new[] { "InstrumentsName", "MusiciansId" });

            migrationBuilder.CreateIndex(
                name: "IX_MusiciannSong_SongsTitle",
                table: "MusiciannSong",
                column: "SongsTitle");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentMusiciann_Instruments_InstrumentsName",
                table: "InstrumentMusiciann",
                column: "InstrumentsName",
                principalTable: "Instruments",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusiciannSong_Songs_SongsTitle",
                table: "MusiciannSong",
                column: "SongsTitle",
                principalTable: "Songs",
                principalColumn: "Title",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
