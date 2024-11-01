namespace SoriProjectV2.Domain.Entities;

public class Produto
{
    public int Id { get; set; }
    public Guid ExternalId { get; set; }
    public decimal ValorUnitario { get; set; }

    public ICollection<ProdutoVenda> ProdutoVenda { get; set; }
}


/*
Número da venda; data em que a venda foi efetuada; cliente; valor total da venda; filial em que 
a venda foi efetuada; produtos; quantidades; valores unitário; descontos; valor total de cada 
item; Cancelado / Não Cancelado;*/