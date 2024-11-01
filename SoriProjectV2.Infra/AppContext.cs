using Microsoft.EntityFrameworkCore;
using SoriProjectV2.Domain.Entities;
using SoriProjectV2.Infra.Mappings;

namespace SoriProjectV2.Infra;

public class AppContext : DbContext
{
    public DbSet<Venda> Vendas { get; set; }
    public DbSet<ProdutoVenda> ProdutoVendas { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public AppContext(DbContextOptions<AppContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProdutoVendaMapping());
        modelBuilder.ApplyConfiguration(new VendaMapping());
        modelBuilder.ApplyConfiguration(new ProdutoMapping());
    }
}
