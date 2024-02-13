using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            string filePath = "";

            if (Directory.GetCurrentDirectory().Contains("Test"))
            {
                string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.Replace("\\test", string.Empty);
                filePath = Path.Combine(projectDirectory, "src", "API.Environment", "DbSettings.json");
            } else
            {
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "API.Environment", "DbSettings.json");
            }

            string jsonContent = File.ReadAllText(filePath);
            DbSettings dbSettings = JsonSerializer.Deserialize<DbSettings>(jsonContent);

            builder.ToTable("User");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Name).IsRequired().HasMaxLength(60);

            builder.Property(u => u.Email).HasMaxLength(100);

            if (dbSettings.DATABASE.ToLower().Equals("Postgres".ToLower()))
            {
                builder.Property(u => u.CreateAt).HasColumnType("timestamp without time zone");
                builder.Property(u => u.UpdateAt).HasColumnType("timestamp without time zone");
            }
        }
    }
}
