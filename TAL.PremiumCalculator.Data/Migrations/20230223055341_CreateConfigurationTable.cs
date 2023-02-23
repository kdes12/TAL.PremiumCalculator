using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TAL.PremiumCalculator.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateConfigurationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Occupations",
                keyColumn: "Id",
                keyValue: new Guid("0e25daed-d9e1-45ec-9f4c-4395c876de98"));

            migrationBuilder.DeleteData(
                table: "Occupations",
                keyColumn: "Id",
                keyValue: new Guid("31c956d2-9d13-4b1c-b38a-233b3b3a8914"));

            migrationBuilder.DeleteData(
                table: "Occupations",
                keyColumn: "Id",
                keyValue: new Guid("35daebfb-58da-4bdd-8a49-7dd58d344d01"));

            migrationBuilder.DeleteData(
                table: "Occupations",
                keyColumn: "Id",
                keyValue: new Guid("6990e2de-8a01-401b-86ff-9b0bb83415f3"));

            migrationBuilder.DeleteData(
                table: "Occupations",
                keyColumn: "Id",
                keyValue: new Guid("a8a5224a-d571-4948-b2cf-a418f00be2d8"));

            migrationBuilder.DeleteData(
                table: "Occupations",
                keyColumn: "Id",
                keyValue: new Guid("d01375c9-7c2a-4ffa-b78b-38dd3d73e13e"));

            migrationBuilder.DeleteData(
                table: "OccupationRatings",
                keyColumn: "Id",
                keyValue: new Guid("25569b64-452b-40dd-b8f8-59b9eb239158"));

            migrationBuilder.DeleteData(
                table: "OccupationRatings",
                keyColumn: "Id",
                keyValue: new Guid("7e98cc49-cfdd-4c05-ab68-6d72f8989d3f"));

            migrationBuilder.DeleteData(
                table: "OccupationRatings",
                keyColumn: "Id",
                keyValue: new Guid("7f907568-0c7c-40b0-8782-fc99efdcd553"));

            migrationBuilder.DeleteData(
                table: "OccupationRatings",
                keyColumn: "Id",
                keyValue: new Guid("b7209ddc-eb32-4643-a797-bd11647f04f5"));

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    MaximumAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.InsertData(
                table: "OccupationRatings",
                columns: new[] { "Id", "Factor", "Name" },
                values: new object[,]
                {
                    { new Guid("17de5b02-2888-401a-ae29-d58ddf9038e4"), 1.0, "Professional" },
                    { new Guid("2e10167b-e895-4b3e-b557-bb9d164d8056"), 1.5, "Light Manual" },
                    { new Guid("35cf2054-e109-41d1-baca-62bb83a1885d"), 1.25, "White Collar" },
                    { new Guid("ef7f0408-0bc4-4451-81d1-6f3b322d4c0d"), 1.75, "Heavy Manual" }
                });

            migrationBuilder.InsertData(
                table: "Occupations",
                columns: new[] { "Id", "Name", "OccupationRatingId" },
                values: new object[,]
                {
                    { new Guid("1b766802-8d51-4c77-b98b-1c48217437c6"), "Farmer", new Guid("ef7f0408-0bc4-4451-81d1-6f3b322d4c0d") },
                    { new Guid("51546ab8-19e5-4334-966f-e4d67efb3806"), "Author", new Guid("35cf2054-e109-41d1-baca-62bb83a1885d") },
                    { new Guid("5a5e144c-96fb-4a22-adad-1517a61b7bd0"), "Doctor", new Guid("17de5b02-2888-401a-ae29-d58ddf9038e4") },
                    { new Guid("c11e48a1-b920-4aa3-94c4-0b8ca279f16a"), "Florist", new Guid("2e10167b-e895-4b3e-b557-bb9d164d8056") },
                    { new Guid("c7dbca9d-e209-4b48-8ced-0e27969e84a9"), "Mechanic", new Guid("ef7f0408-0bc4-4451-81d1-6f3b322d4c0d") },
                    { new Guid("fc9a7ff0-38f2-4a0b-9bd0-a4d927eb211e"), "Cleaner", new Guid("2e10167b-e895-4b3e-b557-bb9d164d8056") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DeleteData(
                table: "Occupations",
                keyColumn: "Id",
                keyValue: new Guid("1b766802-8d51-4c77-b98b-1c48217437c6"));

            migrationBuilder.DeleteData(
                table: "Occupations",
                keyColumn: "Id",
                keyValue: new Guid("51546ab8-19e5-4334-966f-e4d67efb3806"));

            migrationBuilder.DeleteData(
                table: "Occupations",
                keyColumn: "Id",
                keyValue: new Guid("5a5e144c-96fb-4a22-adad-1517a61b7bd0"));

            migrationBuilder.DeleteData(
                table: "Occupations",
                keyColumn: "Id",
                keyValue: new Guid("c11e48a1-b920-4aa3-94c4-0b8ca279f16a"));

            migrationBuilder.DeleteData(
                table: "Occupations",
                keyColumn: "Id",
                keyValue: new Guid("c7dbca9d-e209-4b48-8ced-0e27969e84a9"));

            migrationBuilder.DeleteData(
                table: "Occupations",
                keyColumn: "Id",
                keyValue: new Guid("fc9a7ff0-38f2-4a0b-9bd0-a4d927eb211e"));

            migrationBuilder.DeleteData(
                table: "OccupationRatings",
                keyColumn: "Id",
                keyValue: new Guid("17de5b02-2888-401a-ae29-d58ddf9038e4"));

            migrationBuilder.DeleteData(
                table: "OccupationRatings",
                keyColumn: "Id",
                keyValue: new Guid("2e10167b-e895-4b3e-b557-bb9d164d8056"));

            migrationBuilder.DeleteData(
                table: "OccupationRatings",
                keyColumn: "Id",
                keyValue: new Guid("35cf2054-e109-41d1-baca-62bb83a1885d"));

            migrationBuilder.DeleteData(
                table: "OccupationRatings",
                keyColumn: "Id",
                keyValue: new Guid("ef7f0408-0bc4-4451-81d1-6f3b322d4c0d"));

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
        }
    }
}
