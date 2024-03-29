﻿using Domain.Configuration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Name).IsRequired().HasMaxLength(60);

            builder.Property(u => u.Email).HasMaxLength(100);

            if (Configuration.GetConfiguration().DATABASE.ToLower().Equals("Postgres".ToLower()))
            {
                builder.Property(u => u.CreateAt).HasColumnType("timestamp without time zone");
                builder.Property(u => u.UpdateAt).HasColumnType("timestamp without time zone");
            }
        }
    }
}
