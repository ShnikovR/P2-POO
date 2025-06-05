using System;

class Program
{
    static void Main()
    {
        try
        {
            Cliente cliente1 = new Cliente("Victor Araujo", "victor2@hotmail.com", "59171348204");
            Cliente cliente2 = new Cliente("Luisa Souza", "luisass@gmail.com", "53587909008");

            Console.WriteLine("Clientes cadastrados:");
            ExibirCliente(cliente1);
            ExibirCliente(cliente2);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro ao cadastrar cliente: {ex.Message}");
        }

        try
        {
            Produto produto1 = new Produto("Windows 7 Vista", 400.00m, "Eletrônicos");
            Produto produto2 = new Produto("Rato de borracha", 25.00m, "Brinquedos");

            Console.WriteLine("Produtos cadastrados:");
            ExibirProduto(produto1);
            ExibirProduto(produto2);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro ao cadastrar produto: {ex.Message}");
        }
    }

    static void ExibirCliente(Cliente cliente)
    {
        Console.WriteLine($"ID: {cliente.Id} | Nome: {cliente.Nome} | Email: {cliente.Email} | CPF: {cliente.Cpf}");
    }

    static void ExibirProduto(Produto produto)
    {
        Console.WriteLine($"ID: {produto.Id} | Nome: {produto.Nome} | Preço: R${produto.Preco:F2} | Categoria: {produto.Categoria}");
    }
}
