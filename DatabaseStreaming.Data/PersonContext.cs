using Microsoft.EntityFrameworkCore;

namespace DatabaseStreaming.Data
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> People => Set<Person>();

        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)
        {
        }
    }
}
