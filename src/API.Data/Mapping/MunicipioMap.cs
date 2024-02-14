using Domain.Configuration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class MunicipioMap : IEntityTypeConfiguration<MunicipioEntity>
    {
        public void Configure(EntityTypeBuilder<MunicipioEntity> builder)
        {
            builder.ToTable("Municipio");

            builder.HasKey(m => m.Id);

            builder.HasIndex(m => m.CodeIBGE);

            builder.HasOne(m => m.UF).WithMany(u => u.Municipios);

            if (Configuration.GetConfiguration().DATABASE.ToLower().Equals("Postgres".ToLower()))
            {
                builder.Property(m => m.CreateAt).HasColumnType("timestamp without time zone");
                builder.Property(m => m.UpdateAt).HasColumnType("timestamp without time zone");
            }
        }
    }
}
