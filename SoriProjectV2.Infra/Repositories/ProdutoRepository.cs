using Microsoft.EntityFrameworkCore;
using SoriProjectV2.Domain.Entities;

namespace SoriProjectV2.Infra.Repositories;

internal class ProdutoRepository : IProdutoRepository
{
    private readonly AppContext _context;

    public ProdutoRepository(AppContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Produto?>> BuscarProdutosPorIdentificadoresExternos(IEnumerable<Guid> identificadores)
    {
        return await _context.Produtos.Where(x => identificadores.Contains(x.ExternalId)).ToListAsync();
    }
}
