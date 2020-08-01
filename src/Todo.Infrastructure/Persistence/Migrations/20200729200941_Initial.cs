using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Todo.Infrastructure.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    EstimatedCompletionTime = table.Column<DateTime>(nullable: false),
                    Completed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Completed", "Created", "Description", "EstimatedCompletionTime", "Modified", "Priority", "Title" },
                values: new object[,]
                {
                    { new Guid("8419d158-65f0-4978-b279-9b870c1d2b3a"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "You do it like a hive", new DateTime(2020, 8, 1, 20, 9, 41, 105, DateTimeKind.Utc).AddTicks(2357), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "I like the way you drive" },
                    { new Guid("a67906bc-2f3a-435e-a965-7d96a1322bd3"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Imagine all the people", new DateTime(2020, 7, 31, 20, 9, 41, 105, DateTimeKind.Utc).AddTicks(2747), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "I want to hold your mug" },
                    { new Guid("55d25821-16f7-428b-8a25-de1367cfa561"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blue fire engine, blue fire engine", new DateTime(2020, 8, 3, 20, 9, 41, 105, DateTimeKind.Utc).AddTicks(2762), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "All you need is global domination" },
                    { new Guid("692c9781-8dd3-44b4-9cd9-6ef9bdb547ed"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "I think you'll understand", new DateTime(2020, 8, 5, 20, 9, 41, 105, DateTimeKind.Utc).AddTicks(2765), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "We all live in our violet coach" },
                    { new Guid("fb97d138-a22d-413a-b8cf-5ccd1962729b"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "But I'm not the only one", new DateTime(2020, 8, 10, 20, 9, 41, 105, DateTimeKind.Utc).AddTicks(2766), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Above us only poker chips" },
                    { new Guid("f363c032-1ebe-4d0c-af42-8f20b8bd3183"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oh yeah!", new DateTime(2020, 8, 13, 20, 9, 41, 105, DateTimeKind.Utc).AddTicks(2807), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "You'll let me learn to fly" },
                    { new Guid("5baf1d63-a9fa-4c84-9462-edd19cfa46f8"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "And I'm gonna move your key", new DateTime(2020, 8, 8, 20, 9, 41, 105, DateTimeKind.Utc).AddTicks(2819), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "I never thought I'd see that stick" },
                    { new Guid("f0e46c6c-01be-4320-b757-f9da53005917"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yea, yaz, in a Houston state of mind", new DateTime(2020, 8, 5, 20, 9, 41, 105, DateTimeKind.Utc).AddTicks(2821), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "The joystick drops deep as does my light" },
                    { new Guid("5a4fca27-0652-41ad-8295-5a9f7a0eede1"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "In a Houston state of mind", new DateTime(2020, 8, 7, 20, 9, 41, 105, DateTimeKind.Utc).AddTicks(2823), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "I never snooze, 'cause to snooze is the husband of site" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}