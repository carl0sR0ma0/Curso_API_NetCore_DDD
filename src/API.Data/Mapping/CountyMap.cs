using Domain.Configuration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class CountyMap : IEntityTypeConfiguration<CountyEntity>
    {
        public void Configure(EntityTypeBuilder<CountyEntity> builder)
        {
            builder.ToTable("County");

            builder.HasKey(m => m.Id);

            builder.HasIndex(m => m.CodeIBGE);

            builder.HasOne(m => m.UF).WithMany(u => u.Counties);

            if (Configuration.GetConfiguration().DATABASE.ToLower().Equals("Postgres".ToLower()))
            {
                builder.Property(m => m.CreateAt).HasColumnType("timestamp without time zone");
                builder.Property(m => m.UpdateAt).HasColumnType("timestamp without time zone");
            }
        }
    }
}
