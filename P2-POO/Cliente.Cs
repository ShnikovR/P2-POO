public class Cliente
{
    private static int LocalizarID_Cliente = 1;

    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Cpf { get; private set; }
    public Cliente(string nome, string email, string cpf)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome informado é inválido.");
        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            throw new ArgumentException("O email informado é inválido.");
        if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11)
            throw new ArgumentException("O CPF informado é inválido.");

        Id = LocalizarID_Cliente++;
        Nome = nome;
        Email = email;
        Cpf = cpf;
    }
}