namespace SoriProjectV2.Api.Requests;

public class VendaRequest
{
    public Guid ClienteId { get; set; }
    public string ClienteNome { get; set; }
    public DateTime Data { get; set; }
    public decimal ValorTotal { get; set; }
    public Guid FilialId { get; set; }
    public string FilialNome { get; set; }
    public IEnumerable<ProdutoDTO> Produtos { get; set; }
}

public class ProdutoDTO
{
    public int Quantidade { get; set; }
    public Guid ProdutoId { get; set; }
}
