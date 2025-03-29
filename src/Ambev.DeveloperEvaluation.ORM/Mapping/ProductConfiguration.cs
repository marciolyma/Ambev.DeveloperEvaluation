using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(p => p.Id);
            builder.Property(si => si.Id)
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(p => p.Name)
                   .HasColumnType("varchar(100)")
                   .IsRequired();

            builder.Property(p => p.Description)
                   .HasColumnType("varchar(100)")
                   .IsRequired();

            builder.Property(p => p.Price)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();




        }
    }
}
