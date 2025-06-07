using System;
using System.Collections.Generic;

public interface ILogger
{
    void Logar(string mensagem);
}

public interface IDescontoStrategy
{
    decimal CalcularDesconto(List<ItemPedido> itens);
}

class Program
{
    static void Main()
    {
        ILogger logger = new ConsoleLogger();

        Produto p1 = new Produto("Notebook", 1050m, "Tecnologia");
        Produto p2 = new Produto("Capacete", 150m, "Acessórios");
        Produto p3 = new Produto("Gume Ardente", 200m, "Facas");

        Cliente cliente = new Cliente("Carlos", "carloseduardosouzazneto@email.com", "09876543211");

        IDescontoStrategy desconto = new SemDescontoStrategy();

        PedidoFactory pedidoFactory = new PedidoFactory();

        RegrasPedido regras = new RegrasPedido(logger, pedidoFactory);

        var produtosComQuantidade = new List<(Produto produto, int quantidade)>
        {
            (p1, 1),
            (p2, 2),
            (p3, 3)
        };

        Pedido pedido = regras.CriarPedidoComDesconto(cliente, produtosComQuantidade, desconto);

        Console.WriteLine($"Este pedido foi criado para {pedido.Cliente.Nome} - O valor total do pedido é: R$ {pedido.ValorTotal:F2}");
    }
}

public class ConsoleLogger : ILogger
{
    public void Logar(string mensagem)
    {
        Console.WriteLine($"LOG: {mensagem}");
    }
}

public class SemDescontoStrategy : IDescontoStrategy
{
    public decimal CalcularDesconto(List<ItemPedido> itens)
    {
        return 0;
    }
}
