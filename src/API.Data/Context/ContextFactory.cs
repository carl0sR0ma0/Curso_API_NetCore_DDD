using Domain.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Text.Json;

namespace Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "API.Environment", "DbSettings.json");

            var jsonContent = File.ReadAllText(filePath);
            var dbSettings = JsonSerializer.Deserialize<DbSettings>(jsonContent);

            string? connectionString;
            var optionBuilder = new DbContextOptionsBuilder<MyContext>();

            if (dbSettings.DATABASE.ToLower().Equals("Postgres".ToLower()))
            {
                connectionString = dbSettings.DB_CONNECTION_PG;
                optionBuilder.UseNpgsql(connectionString);
            }
            else
            {
                connectionString = dbSettings.DB_CONNECTION_SS;
                optionBuilder.UseSqlServer(connectionString);
            }
            return new MyContext(optionBuilder.Options);
        }
    }
}
