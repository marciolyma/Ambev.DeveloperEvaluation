﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("Branch");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(b => b.Name)
                     .HasColumnType("varchar(100)")
                     .IsRequired();

            builder.Property(u => u.Status)
                    .HasConversion<string>()
                    .HasMaxLength(20);

        }
    }
}
