using Domain.Configuration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class CepMap : IEntityTypeConfiguration<CepEntity>
    {
        public void Configure(EntityTypeBuilder<CepEntity> builder)
        {
            builder.ToTable("CEP");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Cep);

            builder.HasOne(c => c.Municipio).WithMany(m => m.Ceps);

            if (Configuration.GetConfiguration().DATABASE.ToLower().Equals("Postgres".ToLower()))
            {
                builder.Property(u => u.CreateAt).HasColumnType("timestamp without time zone");
                builder.Property(u => u.UpdateAt).HasColumnType("timestamp without time zone");
            }
        }
    }
}
