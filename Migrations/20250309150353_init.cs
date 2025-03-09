using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REST_API_CV_Hantering.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Beskrivning = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Kontaktuppgifter = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Arbetserfarenheter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jobbtitel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Företag = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Beskrivning = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Arbetsår = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbetserfarenheter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arbetserfarenheter_Personer_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Personer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utbildningar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skola = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Examen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlutDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utbildningar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utbildningar_Personer_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Personer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arbetserfarenheter_PersonId",
                table: "Arbetserfarenheter",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Utbildningar_PersonId",
                table: "Utbildningar",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arbetserfarenheter");

            migrationBuilder.DropTable(
                name: "Utbildningar");

            migrationBuilder.DropTable(
                name: "Personer");
        }
    }
}
