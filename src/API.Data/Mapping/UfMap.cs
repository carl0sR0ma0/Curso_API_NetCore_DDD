using Domain.Configuration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class UfMap : IEntityTypeConfiguration<UFEntity>
    {
        public void Configure(EntityTypeBuilder<UFEntity> builder)
        {
            builder.ToTable("UF");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Initials).IsUnique();

            if (Configuration.GetConfiguration().DATABASE.ToLower().Equals("Postgres".ToLower()))
            {
                builder.Property(u => u.CreateAt).HasColumnType("timestamp without time zone");
                builder.Property(u => u.UpdateAt).HasColumnType("timestamp without time zone");
            }
        }
    }
}
