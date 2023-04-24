using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewsPortal.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsArticles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsArticles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sports" },
                    { 2, "Technology" },
                    { 3, "Health" },
                    { 4, "Environments" },
                    { 5, "Politics" },
                    { 6, "Weather" }
                });

            migrationBuilder.InsertData(
                table: "NewsArticles",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "Title", "UpdatedDateTime" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3087), "The COVID-19 vaccine rollout has now been expanded to include teens aged 16 and 17, with many states and cities beginning to offer appointments.", "COVID-19 vaccine rollout expands to teens", new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3104) },
                    { 2, 6, new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3124), "Parts of the western United States are experiencing a record-breaking heatwave, with temperatures reaching over 100 degrees Fahrenheit in many areas.", "Record-breaking heatwave hits western United States", new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3125) },
                    { 3, 3, new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3141), "A new study has found that practicing meditation regularly can have significant positive effects on mental health, including reducing symptoms of anxiety and depression.", "New study shows benefits of meditation on mental health", new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3142) },
                    { 4, 4, new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3157), "The government has announced a new round of funding for renewable energy projects, with a focus on solar and wind power.", "Government announces new funding for renewable energy projects", new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3158) },
                    { 5, 4, new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3172), "A new report has highlighted the growing impact of climate change on the global food supply, with experts warning of potential shortages and price increases.", "New report highlights effects of climate change on global food supply", new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3173) },
                    { 6, 3, new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3188), "A new study has found a significant link between exposure to air pollution and an increased risk of cardiovascular disease, including heart attacks and strokes.", "New study finds link between air pollution and cardiovascular disease", new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3189) },
                    { 7, 2, new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3204), "A technology company has unveiled a new smartphone with advanced features, including a foldable screen and 5G connectivity.", "Technology company unveils new smartphone with advanced features", new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3205) },
                    { 8, 1, new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3220), "An athlete has broken the world record in a track and field event, setting a new standard for performance in the sport.", "Athlete breaks world record in track and field event", new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3220) },
                    { 9, 2, new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3236), "SpaceX launched a Falcon 9 rocket carrying 60 Starlink internet satellites into orbit from Florida's Cape Canaveral Space Force Station on Monday.", "SpaceX successfully launches Falcon 9 rocket", new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3236) },
                    { 10, 4, new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3252), "Protests demanding action on climate change have erupted in major cities around the world, with thousands of people taking to the streets.", "Climate change protests erupt in major cities around the world", new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3253) },
                    { 11, 2, new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3268), "Apple has announced a new iPhone model that features a foldable screen, allowing users to have a larger display when needed.", "Apple announces new iPhone with foldable screen", new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3268) },
                    { 12, 5, new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3284), "The United Nations has condemned Myanmar's military for human rights violations against the Rohingya minority, including rape, torture, and murder.", "UN condemns Myanmar's military for human rights violations", new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3285) },
                    { 13, 5, new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3300), "Protests demanding action on climate change have erupted in major cities around the world, with thousands of people taking to the streets.", "Climate change protests erupt in major cities around the world", new DateTime(2023, 4, 23, 22, 10, 3, 777, DateTimeKind.Local).AddTicks(3301) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "NewsArticles");
        }
    }
}
