using DatabaseStreaming.Data;
using Microsoft.EntityFrameworkCore;

using var dbContext = new PersonContext(
    new DbContextOptionsBuilder<PersonContext>().Options);

var faker = new Bogus.Faker();
const int personCount = 100000;
var people = new Person[personCount];

for (var i = 0; i < personCount; i++)
{
    if (i % 1000 == 0)
    {
        Console.WriteLine(i);
    }

    people[i] = new Person
    {
        Name = faker.Name.FullName(),
        AvatarUrl = faker.Internet.Avatar(),
        Birthday = faker.Date.Past(100),
        Address = faker.Address.FullAddress(),
        Phone = faker.Phone.PhoneNumber(),
        Notes = faker.Lorem.Paragraphs(1, 10),
    };
}

await dbContext.AddRangeAsync(people);
await dbContext.SaveChangesAsync();
