public class PedidoFactory
{
    public Pedido CriarPedido(Cliente cliente, List<ItemPedido> itens)
    {
        if (cliente == null)
            throw new ArgumentException("O cliente informado é inválido.");

        if (itens == null || itens.Count == 0)
            throw new ArgumentException("O pedido deve ser maior que zero.");

        return new Pedido(cliente, itens);
    }
}
