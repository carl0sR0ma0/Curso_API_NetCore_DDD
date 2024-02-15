using Data.Mapping;
using Data.Seeds;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UFEntity> UF { get; set; }
        public DbSet<MunicipioEntity> Municipios { get; set; }
        public DbSet<CepEntity> Ceps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<UFEntity>(new UfMap().Configure);
            modelBuilder.Entity<MunicipioEntity>(new MunicipioMap().Configure);
            modelBuilder.Entity<CepEntity>(new CepMap().Configure);

            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = "Administrator",
                Email = "user.adm@mfrinfo.com",
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            });

            UFSeeds.UFs(modelBuilder);
        }
    }
}
