using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace DataAccessLayer
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public DatabaseContextFactory() { }
        public DatabaseContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        public DatabaseContext CreateDbContext(string[] args = null)
        {
            DbContextOptionsBuilder<DatabaseContext> options = new DbContextOptionsBuilder<DatabaseContext>();

            //"Server=localhost\\SQLEXPRESS;Database=SmartClassRoom;Trusted_Connection=True"

            options.EnableSensitiveDataLogging();
            //_configureDbContext(options);
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SmartClassRoom;Trusted_Connection=True");

            return new DatabaseContext(options.Options);
        }
    }
}
