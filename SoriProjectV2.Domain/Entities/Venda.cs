using System.ComponentModel.DataAnnotations;
using SoriProjectV2.Domain.Enums;

namespace SoriProjectV2.Domain.Entities;

public class Venda
{
    public int Id { get; set; }
    public List<ProdutoVenda> ProdutoVendas { get; set; }
    public Guid ClienteId { get; set; }
    public string ClienteNome { get; set; }
    public DateTime Data { get; set; }
    public decimal ValorTotal { get; set; }
    public Guid FilialId { get; set; }
    public string FilialNome { get; set; }
    public decimal Desconto { get; set; }
    public StatusVenda Status { get; set; }

    private Venda()
    {
        
    }
    public Venda(Guid clienteId,
        string clienteNome,
        DateTime data,
        Guid filialId, 
        string filialNome,
        List<ProdutoVenda> produtoVendas
        )
    {
        ClienteId = clienteId;
        ClienteNome = clienteNome;
        Data = data;
        FilialId = filialId;
        FilialNome = filialNome;
        ProdutoVendas = produtoVendas;
        Status = StatusVenda.NaoCancelado;

        foreach (var item in produtoVendas)
        {
            var (valorTotal, valorComDesconto) = item.CalcularValor();
            Desconto += valorTotal - valorComDesconto;
            ValorTotal += valorTotal;
            item.Produto = null;
        }
    }
}

/*
Número da venda; data em que a venda foi efetuada; cliente; valor total da venda; filial em que
a venda foi efetuada; produtos; quantidades; valores unitário; descontos; valor total de cada
item; Cancelado/Não Cancelado;*/