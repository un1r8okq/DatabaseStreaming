using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DatabaseStreaming.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AvatarUrl = table.Column<string>(type: "text", nullable: false),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            var faker = new Bogus.Faker();
            const int numBatches = 100;
            const int batchSize = 1_000;

            var data = new object[batchSize, 6];

            for (var i = 0; i < numBatches; i++)
            {
                for (var j = i; j < batchSize; j++)
                {
                    data[j, 0] = faker.Name.FullName();
                    data[j, 1] = faker.Internet.Avatar();
                    data[j, 2] = faker.Date.Past(100).ToUniversalTime();
                    data[j, 3] = faker.Address.FullAddress();
                    data[j, 4] = faker.Phone.PhoneNumber();
                    data[j, 5] = faker.Lorem.Sentence(3, 10);
                }

                migrationBuilder.InsertData(
                    table: "People",
                    columns: new[] { "Name", "AvatarUrl", "Birthday", "Address", "Phone", "Notes" },
                    values: data);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
