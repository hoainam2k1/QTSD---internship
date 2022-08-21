using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace QTSD_internship
{
    public class Context : DbContext
    {
        private readonly string connectionString;
        private readonly ILoggerFactory loggerFactory = LoggerFactory.Create(configure => configure.AddConsole());
        public Context(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public DbSet<Employees> employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
