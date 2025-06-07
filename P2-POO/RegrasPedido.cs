public class RegrasPedido
{
    private readonly ILogger _logger;
    private readonly PedidoFactory _pedidoFactory;

    public RegrasPedido(ILogger logger, PedidoFactory pedidoFactory)
    {
        _logger = logger;
        _pedidoFactory = pedidoFactory;
    }

    public Pedido CriarPedidoComDesconto(Cliente cliente, List<(Produto produto, int quantidade)> produtosComQuantidade, IDescontoStrategy descontoStrategy)
    {
        if (cliente == null)
        {
            _logger.Logar("Cliente não pode estar vazio.");
            return null;
        }

        if (produtosComQuantidade == null || produtosComQuantidade.Count == 0)
        {
            _logger.Logar("Lista de produtos não pode ser vazia.");
            return null;
        }

        _logger.Logar($"Criando pedido para o cliente {cliente.Nome}");

        var itens = new List<ItemPedido>();
        foreach (var pq in produtosComQuantidade)
        {
            var item = new ItemPedido(pq.produto, pq.quantidade);
            itens.Add(item);
        }

        Pedido pedido = _pedidoFactory.CriarPedido(cliente, itens);

        decimal valorTotalBruto = pedido.ValorTotal;

        _logger.Logar($"Valor total bruto: R$ {valorTotalBruto:F2}");

        decimal desconto = descontoStrategy.CalcularDesconto(itens);
        pedido.AtualizarValorTotalComDesconto(desconto);

        _logger.Logar($"Desconto aplicado: R$ {desconto:F2}");
        _logger.Logar($"Valor com desconto: R$ {pedido.ValorTotal:F2}");

        _logger.Logar("Este pedido foi criado com sucesso!");

        return pedido;
    }
}
