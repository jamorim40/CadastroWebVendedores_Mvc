namespace CadastroWebVendedores_Mvc.Models
{
    public class Vendedor
    {
        //Atributos da classe Vendedor
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public double SalarioBase { get; set; }

        //Associação entre Vendedor e Departamento (muitos para 1)
        public Departamento? Departamento { get; set; }

        //Associação entre Vendedor e RegistroDeVendas (1 para muitos)
        public ICollection<RegistroDeVendas> Vendas { get; set; } = new List<RegistroDeVendas>();//Vendas é uma coleção de registros de vendas

        //Construtor vazio
        public Vendedor()
        {
        }

        //Construtor com parâmetros
        public Vendedor(int id, string nome, string email, DateTime dataNascimento, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        //Método para adicionar uma venda ao vendedor
        public void AdicionarVenda(RegistroDeVendas rv) //rv = registro de vendas
        {
            Vendas.Add(rv);
        }

        //Método para remover uma venda do vendedor
        public void RemoverVenda(RegistroDeVendas rv)
        {
            Vendas.Remove(rv);
        }

        //Método para calcular o total de vendas em um período específico
        public double TotalVendas(DateTime dataInicial, DateTime dataFinal)
        {
            return Vendas //Vendas é a coleção de registros de vendas
                .Where(rv => rv.Data >= dataInicial && rv.Data <= dataFinal)
                .Sum(rv => rv.ValorDeVenda);
        }
    }
}
