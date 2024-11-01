using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoriProjectV2.Domain.Entities;

namespace SoriProjectV2.Infra.Mappings;

public class VendaMapping : IEntityTypeConfiguration<Venda>
{
    public void Configure(EntityTypeBuilder<Venda> builder)
    {
        builder.HasKey(v => v.Id);

        builder.Property(v => v.ClienteNome)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(v => v.Data)
               .IsRequired();

        builder.Property(v => v.ValorTotal)
               .HasColumnType("decimal(18,2)");

        builder.Property(v => v.Desconto)
               .HasColumnType("decimal(18,2)");

        builder.Property(v => v.FilialNome)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(v => v.Status)
               .IsRequired();
    }
}
