public class ItemPedido
{
    public Produto Produto { get; private set; }
    public int Quantidade { get; private set; }
    public decimal Subtotal => Produto.Preco * Quantidade;

    public ItemPedido(Produto produto, int quantidade)
    {
        if (produto == null)
            throw new ArgumentException("Produto inválido.");
        if (quantidade <= 0)
            throw new ArgumentException("Quantidade deve ser maior que zero.");

        Produto = produto;
        Quantidade = quantidade;
    }
}