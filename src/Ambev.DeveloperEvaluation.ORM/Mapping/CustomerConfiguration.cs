using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("gen_random_uuid()");
            builder.Property(c => c.Name)
                     .HasColumnType("varchar(100)")
                     .IsRequired();
            builder.HasMany(c => c.Branches)
                   .WithOne()
                   .HasForeignKey(b => b.CustomerId);

            builder.Property(u => u.Status)
                   .HasConversion<string>()
                   .HasMaxLength(20);

        }
    }
}
