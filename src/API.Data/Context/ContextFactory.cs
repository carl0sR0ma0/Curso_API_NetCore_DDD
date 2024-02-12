using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            // Usado para Criar as Migrações
            var connectionString = "Server=127.0.0.1;Port=5432;Pooling=false;Database=dbAPI;User Id=postgres;Password=pentabr0610;";
            var optionBuilder = new DbContextOptionsBuilder<MyContext>();
            optionBuilder.UseNpgsql(connectionString);
            return new MyContext(optionBuilder.Options);
        }
    }
}
