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
    }

    static void ExibirCliente(Cliente cliente)
    {
        Console.WriteLine($"ID: {cliente.Id} | Nome: {cliente.Nome} | Email: {cliente.Email} | CPF: {cliente.Cpf}");
    }
}