public class Produto
{
    private static int LocalizarID_Produto = 1;

    public int Id { get; private set; }
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }
    public string Categoria { get; private set; }
    
    public Produto(string nome, decimal preco, string categoria)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome inválido.");
        if (preco <= 0)
            throw new ArgumentException("Preço deve ser maior que zero.");
        if (string.IsNullOrWhiteSpace(categoria))
            throw new ArgumentException("Categoria inválida.");

        Id = LocalizarID_Produto++;
        Nome = nome;
        Preco = preco;
        Categoria = categoria;
    }

    static void ExibirProduto(Produto produto)
    {
        Console.WriteLine($"ID: {produto.Id} | Nome: {produto.Nome} | Preço: R${produto.Preco:F2} | Categoria: {produto.Categoria}");
    }

}