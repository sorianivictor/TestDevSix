using SoriProjectV2.Domain.Entities;

namespace SoriProjectV2.Infra.Repositories;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto?>> BuscarProdutosPorIdentificadoresExternos(IEnumerable<Guid> identificadores);
}