using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sale");

            builder.HasKey(x => x.Id);

            builder.Property(b => b.Id)
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(b => b.SaleNumber)
                   .HasColumnType("varchar(100)")
                   .IsRequired();

            builder.Property(s => s.TotalAmount)
                   .HasColumnType("numeric(18,2)")
                   .IsRequired();

            builder.Property(s => s.BranchId)
                   .HasColumnType("uuid")
                   .IsRequired();

            builder.Property(u => u.Status)
                   .HasConversion<string>()
                   .HasMaxLength(20);


            builder.HasOne(x => x.Branch)
                   .WithMany()
                   .HasForeignKey(x => x.BranchId);





        }
    }
}
