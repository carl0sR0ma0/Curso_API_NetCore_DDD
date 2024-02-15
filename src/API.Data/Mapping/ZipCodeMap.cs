using Domain.Configuration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class ZipCodeMap : IEntityTypeConfiguration<ZipCodeEntity>
    {
        public void Configure(EntityTypeBuilder<ZipCodeEntity> builder)
        {
            builder.ToTable("ZipCode");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.ZipCode);

            builder.HasOne(c => c.County).WithMany(m => m.ZipsCode);

            if (Configuration.GetConfiguration().DATABASE.ToLower().Equals("Postgres".ToLower()))
            {
                builder.Property(u => u.CreateAt).HasColumnType("timestamp without time zone");
                builder.Property(u => u.UpdateAt).HasColumnType("timestamp without time zone");
            }
        }
    }
}
