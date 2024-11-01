namespace SoriProjectV2.Domain.Entities;

public class ProdutoVenda
{
    public ProdutoVenda(Produto produto, int quantidade)
    {
        Produto = produto;
        ProdutoId = produto.Id;
        Quantidade = quantidade;
    }

    public ProdutoVenda()
    {
        
    }

    public Produto Produto { get; set; }
    public int ProdutoId { get; set; }
    public Venda Venda { get; set; }
    public int VendaId { get; set; }
    public int Quantidade { get; set; }

    public (decimal valorTotal, decimal valorComDesconto) CalcularValor()
    {
        decimal valorTotal;
        decimal valorComDesconto;
        valorTotal = valorComDesconto = Produto.ValorUnitario * Quantidade;
        switch (Quantidade)
        {
            case > 10:
                valorComDesconto *= 0.8M;
                break;
            case > 4:
                valorComDesconto *= 0.9M;
                break;
            default:
                break;
        }

        return (valorTotal, valorComDesconto);
    }
}