using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ToTable("SaleItem");

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id)
               .HasColumnType("uuid")
               .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(i => i.SaleId)
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(i => i.ProductId)
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(i => i.Quantity)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(i => i.UnitPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(i => i.Discount)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(i => i.TotalAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.HasOne(i => i.Sale)
                .WithMany(s => s.SaleItems)
                .HasForeignKey(i => i.SaleId);

            builder.HasOne(i => i.Product)
                .WithMany()
                .HasForeignKey(i => i.ProductId);

        }
    }
}
