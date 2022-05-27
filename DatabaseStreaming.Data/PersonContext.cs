using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatabaseStreaming.Data
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> People => Set<Person>();

        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost:5432;Password=xJqf1aAUCZkOHr7Z;Username=postgres");
                optionsBuilder.UseLoggerFactory(LoggerFactory.Create(logger =>
                    logger
                        .AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning)
                        .AddConsole()));
            }
        }
    }
}
