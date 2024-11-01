using Microsoft.EntityFrameworkCore;
using SoriProjectV2.Domain.Entities;

namespace SoriProjectV2.Infra.Repositories;

public class VendaRepository : IVendaRepository
{
    private readonly AppContext _context;

    public VendaRepository(AppContext context)
    {
        _context = context;
    }

    public async Task<Venda> CriarNovaVenda(Venda venda)
    {
        var entity = await _context.Vendas.AddAsync(venda);
        await _context.SaveChangesAsync();
        return entity.Entity;
    }

    public async Task<IEnumerable<Venda>> GetListaDeComprasPorIdentificadorDoUsuarioAsync(Guid clientId)
    {
        return await _context.Vendas.Where(x => x.ClienteId == clientId).ToListAsync();
    }
}
