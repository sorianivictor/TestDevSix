using SoriProjectV2.Domain.Entities;

namespace SoriProjectV2.Infra.Repositories;

public interface IVendaRepository
{
    Task<Venda> CriarNovaVenda(Venda venda);
    Task<IEnumerable<Venda>> GetListaDeComprasPorIdentificadorDoUsuarioAsync(Guid clientId);
}