public class Pedido
{
    private static int LocalizarID_Pedido = 1;

    public int Id { get; private set; }
    public Cliente Cliente { get; private set; }
    public List<ItemPedido> Itens { get; private set; }
    public DateTime Data { get; private set; }
    public decimal ValorTotal { get; private set; }

    public Pedido(Cliente cliente, List<ItemPedido> itens)
    {
        if (cliente == null)
            throw new ArgumentException("O cliente informado é inválido.");
        if (itens == null || itens.Count == 0)
            throw new ArgumentException("O pedido deve ser maior que zero.");

        Id = LocalizarID_Pedido++;
        Cliente = cliente;
        Itens = itens;
        Data = DateTime.Now;

        CalcularValorTotal();
    }

    private void CalcularValorTotal()
    {
        ValorTotal = Itens.Sum(item => item.Subtotal);
    }
    public void AtualizarValorTotalComDesconto(decimal desconto)
    {
        CalcularValorTotal();
        ValorTotal -= desconto;
    }
}
