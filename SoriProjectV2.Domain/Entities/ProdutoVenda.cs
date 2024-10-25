using System.Xml.Serialization;

namespace SoriProjectV2.Domain.Entities;

public class ProdutoVenda
{
    public Produto ProdutoTeste { get; set; }
    public int ProdutoId { get; set; }
    public Venda Venda { get; set; }
    public int VendaId { get; set; }
    public int Quantidade { get; set; }


    public decimal CalcularValor()
    {
        decimal valorTotal = ProdutoTeste.ValorUnitario * Quantidade;
        switch (Quantidade)
        {
            case > 10:
                valorTotal *= 0.8M;
                break;
            case > 4:
                valorTotal *= 0.9M;
                break;
            default: 
                break;
        }

        return valorTotal;
    }
}