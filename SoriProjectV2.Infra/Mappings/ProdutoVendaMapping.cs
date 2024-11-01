using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoriProjectV2.Domain.Entities;

namespace SoriProjectV2.Infra.Mappings
{
    public class ProdutoVendaMapping : IEntityTypeConfiguration<ProdutoVenda>
    {
        public void Configure(EntityTypeBuilder<ProdutoVenda> builder)
        {
            builder.HasKey(pv => new { pv.ProdutoId, pv.VendaId });

            builder.Property(pv => pv.Quantidade)
                   .IsRequired();

            builder.HasOne(pv => pv.Produto)
                   .WithMany()
                   .HasForeignKey(pv => pv.ProdutoId)
                   .IsRequired();

            builder.HasOne(pv => pv.Venda)
                   .WithMany(v => v.ProdutoVendas)
                   .HasForeignKey(pv => pv.VendaId)
                   .IsRequired();
        }
    }
}
