using System.ComponentModel.DataAnnotations;

namespace SoriProjectV2.Domain.Entities;

public class Venda
{
    public List<ProdutoVenda> Produtos { get; set; }
    public Guid ClienteId { get; set; }
    public string ClienteNome { get; set; }
    public DateTime Data { get; set; }
    public decimal ValorTotal { get; set; }
    public Guid FilialId { get; set; }
    public string FilialNome { get; set; }
    [RegularExpression(pattern:"\\d{1,3}\\,\\d{2}")]
    public decimal Desconto { get; set; }
    public StatusVenda Status { get; set; }

    public Venda(Guid clienteId,
        string clienteNome,
        DateTime data,
        Guid filialId, 
        string filialNome,
        List<ProdutoVenda> produtos,
        StatusVenda status
        )
    {
        ClienteId = clienteId;
        ClienteNome = clienteNome;
        Data = data;
        FilialId = filialId;
        FilialNome = filialNome;
        Produtos = produtos;
        Status = status;

        foreach (var item in produtos)
        {

        }
    }
}

/*
Número da venda; data em que a venda foi efetuada; cliente; valor total da venda; filial em que
a venda foi efetuada; produtos; quantidades; valores unitário; descontos; valor total de cada
item; Cancelado/Não Cancelado;*/