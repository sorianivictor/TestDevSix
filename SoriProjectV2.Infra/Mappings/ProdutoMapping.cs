using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoriProjectV2.Domain.Entities;

namespace SoriProjectV2.Infra.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.ExternalId)
                   .IsRequired();

            builder.Property(p => p.ValorUnitario)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();
        }

    }
}
