using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TAL.PremiumCalculator.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OccupationRatings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Factor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccupationRatings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Occupations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OccupationRatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Occupations_OccupationRatings_OccupationRatingId",
                        column: x => x.OccupationRatingId,
                        principalTable: "OccupationRatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OccupationRatings",
                columns: new[] { "Id", "Factor", "Name" },
                values: new object[,]
                {
                    { new Guid("25569b64-452b-40dd-b8f8-59b9eb239158"), 1.5, "Light Manual" },
                    { new Guid("7e98cc49-cfdd-4c05-ab68-6d72f8989d3f"), 1.75, "Heavy Manual" },
                    { new Guid("7f907568-0c7c-40b0-8782-fc99efdcd553"), 1.0, "Professional" },
                    { new Guid("b7209ddc-eb32-4643-a797-bd11647f04f5"), 1.25, "White Collar" }
                });

            migrationBuilder.InsertData(
                table: "Occupations",
                columns: new[] { "Id", "Name", "OccupationRatingId" },
                values: new object[,]
                {
                    { new Guid("0e25daed-d9e1-45ec-9f4c-4395c876de98"), "Farmer", new Guid("7e98cc49-cfdd-4c05-ab68-6d72f8989d3f") },
                    { new Guid("31c956d2-9d13-4b1c-b38a-233b3b3a8914"), "Cleaner", new Guid("25569b64-452b-40dd-b8f8-59b9eb239158") },
                    { new Guid("35daebfb-58da-4bdd-8a49-7dd58d344d01"), "Doctor", new Guid("7f907568-0c7c-40b0-8782-fc99efdcd553") },
                    { new Guid("6990e2de-8a01-401b-86ff-9b0bb83415f3"), "Author", new Guid("b7209ddc-eb32-4643-a797-bd11647f04f5") },
                    { new Guid("a8a5224a-d571-4948-b2cf-a418f00be2d8"), "Florist", new Guid("25569b64-452b-40dd-b8f8-59b9eb239158") },
                    { new Guid("d01375c9-7c2a-4ffa-b78b-38dd3d73e13e"), "Mechanic", new Guid("7e98cc49-cfdd-4c05-ab68-6d72f8989d3f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Occupations_OccupationRatingId",
                table: "Occupations",
                column: "OccupationRatingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Occupations");

            migrationBuilder.DropTable(
                name: "OccupationRatings");
        }
    }
}
