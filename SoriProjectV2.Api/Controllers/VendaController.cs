using Microsoft.AspNetCore.Mvc;
using SoriProjectV2.Api.Requests;
using SoriProjectV2.Domain.Entities;
using SoriProjectV2.Infra.Repositories;

namespace SoriProjectV2.Api.Controllers;

public class VendaController : Controller
{
    private readonly IVendaRepository _vendaRepository;
    private readonly IProdutoRepository _produtoRepository;
    public VendaController(IVendaRepository vendaRepository, IProdutoRepository produtoRepository)
    {
        _vendaRepository = vendaRepository;
        _produtoRepository = produtoRepository;
    }

    /// <summary>
    /// Retorna Compras do Usuário
    /// </summary>
    /// <param name="IdentificadorUsuario"></param>
    /// <returns></returns>
    [HttpGet("IdentificadorUsuario")]
    public async Task<IActionResult> GetListaDeComprasPorIdentificadorDoUsuarioAsync(Guid IdentificadorUsuario)
    {
        var listaCompras = await _vendaRepository.
            GetListaDeComprasPorIdentificadorDoUsuarioAsync(IdentificadorUsuario);
        return Ok(listaCompras);
    }

    /// <summary>
    /// Cria nova venda
    /// </summary>
    /// <param name="venda"></param>
    /// <returns></returns>
    [HttpPost("CriarNovaVenda")]
    public async Task<IActionResult> PostAsync([FromBody] VendaRequest venda)
    {
        var produtos = await _produtoRepository.BuscarProdutosPorIdentificadoresExternos(venda.Produtos.Select(x => x.ProdutoId));
        var produtosVenda = produtos
            .SelectMany(x=> venda.Produtos.Select(y=> new ProdutoVenda(x,y.Quantidade))).ToList();
            //.Select(x => new ProdutoVenda(x.Id, venda.Produtos
            //.First(y => y.ProdutoId == x.ExternalId).Quantidade)).ToList();

        var vendaSalvar = await _vendaRepository.CriarNovaVenda(new Venda(venda.ClienteId,
            venda.ClienteNome,
            venda.Data,
            venda.FilialId,
            venda.FilialNome,
            produtosVenda));
        return Ok(vendaSalvar);
    }
}
